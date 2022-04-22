using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Oink.Core.Azure.Cosmos.FunctionHelpers;
using Oink.FinancialAccountMgmt.Accounts.Api;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Oink.FinancialAccountMgmt.Accounts.Api;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        ConfigureServices(builder);
    }
    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        var builtConfig = builder.ConfigurationBuilder.Build();
        var configKeyVault = builtConfig.GetValue<string?>(ApplicationConstants.KeyVaultName);

        var configBuilder = builder.ConfigurationBuilder
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("local.settings.json", true)
            .AddEnvironmentVariables();

        if (!string.IsNullOrEmpty(configKeyVault))
            configBuilder.AddAzureKeyVault(new Uri($"https://{configKeyVault}.vault.azure.net/"), new DefaultAzureCredential());

        configBuilder.Build();
    }

    private void ConfigureServices(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;
        builder.Services.AddSingleton<ICosmosDBSerializerFactory, SystemTextCosmosSerializerFactory>();

        // Currently using both NewtonSoft (Http) & System.Text (Cosmos)
        // https://github.com/Azure/azure-functions-host/issues/5469
        builder.Services.AddMvcCore().AddNewtonsoftJson(x => x.SerializerSettings.Converters.Add(new StringEnumConverter()));

        // For configuration of AAD (B2C in this case) without EasyAuth
        // Meant for deployment to Kubernetes
        if (configuration.GetSection(ApplicationConstants.AadConfigurationSectionName).Exists())
        {
            builder.Services
                .AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = Microsoft.Identity.Web.Constants.Bearer;
                    sharedOptions.DefaultChallengeScheme = Microsoft.Identity.Web.Constants.Bearer;
                })
                .AddMicrosoftIdentityWebApi(jwtOptions =>
                {
                    configuration.Bind(ApplicationConstants.AadConfigurationSectionName, jwtOptions);
                    jwtOptions.TokenValidationParameters.NameClaimType = "name";
                }, msftIdentityOptions => configuration.Bind(ApplicationConstants.AadConfigurationSectionName, msftIdentityOptions));
        }

    }
}

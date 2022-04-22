using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace Oink.FinancialAccountMgmt.Accounts.Api.Monitoring;
public class CustomTelemetryInitializer : ITelemetryInitializer
{
    public CustomTelemetryInitializer()
    {
    }

    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry == null)
        {
            return;
        }

        telemetry.Context.Cloud.RoleName = "Test";
    }
}

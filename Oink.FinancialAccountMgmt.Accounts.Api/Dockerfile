#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG OINK_NUGET_KEY
WORKDIR /src
COPY ["Oink.FinancialAccountMgmt.Accounts.Api/Oink.FinancialAccountMgmt.Accounts.Api.csproj", "Oink.FinancialAccountMgmt.Accounts.Api/"]
COPY ["Oink.FinancialAccountMgmt.Domain/Oink.FinancialAccountMgmt.Domain.csproj", "Oink.FinancialAccountMgmt.Domain/"]
COPY nuget.config .
RUN dotnet restore "Oink.FinancialAccountMgmt.Accounts.Api/Oink.FinancialAccountMgmt.Accounts.Api.csproj"
COPY . .
WORKDIR "/src/Oink.FinancialAccountMgmt.Accounts.Api"
RUN dotnet build "Oink.FinancialAccountMgmt.Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Oink.FinancialAccountMgmt.Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true
# Sample - Financial account managment function on AKS
**This is a work in progress. This repo is a part of a larger effort to demonstrate secure workloads on Azure. This is for reference only and not meant for production workloads**
Serverless Azure Function used to demonstrate several concepts. This is meant to be deployed in a private AKS cluster. All supporting resources are connected via Private Link.

## Features
* Managed Identity data plane access to Cosmos DB.
* Custom JSON serialization for HTTP (Newtonsoft) and CosmosDB (System.Text.Json) bindings
* Custom authentication & authorization using Azure B2C
* Generates OpenApi documentation for Azure API Management consumption 

## Related GitHub repositories

### Supporting
|Item|Description|
|----|-----|
|[Utility Docker Images](https://github.com/colincmac/oink-docker-images)|Images used to support Ops scenarios. Built using [ACR Tasks](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-tasks-overview)|
|[Helm Charts](https://github.com/colincmac/oink-helm-charts)|Helm charts to support GitOps scenarios|
|[AKS GitOps - Core Platform](https://github.com/colincmac/aks-lz-manifests)|Flux multi-tenant configuration in AKS - Core Platform|
|[AKS GitOps - Shared Services](https://github.com/colincmac/aks-lz-shared-services-manifests)|Flux multi-tenant configuration in AKS - Shared Services|

### Application Workloads
|Item|Description|
|----|-----|
|[Shared .NET Libraries](https://github.com/colincmac/oink-core-dotnet)|Base .NET seedwork for implementing CQRS, EventSourcing, and DDD|
|[Financial Account Management](https://github.com/colincmac/oink-financial-account-mgmt)|Serverless Azure Function used to demonstrate several concepts|

## Getting Started

### Prerequisites

(ideally very short, if any)

- OS
- Library version
- ...

### Installation

(ideally very short)

- npm install [package name]
- mvn install
- ...

### Quickstart
(Add steps to get up and running quickly)

1. git clone [repository clone url]
2. cd [repository name]
3. ...


## Demo

A demo app is included to show how to use the project.

To run the demo, follow these steps:

(Add steps to start up the demo)

1.
2.
3.

## Resources

(Any additional resources or related projects)

- Link to supporting information
- Link to similar sample
- ...

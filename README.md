# Universal migration toolkit for Xperience

<!-- ABOUT THE PROJECT -->
## About The Project

UMT is an open-source set of software libraries, documentation, and samples distributed via NuGet packages to facilitate and automate data import from external systems (Sitecore, Sitefinity, Legacy Kentico, etc. ) into Xperience by Kentico.

<!-- GETTING STARTED 
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.-->

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

* [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* Xperience by Kentico of version **26.4.0**


### Installation

1. Install the NuGet package

   ```powershell
   dotnet add package <Package Name> --version 1.2.3
   ```
2. Open file with dependency injection container configuration (`Program.cs` / `Startup.cs` / ...)
3. import namespace `Kentico.UMT`
4. register Umt to service collection `IServiceCollection` using `AddUniversalMigrationToolkit()`
5. inject `IImportService` where you want use migration toolkit

<!-- USAGE EXAMPLES -->
## Usage

### Convert & Import samples

advanced usage is covered [here](./Docs/README.md)

#### Console sample

[Console application](./Examples/Kentico.Xperience.UMT.Example.Console/README.md) sample shows usage of toolkit in console application. 

#### Administration plug-in sample
[Administration plugin](./Examples/Kentico.Xperience.UMT.Example.AdminApp/README.md) sample shows deployment of toolkit as administration application that receives file with serialized data as JSON and performs import of data.

<!-- 
### Export samples

**TODO**

_For more examples, please refer to the [Documentation](./Documentation.md)_
-->

<!-- CONTRIBUTING -->
## Contributing

For Contributing please see  <a href="./CONTRIBUTING.md">`CONTRIBUTING.md`</a> for more information.

### Requirements

* [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

<!-- LICENSE -->
## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.

<!-- SUPPORT -->
## Support

This contribution has __Full support by 7-day bug-fix policy__ / __Kentico Labs limited support__. See [`SUPPORT.md`](./SUPPORT.md) for more information.

For any security issues see [`SECURITY.md`](./SECURITY.md).
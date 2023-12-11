# Xperience by Kentico Universal Migration Toolkit

[![CI: Build and Test](<[https://github.com/Kentico/xperience-by-kentico-lucene](https://github.com/Kentico/xperience-by-kentico-universal-migration-toolkit)/actions/workflows/ci.yml/badge.svg?branch=main>)](<[https://github.com/Kentico/xperience-by-kentico-lucene](https://github.com/Kentico/xperience-by-kentico-universal-migration-toolkit)/actions/workflows/ci.yml>)

[![NuGet Package](https://img.shields.io/nuget/v/Kentico.Xperience.UMT.svg)](https://www.nuget.org/packages/Kentico.Xperience.UMT)

## About The Project

The Universal Migration Toolkit (UMT) is an open-source set of software libraries, documentation, and samples distributed via NuGet packages to facilitate and automate data import from external systems (Legacy Kentico, etc...) into Xperience by Kentico.

## Getting Started

### Prerequisites

- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Xperience by Kentico of version **28.0.1**

### Installation

1. Install the NuGet package

   ```powershell
   dotnet add package Kentico.Xperience.UMT
   ```

2. Open file with dependency injection container configuration (`Program.cs` / `Startup.cs` / ...)
3. Import namespace `Kentico.Xperience.UMT`
4. Register Umt to service collection `IServiceCollection` using `AddUniversalMigrationToolkit()`
5. Inject `IImportService` where you want use migration toolkit

## Usage

### Convert & Import samples

Advanced usage is covered [in the extended documentation](./Docs/README.md)

#### Console sample

[Console application](./Examples/Kentico.Xperience.UMT.Example.Console/README.md) sample shows usage of toolkit in console application.

#### Administration plug-in sample

[Administration plugin](./Examples/Kentico.Xperience.UMT.Example.AdminApp/README.md) sample shows deployment of toolkit as administration application that receives file with serialized data as JSON and performs import of data.

## Contributing

For Contributing please see [`CONTRIBUTING.md`](https://github.com/Kentico/.github/blob/main/CONTRIBUTING.md) for more information and follow the [`CODE_OF_CONDUCT`](https://github.com/Kentico/.github/blob/main/CODE_OF_CONDUCT.md).

### Requirements

- .NET SDK >= 7.0.109

  - <https://dotnet.microsoft.com/en-us/download/dotnet/7.0>

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.

## Support

This contribution has **Full support by 7-day bug-fix policy**.

See [`SUPPORT.md`](https://github.com/Kentico/.github/blob/main/SUPPORT.md#full-support) for more information.

For any security issues see [`SECURITY.md`](https://github.com/Kentico/.github/blob/main/SECURITY.md).

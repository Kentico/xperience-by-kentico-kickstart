

## Description

The src folder of this repository represents what you should see if you follow along with the steps of the [Kickstart for developers](https://docs.kentico.com/guides/development). **!!! ADD LINK ONCE TUTOTIAL EXISTS**

It contains a simple navigation menu and two pages that utilize reusable content items.

## Requirements

### Dependencies

- [ASP.NET Core 8.0](https://dotnet.microsoft.com/en-us/download)
- [Xperience by Kentico 29.3.0](https://docs.kentico.com)

## Quick Start

1. Download and restore the **.bak** file from the [Database](./database/) folder to your SQL server, or install a new Xperience by Kentico database of version **29.3.0**.
1. Download the repository and add a `CMSConnectionString` property that points to this database to the `ConnectionStrings` section of [appsettings.json](./src/Kickstart.Web/appsettings.json).
1. Use the `dotnet run --kxp-ci-restore` command from the [Kickstart.Web](./src/Kickstart.Web/) directory to populate the database.

## Full Instructions

View the [Usage Guide](./docs/Usage-Guide.md) for more detailed instructions.

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.
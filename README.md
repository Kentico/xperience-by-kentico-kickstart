

## Description

The src folder of this repository represents what you should see if you follow along with the steps of the [Kickstart for developers](https://docs.kentico.com/tutorial/developer-tutorial).

It contains a simple navigation menu and two pages that utilize reusable content items.

## Requirements

### Dependencies

- [ASP.NET Core 8.0](https://dotnet.microsoft.com/en-us/download)
- [Xperience by Kentico 29.3.0](https://docs.kentico.com)

## Quick Start

1. Download and restore the **.bak** file from the [database](./database/) folder to your SQL server, or install a new Xperience by Kentico database, version **29.3.0**.
1. Clone or download the repository and edit [appsettings.json](./src/Kickstart.Web/appsettings.json).
    - Add a `CMSConnectionString` property that points to your database to the `ConnectionStrings` section, e.g.:
      ```
      "ConnectionStrings": {
            "CMSConnectionString": "Data Source=<YOUR_SQL_SERVER_NAME>;Initial Catalog=<DATABASE_NAME>;Integrated Security=True;Persist Security Info=False;Connect Timeout=60;Encrypt=False;Current Language=English;"    
      }
      ```
1. Use the `dotnet run --kxp-ci-restore` command from the [Kickstart.Web](./src/Kickstart.Web/) directory to populate the database.
1. Log in under the **~/admin** path with the username **administrator** and the password **kickstart**.

## Contributing

This repository is related to an introductory tutorial and is kept simple for educational purposes. For this reason, please do not submit ideas for new functionality. However, please do let us know if you encounter a bug that needs to be fixed, either by submitting an issue or contributing a fix directly.

To see the guidelines for Contributing to Kentico open source software, please see [Kentico's `CONTRIBUTING.md`](https://github.com/Kentico/.github/blob/main/CONTRIBUTING.md) for more information and follow the [Kentico's `CODE_OF_CONDUCT`](https://github.com/Kentico/.github/blob/main/CODE_OF_CONDUCT.md).

Instructions and technical details for contributing to **this** project can be found in [Contributing Setup](./docs/Contributing-Setup.md).

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.

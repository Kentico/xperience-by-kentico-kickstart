## Description

The src folder of this repository represents what you should see if you follow along with the steps of the [Kickstart for developers](https://docs.kentico.com/tutorial/developer-tutorial).

It contains a simple navigation menu and two pages that utilize reusable content items.

## Requirements

### Dependencies

- [ASP.NET Core 10.0](https://dotnet.microsoft.com/en-us/download)
- [Xperience by Kentico 31.8.2](https://docs.kentico.com)

## Quick Start

1. Clone or download the repository.
1. From the [Kickstart.Web](./src/Kickstart.Web/) directory, run `dotnet tool restore` to restore the required .NET tools, including the Xperience by Kentico Database Manager.
1. Create your Xperience by Kentico database, version **31.8.2**, by running the `dotnet kentico-xperience-dbmanager` command, providing your own SQL Server name and admin password, e.g.:
      ```
      dotnet kentico-xperience-dbmanager -- -s "<YOUR_SQL_SERVER_NAME>" -a "<YOUR_ADMIN_PASSWORD>" -d "Xperience.Kickstart" --hash-string-salt "59642433-67b2-4230-9c5b-ad98d02b0c72"
      ```
    This command automatically updates [appsettings.json](./src/Kickstart.Web/appsettings.json), setting the `CMSConnectionString` and `CMSHashStringSalt` values.
1. Use the `dotnet run --kxp-ci-restore` command from the [Kickstart.Web](./src/Kickstart.Web/) directory to populate the database.
1. Navigate to **~/admin** path and sign in with the username `administrator` and the password you specified in the previous step.
1. Apply your license key to the instance:
    1. Access the **Settings** application.
    1. Paste your license key into the **License key** field under the **System → License** category and click **Save**.
    ![Screenshot of Settings application](/images/SettingsApp.png)
    ![Screenshot of license key settings](/images/SettingsLicense.png)

> [!TIP]
> You can obtain a license key from your agency, supervisor, or team lead.  
> Alternatively, you can create an account at the [Client Portal](https://client.kentico.com/), and generate a [temporary key](https://client.kentico.com/evaluation-keys) valid for 30 days.  
> Learn more about licensing in our [documentation](https://docs.kentico.com/developers-and-admins/installation/licenses).


## Contributing

This repository is related to an introductory tutorial and is kept simple for educational purposes. For this reason, please do not submit ideas for new functionality. However, please do let us know if you encounter a bug that needs to be fixed, either by submitting an issue or contributing a fix directly.

To see the guidelines for Contributing to Kentico open source software, please see [Kentico's `CONTRIBUTING.md`](https://github.com/Kentico/.github/blob/main/CONTRIBUTING.md) for more information and follow the [Kentico's `CODE_OF_CONDUCT`](https://github.com/Kentico/.github/blob/main/CODE_OF_CONDUCT.md).

Instructions and technical details for contributing to **this** project can be found in [Contributing Setup](./docs/Contributing-Setup.md).

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.

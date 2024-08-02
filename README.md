

## Description

The src folder of this repository represents what you should see if you follow along with the steps of the [Kickstart for developers](https://docs.kentico.com/guides/development). **!!! ADD LINK ONCE TUTOTIAL EXISTS**

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
    <!-- I personally can never remember the shape of the connection string. Considering also that this is their first time w Xperience likely, I suggest we give them an example without server and database name. If you agree, pls remove this comment. If you disagree, feel free to remove the example as well. :)
     -->
1. Use the `dotnet run --kxp-ci-restore` command from the [Kickstart.Web](./src/Kickstart.Web/) directory to populate the database.
1. Log in under the **~/admin** path with the username **administrator** and the password **kickstart**.

## License

Distributed under the MIT License. See [`LICENSE.md`](./LICENSE.md) for more information.
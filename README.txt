Open the shortcut menu for Data Connections and choose Add New Connection.

The Add Connection dialog box appears.

Choose the Change button.

The Change Data Source dialog box appears.

Select Microsoft SQL Server and choose the OK button.

The Add Connection dialog box reappears, with Microsoft SQL Server (SqlClient) displayed in the Data source text box.

In the Server Name box, type or browse to the path to the local instance of SQL Server. You can type the following:

    "." for the default instance on your computer.

    "(LocalDB)\v11.0" for the default instance of SQL Server Express LocalDB.

    ".\SQLEXPRESS" for the default instance of SQL Server Express.

For information about SQL Server Express LocalDB and SQL Server Express, see Local Data Overview.

Select either Use Windows Authentication or Use SQL Server Authentication.

Choose Attach a database file, Browse, and open an existing .mdf file.

Choose the OK button.

The new database appears in Server Explorer. It will remain connected to SQL Server until you explicitly detach it.
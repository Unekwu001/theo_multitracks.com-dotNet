Thank you for considering my application. Below is my Documentation
-------------------------------------------------------------------
**DATABASE IS PUBLISHED REMOTELY, SO THERE WONT BE NEED TO CHANGE CONNECTION STRING. YOU CAN GO AHEAD AND TEST.**
IF you wish to connect to the Database via SSMS, Kindly see details below:



For SSMS 2019

Server name: multitracksDB.mssql.somee.com

Authentication: Sql Server Authentication

Login: otus_SQLLogin_1

password: uloom78tzf

Database Name: multitracksDB








To get started:
- Clone the repo locally	
- Open the solution in Visual Studio	and Run **"Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"** from the Package Manager Console	
-  There are 3 API Projects. Feel free to test any. However, **API using Dapper or EntityFramework is recommended**.

-  **Web Project Instruction**
-  To test Web project,  
-  Simply use this format: **"localhost/artistDetails.aspx?artistID=2"**. This will automatically generate a details page for the artist with ID of 2.
-  **PLEASE NOTE** - There is no Need to change connection string.
-  

**API_using_Dapper**
-  To test API_using_Dapper, change the startup project to "API_using_Dapper" then run the project.

  

  **API_using_EntityFramework**
-  To test API_using_Entity framework, change to startup project and run.
-  Please Note that Entities were automatically generated using Scaffold command : "Scaffold-DbContext 'YourConnectionString' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities".

**API_using_ADO.NET**
-  To test API_using_ADO.NET, select as startup project and run project.


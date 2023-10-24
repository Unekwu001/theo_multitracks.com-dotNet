Thank you for considering my application. Below is my Documentation
-------------------------------------------------------------------
**DATABASE IS PUBLISHED REMOTELY, SO THERE WONT BE NEED TO CHANGE CONNECTION STRING. YOU CAN GO AHEAD AND TEST.**
To get started:
- Clone the repo locally	
- Open the solution in Visual Studio	and Run **"Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"** from the Package Manager Console	
-  There are 2 API Projects. Feel free to test any. However, **API using EntityFramework is recommended**.

-  **Web Project Instruction**
-  To test Web project,  
-  Simply use this format: **"localhost/artistDetails.aspx?artistID=2"**. This will automatically generate a details page for the artist with ID of 2.
-  **PLEASE NOTE** - There is no Need to change connection string.

  **API_using_EntityFramework**
-  To test API_using_Entity framework, please ensure to change connection string to your local. Change connection string within 'MyMultitrackDbContext' folder and app.settings.json file. YOu would also need to install EntityframeworkCore,EntityFrameworkTools,EntityFrameworkSqlServer from NuGet Pakage Manager.
-  Please Note that Entities were automatically generated using Scaffold command : "Scaffold-DbContext 'YourConnectionString' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities".

**API_using_ADO.NET**
-  To test API_using_ADO.NET, select as startup project, change the connection string at WebConfig, and run project.


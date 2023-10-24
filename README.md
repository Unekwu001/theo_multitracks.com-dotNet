Thank you for considering my application. Below is my Documentation
-------------------------------------------------------------------
To get started:
- Clone the repo locally	
- Open the solution in Visual Studio	and Run "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r" from the Package Manager Console	
-  There are 2 API Projects. **API using EntityFramework is recommended**.
-  To test Web project, Please change connection strings of the webproject to your desired local and publish DB.
-  Test the Details page using the url. For example if you are using your local machine and you want to view the Artist with ID of 2, you will need to visit: "localhost/artistDetails.aspx?artistID=2". This will automatically generate a details page for the artist with ID of 2.

  
-  To test API_using_Entity framework, please ensure to change connection string to your local. Change connection string within 'MyMultitrackDbContext' folder and app.settings.json file. YOu would also need to install EntityframeworkCore,EntityFrameworkTools,EntityFrameworkSqlServer from NuGet Pakage Manager.
-  Please Note that Entities were automatically generated using Scaffold command : "Scaffold-DbContext 'YourConnectionString' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities".

-  To test API_using_ADO.NET, select as startup project, change the connection string at WebConfig, and run project.


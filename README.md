# ticketManager

The webstite is connected to Azure sql server. As a result, you have to modify the sql connection confegration to connect to your local DB.
To run this project:
- import **script.sql** to your sql server.
- modify Web.config connectionStrings. Don't change the name, only the **connectionString**.

The connectionStrings in the project (Azure sql server):
``` Config
<connectionStrings>
    <add name="DefaultConnection" connectionString="Server=tcp:aspnet-ticketmanager-20210329014834dbserver.database.windows.net,1433;Initial Catalog=aspnet-ticketManager-20210329014834;Persist Security Info=False;User ID=ahmed;Password=Ab@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```


any questions:
ahha000@gmail.com

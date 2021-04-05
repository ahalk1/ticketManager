# ticketManager

The webstite is connected to Azure sql server. As a result, you have to modify the sql connection confegration to connect to your local DB.
To run this project:
- import **script.sql** to your sql server.
- modify Web.config connectionStrings. Don't change the name, only the **connectionString**.

The connectionStrings in the project (my local sql server):
``` Config
<connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(localdb)\ticketDB;Initial Catalog=ticketMDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```


any questions:
ahha000@gmail.com

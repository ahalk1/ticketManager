# ticketManager
**(Tested using different machine)**

The website is connected to the Azure SQL server. As a result, you have to modify the SQL connection configuration to connect to your local DB.
To run this project:
- import **ticketMDB.bacpac** to your sql server. **(updated)**
- modify Web.config connectionStrings. Don't change the name, only the **connectionString**.

The connectionStrings in the project (my local sql server):

- make sure to change the **Source** and the **Catalog** to match your sql server
``` Config
<connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(localdb)\ticketDB;Initial Catalog=ticketMDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```


any questions:
ahha000@gmail.com

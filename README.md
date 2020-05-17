# BookStore_Authors
ASP.NET Core Web Application using EF, Repository Pattern, JWT Token, AutoMapper, Swagger, SQL . 
Provides all endpoints to perform CURD operation for Authors table

Note: after you open the project, 
 1.download the required packages
      microsoft.entityframeworkcore
      microsoft.entityframeworkcore.sqlserver
      microsoft.entityframeworkcore.tools
      swashbuckle.aspnetcore
      automapper.extensions.microsoft.dependencyinjection
      microsoft.aspnetcore.authentication.jwtbearer
      
  2.open appsettings.json and upate the database configuration details
  
  3.open package manager console window and run this command 
        => add-migration initial -verbose 
          //this will generate the requried migration files
          // and then
          // run the following command OR run the application  - to create the database,tables and rows in the SQL
        => udpadate-database

 




# RegisterLoginWebApi
1)Open appsetting.json 
2)Change the "Ef_Postgres_Db" Connection string values to your database values 
3)Open VSCode terminal and paste the cli commands of EntityFrameWorkCore and Npgsql.EntityFrameworkCore
4)After nuget installizations use "dotnet ef migrations add initialdatabase"cli command to do create your AccountsDatabase
5)Use "dotnet ef database update" command to update database 
6)Use "dotnet build" command to build your code before start
7)Afer build use "dotnet watch" command and finally swagger opens automatically 

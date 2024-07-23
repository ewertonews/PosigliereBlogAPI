# Posig.Blog.API
## Steps to run the application:
1. Using a terminal/cmd navigate to /src/Posig.Blog.API
2. Run the command: ```dotnet run --configuration Debug --launch-profile "https"```
3. Then navigate to the [Swagger UI](https://localhost:7189/swagger/index.html) to test the API.
## Database
The API is using SQLite data and the database file is already in the code, but if needed to setup the db againg for the first time do:
1. Using a terminal/cmd navigate to /src/Posig.Blog.Data
2. Run the command ```dotnet ef migrations add InitialCreate --startup-project ..\Posig.Blog.API```
3. Update the database:  ```dotnet ef database update --startup-project ..\Posig.Blog.API```
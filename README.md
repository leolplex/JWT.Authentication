# JWT.Authentication

This workshop is performed in order to create a JWT Authenticator:

1. Add packages dependencies:
    - `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer`
    - `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore`
    - `dotnet add package Microsoft.EntityFrameworkCore`
    - `dotnet add package Microsoft.EntityFrameworkCore.Design`
    - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
    - `dotnet add package Microsoft.EntityFrameworkCore.Tools`
    - `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
    - `dotnet add package System.IdentityModel.Tokens.Jwt`
2. Run migrations
    - `dotnet ef database update`
3. Build solution
    - `dotnet build`


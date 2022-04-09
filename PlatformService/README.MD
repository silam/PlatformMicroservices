
1-Step to create API PlatformService

dotnet new webapi -n PlatformService   

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Design


dotnet add package Microsoft.EntityFrameworkCore.InMemory

dotnet add package Microsoft.EntityFrameworkCore.SqlServer


2 - Add Models and Context

Adding Models

Add DbContext

in Program.cs, 
add AddDbContext to services
and
use UseInMemoryDatabase

3 - Create PlatformRepo Interface and its implementation

4 - Seeding example data to test

5 - DTO: Data Transfer Object
    Result: Data Privacy
            Contractual Coupling

    Create ReadDTO and CreateDTO

6 - Add AutoMapper into Services

7 - Create PlatformProfiles

8 - Platformcontroller, 
    Getallplatform and getplatformbyid

    CreatePlatform

9 - Build Dockerfile

10 - 

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

COPY .  ./


# Copy everything else and build
#COPY ../engine/examples ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PlatformService.dll"]


11- docker build -t sichilam/platformservice .

12- Docker run

13 - Docker push


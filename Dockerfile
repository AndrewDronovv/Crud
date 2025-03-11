FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Crud.WebApi/Crud.WebApi.csproj", "Crud.WebApi/"]
COPY ["BusinessLogic/Crud.BusinessLogic.csproj", "Crud.BusinessLogic/"]
COPY ["Crud.DataAccess/Crud.DataAccess.csproj", "Crud.DataAccess/"]

RUN dotnet restore "Crud.WebApi/Crud.WebApi.csproj"

COPY . .
WORKDIR "/src/Crud.WebApi"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Crud.WebApi.dll"]
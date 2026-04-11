FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj from subfolder
COPY VarunPortfolioCore/VarunPortfolioCore.csproj ./VarunPortfolioCore/

WORKDIR /src/VarunPortfolioCore
RUN dotnet restore

# copy everything
COPY VarunPortfolioCore/ ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "VarunPortfolioCore.dll"]
# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#COPY Controllers/ *.cs *.json Resources/ *.csproj ./
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /result
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "ClientApp.dll"]
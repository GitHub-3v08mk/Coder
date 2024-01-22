#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# Build and Publish
COPY . ./
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet publish -c Release -o out

# Copy to Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Install curl
RUN apt-get update && \
    apt-get install -y curl && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /App
COPY --from=build /App/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Coder.dll"]

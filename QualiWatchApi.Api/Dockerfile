#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QualiWatchApi.Api/QualiWatchApi.Api.csproj", "QualiWatchApi.Api/"]
COPY ["QualiWatchApi.Contracts/QualiWatchApi.Contracts.csproj", "QualiWatchApi.Contracts/"]
COPY ["QualiWatchApi.Application/QualiWatchApi.Application.csproj", "QualiWatchApi.Application/"]
COPY ["QualiWatchApi.Domain/QualiWatchApi.Domain.csproj", "QualiWatchApi.Domain/"]
COPY ["QualiWatchApi.Infrastructure/QualiWatchApi.Infrastructure.csproj", "QualiWatchApi.Infrastructure/"]
RUN dotnet restore "./QualiWatchApi.Api/QualiWatchApi.Api.csproj"
COPY . .
WORKDIR "/src/QualiWatchApi.Api"
RUN dotnet build "./QualiWatchApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QualiWatchApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QualiWatchApi.Api.dll"]
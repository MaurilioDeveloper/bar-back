FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["src/PortalDeParceiros.Api/PortalDeParceiros.Api.csproj", "src/PortalDeParceiros.Api/"]
RUN dotnet restore "src/PortalDeParceiros.Api/PortalDeParceiros.Api.csproj"
COPY . .
WORKDIR "src/PortalDeParceiros.Api"
RUN dotnet build "PortalDeParceiros.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PortalDeParceiros.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PortalDeParceiros.Api.dll"]
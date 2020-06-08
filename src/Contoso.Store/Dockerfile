#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src

COPY ["Contoso.Store.API/Contoso.Store.API.csproj", "src/Contoso.Store.API/"]
RUN dotnet restore "src/Contoso.Store.API/Contoso.Store.API.csproj"

COPY . .

WORKDIR "/src/Contoso.Store.API"
RUN dotnet build "Contoso.Store.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contoso.Store.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contoso.Store.API.dll"]
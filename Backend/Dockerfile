# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API/PetShop.API.csproj", "API/"]
COPY ["Application/PetShop.Application.csproj", "Application/"]
COPY ["Domain/PetShop.Domain.csproj", "Domain/"]
COPY ["Infrastructure/PetShop.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "API/PetShop.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "PetShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetShop.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetShop.API.dll"]

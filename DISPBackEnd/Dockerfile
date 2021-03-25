#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DISPBackEnd/DISPBackEnd.csproj", "DISPBackEnd/"]
RUN dotnet restore "DISPBackEnd/DISPBackEnd.csproj"
COPY . .
WORKDIR "/src/DISPBackEnd"
RUN dotnet build "DISPBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DISPBackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DISPBackEnd.dll"]
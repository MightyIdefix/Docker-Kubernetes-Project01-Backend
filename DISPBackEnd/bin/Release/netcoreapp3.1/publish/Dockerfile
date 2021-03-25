FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ADD ./ /app
EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_URLS http://*:80
WORKDIR /app
ENTRYPOINT [ "dotnet", "DISPBackEnd.dll"]
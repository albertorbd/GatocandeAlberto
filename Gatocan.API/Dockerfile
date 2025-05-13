FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY Gatocan.Model/*.csproj Gatocan.Model/
COPY Gatocan.Business/*.csproj Gatocan.Business/
COPY Gatocan.Data/*.csproj Gatocan.Data/
COPY Gatocan.API/*.csproj Gatocan.API/
RUN dotnet restore Gatocan.sln

COPY . .
RUN dotnet publish Gatocan.sln -c Release -o API/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/API/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Gatocan.API.dll"]
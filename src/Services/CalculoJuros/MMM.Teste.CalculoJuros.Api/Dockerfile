#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Services/CalculoJuros/MMM.Teste.CalculoJuros.Api/MMM.Teste.CalculoJuros.Api.csproj", "Services/CalculoJuros/MMM.Teste.CalculoJuros.Api/"]
#COPY ["./Core/MMM.Test.Core/MMM.Test.Core.csproj", "Core/MMM.Teste.Core/"]
RUN dotnet restore "./Services/CalculoJuros/MMM.Teste.CalculoJuros.Api/MMM.Teste.CalculoJuros.Api.csproj"
COPY . .
WORKDIR "Services/CalculoJuros/MMM.Teste.CalculoJuros.Api"
RUN dotnet build "MMM.Teste.CalculoJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MMM.Teste.CalculoJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MMM.Teste.CalculoJuros.Api.dll"]
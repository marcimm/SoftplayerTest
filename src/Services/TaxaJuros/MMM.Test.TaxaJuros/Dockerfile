#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/TaxaJuros/MMM.Test.TaxaJuros/MMM.Test.TaxaJuros.csproj", "src/Services/TaxaJuros/MMM.Test.TaxaJuros/"]
RUN dotnet restore "src/Services/TaxaJuros/MMM.Test.TaxaJuros/MMM.Test.TaxaJuros.csproj"
COPY . .
WORKDIR "/src/src/Services/TaxaJuros/MMM.Test.TaxaJuros"
RUN dotnet build "MMM.Test.TaxaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MMM.Test.TaxaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MMM.Test.TaxaJuros.dll"]
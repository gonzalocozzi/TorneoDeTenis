FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5292

ENV ASPNETCORE_URLS=http://+:5292

USER app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TorneoDeTenis.WebApi.csproj", "./"]
RUN dotnet restore "TorneoDeTenis.WebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TorneoDeTenis.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TorneoDeTenis.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TorneoDeTenis.WebApi.dll"]

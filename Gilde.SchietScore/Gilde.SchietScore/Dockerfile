FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gilde.SchietScore.csproj", "SchietScore"]
RUN dotnet restore "Gilde.SchietScore.csproj"
COPY . .
WORKDIR "/src/SchietScore"
RUN dotnet build "Gilde.SchietScore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gilde.SchietScore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gilde.SchietScore.dll"]
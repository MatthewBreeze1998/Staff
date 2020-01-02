FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Could-System-dev-ops/Staff App.csproj", "Could-System-dev-ops/"]
RUN dotnet restore "Could-System-dev-ops/Staff App.csproj"
COPY . .
WORKDIR "/src/Could-System-dev-ops"
RUN dotnet build "Staff App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Staff App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Staff App.dll"]
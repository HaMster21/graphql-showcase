FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["graphql-showcase.csproj", ""]
RUN dotnet restore "graphql-showcase.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "graphql-showcase.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "graphql-showcase.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "graphql-showcase.dll"]
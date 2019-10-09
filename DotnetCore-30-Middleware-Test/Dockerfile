FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DotnetCore-30-Middleware-Test/DotnetCore-30-Middleware-Test.csproj", "DotnetCore-30-Middleware-Test/"]
RUN dotnet restore "DotnetCore-30-Middleware-Test/DotnetCore-30-Middleware-Test.csproj"
COPY . .
WORKDIR "/src/DotnetCore-30-Middleware-Test"
RUN dotnet build "DotnetCore-30-Middleware-Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetCore-30-Middleware-Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetCore-30-Middleware-Test.dll"]
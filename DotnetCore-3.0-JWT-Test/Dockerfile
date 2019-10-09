FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DotnetCore-3.0-JWT-Test/DotnetCore-3.0-JWT-Test.csproj", "DotnetCore-3.0-JWT-Test/"]
RUN dotnet restore "DotnetCore-3.0-JWT-Test/DotnetCore-3.0-JWT-Test.csproj"
COPY . .
WORKDIR "/src/DotnetCore-3.0-JWT-Test"
RUN dotnet build "DotnetCore-3.0-JWT-Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetCore-3.0-JWT-Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetCore-3.0-JWT-Test.dll"]
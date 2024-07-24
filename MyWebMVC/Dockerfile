FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyWebMVC/MyWebMVC.csproj", "MyWebMVC/"]
RUN dotnet restore "MyWebMVC/MyWebMVC.csproj"
COPY . .
WORKDIR "/src/MyWebMVC"
RUN dotnet build "MyWebMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyWebMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyWebMVC.dll"]
# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj", "Otus.Teaching.PromoCodeFactory.WebHost/"]
COPY ["Otus.Teaching.PromoCodeFactory.Core/Otus.Teaching.PromoCodeFactory.Core.csproj", "Otus.Teaching.PromoCodeFactory.Core/"]
COPY ["Otus.Teaching.PromoCodeFactory.DataAccess/Otus.Teaching.PromoCodeFactory.DataAccess.csproj", "Otus.Teaching.PromoCodeFactory.DataAccess/"]
COPY ["Otus.Teaching.PromoCodeFactory.Services/Otus.Teaching.PromoCodeFactory.Services.csproj", "Otus.Teaching.PromoCodeFactory.Services/"]
RUN dotnet restore "./Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj"
COPY . .
WORKDIR "/src/Otus.Teaching.PromoCodeFactory.WebHost"
RUN dotnet build "./Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Teaching.PromoCodeFactory.WebHost.dll"]
# ===== Этап 1: сборка =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем только csproj, чтобы кэшировать restore
COPY *.csproj ./
RUN dotnet restore

# Копируем всё остальное и публикуем
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# ===== Этап 2: запуск =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish ./

# Render передаёт порт через переменную PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000}
EXPOSE 10000

ENTRYPOINT ["dotnet", "wt-lab4-4mvc-talko.dll"]
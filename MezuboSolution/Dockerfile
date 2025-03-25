# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos del proyecto
COPY . . 

# Restaurar dependencias
RUN dotnet restore

# Compilar la aplicación en modo Release
RUN dotnet publish -c Release -o /out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de compilación
COPY --from=build /out .

# Exponer el puerto 80 para acceder a la API
EXPOSE 80

# Configurar el punto de entrada del contenedor
ENTRYPOINT ["dotnet", "Mezubo.Api.dll"]

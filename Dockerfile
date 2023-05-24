FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App
EXPOSE 5062

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
#ruta 
WORKDIR /App
# ENV ASPNETCORE_URLS=http://+:5062
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "API_PedroPinturas.dll"]

# Este archivo construye una imagen de Docker para una aplicación ASP.NET Core 6.0. 
# Copia los archivos de la aplicación, restaura las dependencias, compila y publica
#  la aplicación en modo de lanzamiento, y finalmente crea un contenedor que ejecuta la aplicación ASP.NET Core cuando se inicia.
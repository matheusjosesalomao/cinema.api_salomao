# Usando o SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiando apenas o .csproj e restaurando as depend�ncias
COPY *.csproj ./
RUN dotnet restore

# Copiando o restante do c�digo e publicando
COPY . .
RUN dotnet publish -c Release -o out

# Usando a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta e rodando a aplica��o
EXPOSE 5000
ENTRYPOINT ["dotnet", "Cinema.Usuario.Api.dll"]

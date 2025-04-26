# Usando o SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiando apenas o .csproj e restaurando as dependências
COPY Cinema.Bilhetes.Api/*.csproj Cinema.Bilhetes.Api/
COPY Cinema.Bilhetes.Domain/*.csproj Cinema.Bilhetes.Domain/
COPY Cinema.Bilhetes.Infra/*.csproj Cinema.Bilhetes.Infra/

# Alterar para o diretório da API principal antes de restaurar dependências
WORKDIR /app/Cinema.Bilhetes.Api
RUN dotnet restore

# Voltar para o diretório principal e copiar o restante do código
WORKDIR /app
COPY . .

# Publicar o projeto
RUN dotnet publish Cinema.Bilhetes.Api/Cinema.Bilhetes.Api.csproj -c Release -o out

# Usando a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta e rodando a aplicação
EXPOSE 5002
ENTRYPOINT ["dotnet", "Cinema.Bilhetes.Api.dll"]

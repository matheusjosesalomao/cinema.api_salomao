# Usando o SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar arquivos .csproj para os respectivos diret�rios
COPY Cinema.Filmes.Api/*.csproj Cinema.Filmes.Api/
COPY Cinema.Filmes.Application/*.csproj Cinema.Filmes.Application/
COPY Cinema.Filmes.TMDBAdapter/*.csproj Cinema.Filmes.TMDBAdapter/

# Alterar para o diret�rio da API principal antes de restaurar depend�ncias
WORKDIR /app/Cinema.Filmes.Api
RUN dotnet restore

# Voltar para o diret�rio principal e copiar o restante do c�digo
WORKDIR /app
COPY . .

# Publicar o projeto
RUN dotnet publish Cinema.Filmes.Api/Cinema.Filmes.Api.csproj -c Release -o out

# Usando a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta e rodando a aplica��o
EXPOSE 5001
ENTRYPOINT ["dotnet", "Cinema.Filmes.Api.dll"]

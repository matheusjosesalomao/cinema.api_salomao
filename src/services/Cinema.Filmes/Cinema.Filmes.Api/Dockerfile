# Usando o SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiando apenas o .csproj e restaurando as dependências
COPY *.csproj ./
COPY ../Cinema.Filmes.Application/*.csproj ../Cinema.Filmes.Application/
COPY ../Cinema.Filmes.TMDBAdapter/*.csproj ../Cinema.Filmes.TMDBAdapter/
RUN dotnet restore

# Copiando o restante do código e publicando
COPY . .
RUN dotnet publish -c Release -o out

# Usando a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta e rodando a aplicação
EXPOSE 5001
ENTRYPOINT ["dotnet", "Cinema.Filmes.Api.dll"]

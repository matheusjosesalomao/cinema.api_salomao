# Usando o SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiando apenas o .csproj e restaurando as dependências
COPY *.csproj ./
COPY ../Cinema.Bilhetes.Domain/*.csproj ../Cinema.Bilhetes.Domain/
COPY ../Cinema.Bilhetes.Infra/*.csproj ../Cinema.Filmes.Infra/
RUN dotnet restore

# Copiando o restante do código e publicando
COPY . .
RUN dotnet publish -c Release -o out

# Usando a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta e rodando a aplicação
EXPOSE 5002
ENTRYPOINT ["dotnet", "Cinema.Bilhetes.Api.dll"]

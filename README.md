# Cinema.API

Este repositório contém uma aplicação distribuída que simula um sistema para gestão de cinemas. A aplicação está dividida em múltiplos serviços que seguem o padrão **Arquitetura em Microsserviços**. Cada serviço é responsável por uma funcionalidade específica, como gerenciamento de usuários, filmes e bilhetes.

## Serviços Implementados

Abaixo está a descrição dos principais serviços implementados no projeto:

### 1. **Cinema.Usuarios**
- **Descrição**: Serviço responsável pela gestão de usuários do sistema, incluindo cadastro, autenticação e gerenciamento de dados pessoais.
- **Tecnologias**: ASP.NET Core, MongoDB
- **Endpoints principais**:
  - `POST /api/identidade/nova-contra`: Cadastra um novo usuário.
  - `POST /api/identidade/login`: Realiza o login e retorna um JWT.
- **Banco de Dados**: MongoDB
- **Porta padrão**:
  - Visual Studio: `https://localhost:7240`
  - Docker: `http://localhost:5000`

---

### 2. **Cinema.Filmes**
- **Descrição**: Serviço responsável pela gestão de filmes, obtém informações de filmes com a integração com a API externas, do TMDB (The Movie Database).
- **Tecnologias**: ASP.NET Core
- **Endpoints principais**:
  - `GET /filmes`: Lista todos os filmes com filtro de genero e lançamento.
  - `GET /filmes/{id}`: Obtém um filme pelo Id.
- **Porta padrão**:
  - Visual Studio: `https://localhost:7218`
  - Docker: `http://localhost:5001`

---

### 3. **Cinema.Bilhetes**
- **Descrição**: Serviço responsável pela gestão de bilhetes, permitindo a reserva e compra de ingressos para sessões de filmes.
- **Tecnologias**: ASP.NET Core, SQL Server
- **Endpoints principais**:
  - `POST /bilhetes/check-in`: Cadastra um novo bilhete, com id de filme - Rota precisa de autenticação.
  - `GET /bilhetes`: Lista bilhetes do usuário autenticado.
- **Banco de Dados**: SQL Server
- **Porta padrão**:
  - Visual Studio: `http://localhost:7104`
  - Docker: `http://localhost:5002`

---

## Arquitetura Utilizada

O projeto segue os princípios da **Arquitetura em Microsserviços**:
- **Independência de serviços**: Cada serviço opera de forma independente, com seu próprio banco de dados.
- **Comunicação**: A comunicação entre serviços pode ser feita de forma síncrona (HTTP) ou assíncrona (mensageria) dependendo da necessidade.
- **Banco de dados distribuído**: Cada serviço possui seu banco de dados próprio, garantindo a independência e escalabilidade.
- **APIs RESTful**: Cada serviço expõe uma API RESTful que segue os princípios de boas práticas e padronização.

---

## Como Rodar a Aplicação

### 1. **Via Visual Studio**
1. Abra a solução no Visual Studio.
2. Configure os projetos como múltiplos projetos de inicialização:
   - `Cinema.Usuarios.Api`
   - `Cinema.Filmes.Api`
   - `Cinema.Bilhetes.Api`
3. Execute a aplicação pressionando `F5`.
4. Acesse os serviços nas URLs configuradas:
   - `http://localhost:7240` (Cinema.Usuarios)
   - `http://localhost:7218` (Cinema.Filmes)
   - `http://localhost:7104` (Cinema.Bilhetes)

---

### 2. **Via Docker**
1. Certifique-se de que o Docker e o Docker Compose estão instalados.
2. No terminal, navegue até a pasta `docker/`.
3. Execute os comandos:
   ```bash
   docker-compose build
   docker-compose up
   ```
4. Acesse os serviços nas URLs configuradas:
   - `http://localhost:5000` (Cinema.Usuarios)
   - `http://localhost:5001` (Cinema.Filmes)
   - `http://localhost:5002` (Cinema.Bilhetes)

---

## Banco de Dados

### MongoDB
- Serviço utilizado pelo sistema de usuários.
- Porta: `27017`
- Credenciais:
  - **Usuário**: `admin`
  - **Senha**: `password`

### SQL Server
- Serviço utilizado pelos sistemas de filmes e bilhetes.
- Porta: `1433`
- Credenciais:
  - **Usuário**: `sa`
  - **Senha**: `123@Passw0rd`

---

## Ferramentas e Tecnologias Utilizadas
- **ASP.NET Core**: Framework para desenvolvimento de APIs RESTful.
- **Docker/Docker Compose**: Para containerização e orquestração de serviços.
- **MongoDB**: Banco de dados NoSQL para o serviço de usuários.
- **SQL Server**: Banco de dados relacional para os serviços de filmes e bilhetes.
- **Swagger**: Documentação interativa para os endpoints das APIs.

---
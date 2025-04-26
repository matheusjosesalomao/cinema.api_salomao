# Cinema.API

Este reposit�rio cont�m uma aplica��o distribu�da que simula um sistema para gest�o de cinemas. A aplica��o est� dividida em m�ltiplos servi�os que seguem o padr�o **Arquitetura em Microsservi�os**. Cada servi�o � respons�vel por uma funcionalidade espec�fica, como gerenciamento de usu�rios, filmes e bilhetes.

## Servi�os Implementados

Abaixo est� a descri��o dos principais servi�os implementados no projeto:

### 1. **Cinema.Usuarios**
- **Descri��o**: Servi�o respons�vel pela gest�o de usu�rios do sistema, incluindo cadastro, autentica��o e gerenciamento de dados pessoais.
- **Tecnologias**: ASP.NET Core, MongoDB
- **Endpoints principais**:
  - `POST /api/identidade/nova-contra`: Cadastra um novo usu�rio.
  - `POST /api/identidade/login`: Realiza o login e retorna um JWT.
- **Banco de Dados**: MongoDB
- **Porta padr�o**:
  - Visual Studio: `https://localhost:7240`
  - Docker: `http://localhost:5000`

---

### 2. **Cinema.Filmes**
- **Descri��o**: Servi�o respons�vel pela gest�o de filmes, obt�m informa��es de filmes com a integra��o com a API externas, do TMDB (The Movie Database).
- **Tecnologias**: ASP.NET Core
- **Endpoints principais**:
  - `GET /filmes`: Lista todos os filmes com filtro de genero e lan�amento.
  - `GET /filmes/{id}`: Obt�m um filme pelo Id.
- **Porta padr�o**:
  - Visual Studio: `https://localhost:7218`
  - Docker: `http://localhost:5001`

---

### 3. **Cinema.Bilhetes**
- **Descri��o**: Servi�o respons�vel pela gest�o de bilhetes, permitindo a reserva e compra de ingressos para sess�es de filmes.
- **Tecnologias**: ASP.NET Core, SQL Server
- **Endpoints principais**:
  - `POST /bilhetes/check-in`: Cadastra um novo bilhete, com id de filme - Rota precisa de autentica��o.
  - `GET /bilhetes`: Lista bilhetes do usu�rio autenticado.
- **Banco de Dados**: SQL Server
- **Porta padr�o**:
  - Visual Studio: `http://localhost:7104`
  - Docker: `http://localhost:5002`

---

## Arquitetura Utilizada

O projeto segue os princ�pios da **Arquitetura em Microsservi�os**:
- **Independ�ncia de servi�os**: Cada servi�o opera de forma independente, com seu pr�prio banco de dados.
- **Comunica��o**: A comunica��o entre servi�os pode ser feita de forma s�ncrona (HTTP) ou ass�ncrona (mensageria) dependendo da necessidade.
- **Banco de dados distribu�do**: Cada servi�o possui seu banco de dados pr�prio, garantindo a independ�ncia e escalabilidade.
- **APIs RESTful**: Cada servi�o exp�e uma API RESTful que segue os princ�pios de boas pr�ticas e padroniza��o.

---

## Como Rodar a Aplica��o

### 1. **Via Visual Studio**
1. Abra a solu��o no Visual Studio.
2. Configure os projetos como m�ltiplos projetos de inicializa��o:
   - `Cinema.Usuarios.Api`
   - `Cinema.Filmes.Api`
   - `Cinema.Bilhetes.Api`
3. Execute a aplica��o pressionando `F5`.
4. Acesse os servi�os nas URLs configuradas:
   - `http://localhost:7240` (Cinema.Usuarios)
   - `http://localhost:7218` (Cinema.Filmes)
   - `http://localhost:7104` (Cinema.Bilhetes)

---

### 2. **Via Docker**
1. Certifique-se de que o Docker e o Docker Compose est�o instalados.
2. No terminal, navegue at� a pasta `docker/`.
3. Execute os comandos:
   ```bash
   docker-compose build
   docker-compose up
   ```
4. Acesse os servi�os nas URLs configuradas:
   - `http://localhost:5000` (Cinema.Usuarios)
   - `http://localhost:5001` (Cinema.Filmes)
   - `http://localhost:5002` (Cinema.Bilhetes)

---

## Banco de Dados

### MongoDB
- Servi�o utilizado pelo sistema de usu�rios.
- Porta: `27017`
- Credenciais:
  - **Usu�rio**: `admin`
  - **Senha**: `password`

### SQL Server
- Servi�o utilizado pelos sistemas de filmes e bilhetes.
- Porta: `1433`
- Credenciais:
  - **Usu�rio**: `sa`
  - **Senha**: `123@Passw0rd`

---

## Ferramentas e Tecnologias Utilizadas
- **ASP.NET Core**: Framework para desenvolvimento de APIs RESTful.
- **Docker/Docker Compose**: Para containeriza��o e orquestra��o de servi�os.
- **MongoDB**: Banco de dados NoSQL para o servi�o de usu�rios.
- **SQL Server**: Banco de dados relacional para os servi�os de filmes e bilhetes.
- **Swagger**: Documenta��o interativa para os endpoints das APIs.

---
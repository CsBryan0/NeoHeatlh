# NoeHealth

Uma aplicação web criada com NET 6 SDK, voltada para área da saúde.

## Requisitos

- .NET 6 SDK
- MySQL 

## Configuração

### Banco de Dados

1. Certifique-se de ter um servidor MySQL em execução.
2. Crie um banco de dados e atualize a string de conexão no arquivo `appsettings.json`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HospitalDB;Uid=seu_usuario;Pwd=sua_senha;"
  }
}
```
### Execução

1.  Clone este repositório.
2.  Navegue até o diretório do projeto.
3.  Execute o projeto utilizando o comando:

```bash
	dotnet run
```
Acesse a API localmente em `http://localhost:{porta}`.

### Swagger
O projeto foi todo documentado utilizando o Swagger, lá é possível encontrar todas as rotas possiveis e testá-las.

 Acesse a documentação em `https://localhost:{porta}/swagger/index.html`.

## Funcionalidades

-  	 CRUD para médicos, pacientes e consultas.

## Processo Criativo
### Escolha da Versão do SDK e do Banco de Dados
Antes de começar a realmenter codar o projeto escolhi qual versão do framework e do banco de dados iria usar, inicialmente optei por usar o Net SDK 8, que é a versão mais recente, porém tive alguns problemas de compatibilidade com os pacotes NuGet usados. E o banco de dados inicial foi o SQL Server, mas também enfrentei dificuldades na hora de realizar as migrações e a atualização das tabelas no banco de dados. Como já tenho mais experiência com o MySQL acabei utilizando ele e o NET SKD 6, sinto que me ajudou muito por serem tecnologias que tenho conhecimento e já utilizei em projeto pessoais.

### Rota de códigos
Inicie meu código pelos modelos de banco de dados, tenho o costume de sempre começar um projeto por isso, assim consigo visualizar melhor o que estou fazendo e quias métodos irei precisar implementar no projeto.
Logo em seguida criei o contexto do banco de dados e realizei a primeira migração, criando assim as tabelas.
Com as tabelas criadas e o banco de dados conectados, começei a criar as operações CRUD de todos os modelos (paciente, médico e consultas). Fiz sem muitas dificuldades  e até que rápido.

### Dificuldades
Infelizmente não consegui realizar tudo que foi pedido no projeto, por não ter um conhecimento mais aprofundado no framework e na linguagem acabei deixando 3 dos tópicos que foram pedidos para trás (Autenticação e autorização, Testes de unidade e TDD, Consulta com o Dapper). Optei por retirar essas etapas do código pois estavam mal escritas e muito confusas, sinto que isso irei poluir e dificultar na integração do código.

### Considerações finais
Foi um projeto bem interessante de realizar, aprendi bastante coisa e puder me apronfundar em outras que já sabia, fico feliz com a oportunidade e com a entrega, sinto que fiz o meu melhor e espero que agrade você, mesmo com o código não cumprindo todos os requisitos!

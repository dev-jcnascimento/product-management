# COMO RODAR O PROJETO
## SOBRE O PROJETO
Trata-se de uma API para Cadastro de Produtos e Gestão de Estoque desenvolvida em .net 6 Core, utilizando: Entity Framework Core, Sql Server, JWT Bearer.

A API foi elaborada tendo como objetivo, aplicar conceitos e princípios: REST, DRY e SOLID.

Ao rodar pela primeira vez a aplicação e o banco de dados estiver vazio, ela vai realizar uma persistência de dados inicial, para visualização e testes.

## BANCO DE DADOS
Foi usado o banco de dados SQL Server. Antes de rodar o projeto, é necessário executar o comando:

Primeiro, altere a string de conexão com o banco de dados localizada em .\ProductManagement.API\appsettings.json

Segundo, deve ser feito o build do projeto. 
<br>
Abra o cmd (prompt de comando) e digite:
>dotnet build

Agora, execute o update do banco de dados:
>dotnet ef database update --project ./ProductManagement.API
>
Depois, execute o comando para rodar o projeto:
>dotnet run --project ./ProductManagement.API

Para ter acesso aos endpoints criados, acesse no navegador:
>https://localhost:7238/Swagger

Para ter acesso aos endpoints criados utilizando o Postman, utilize o link para importar:
>https://www.getpostman.com/collections/c61bec482dfeec66c68c

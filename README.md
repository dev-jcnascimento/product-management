# COMO RODAR O PROJETO

## BANCO DE DADOS
Foi usado o banco de dados SQL Server. Antes de rodar o projeto, é necessário executar o comando:

Primeiro, altere a string de conexão com o banco de dados localizada em ...\ProductManagement\ProductManagement.API\appsettings.json

Segundo,deve ser feito o build do projeto. <br>
Abra o cmd (prompt de comando) e digite:
...\ProductManagement>dotnet build
<br>
Depois de compilado, entre na pasta usando "cd ProductManagement.API", execute o update do banco de dados.

...\ProductManagement.API>dotnet ef database update

Depois, execute o comando para rodar o projeto:
  >dotnet run --project ./ProductManagement.API

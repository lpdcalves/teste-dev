# Web App feito com uma API REST C# .NET 6 e AngularJS 14

Web App para cadastro de clientes feito com .NET 6 e AngularJS, como parte de um processo avaliativo para desenvolvedores .NET C#.

A aplicação web permite inserir, alterar, excluir e filtrar clientes.

## Iniciando o Backend
Para rodar o serviço .NET com a API REST basta abrir a solução TesteDev.sln na pasta TesteDevBackend com o VisualStudio 2022 e executar o projeto. A API será iniciada sem interface gráfica, mas seus endpoints podem ser visualizados através do endereço [https://localhost:7145/swagger/index.html](https://localhost:7145/swagger/index.html).

## Iniciando o Frontend
Para rodar o serviço do frontend feito com Angular 14 basta ter o Node Js instalado, ter o Angular 14 instalado, abrir o seu terminal na pasta TesteDevFrontend e executar o seguinte comando.

```console
ng serve -o
```
## Configurando o banco de dados

Para replicar o banco de dados utilizado nessa aplicação, basta rodar os comandos no arquivo [SQL-COMMANDS.txt](https://github.com/lpdcalves/teste-dev/blob/master/SQL-COMMANDS.txt) em um gerenciador de banco de dados SQL, como o SQL SERVER.

<img src="/RepoImgs/Exemplo.png" width="800">

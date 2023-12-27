Siga os passos para rodar a aplicação. 
Tanto Front End Quanto Back foram desenvolvidos no Visual Studio 2022 e estão na 
mesma solution, para facilitar no momento de roda-los.

Pre-requisito
______________________________________________________________

Instalar Dotnet EF versao 7.0.12

1 - Abrir menu View, Other Window, click em Package Manager Console

dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.12
dotnet tool install --global dotnet-ef --version 7.0.12

2 - Ter instalado o SqlServer com acesso a localhost (caso a instância do sqlserver localhost
tenha outro nome, devera ser alterado nas connections strings, danto do RaizenDBContext.cs quando para o 
appsettings.development do camada de API)


Executar Migrations
______________________________________________________________

1 - Abrir menu View, Other Window, click em Package Manager Console
2 - Dar o comando "dir" e logo apos entrar na camada da Migration com o comando cd RaizenUserRegister.Infra.Data
3 - No console que abrir escolher o Default Project como RaizenUserRegister.Infra.Data no combobox
4 - Executar o comando
	dotnet ef database update (Este comando irá criar as duas entidades necessárias no sql server)


Executando Projeto para teste
______________________________________________________________

1 - Ambos projetam devem rodar juntos, tanto a camada RaizenUserRegister.API e RaizenUserRegister.Presentation

2 - Deve estar instalado no Visual Studio Installer o pacote "Desenvolvimento em Node.js"

3 - Ainda com a ferramenta Visual Studio Installer aberta verificar se os pacotes abaixo estao instalados
     - Na sessao Asp.NET e desenvolvimento WEB - "Modelo de projetos e item do .NET Framework" 
     - Na sessao Asp.NET e desenvolvimento WEB - "Modelo de projetos adicionais (versoes anteriores) 

4 - Abrir a solucao no Visual Studio 2022, apos feito as intalacoes dos pacotes mencionados acima.

5 - Clicar bom o botao direito em cima da camada "Presentation" e abrir um terminal e digitar o command "npm install"
    para instalar os packages necessarios do angular.

6 - Clicar com o botao direito do mouse na solution e clicar em Propriedades

7 - Selecionar "Varios projetos de instalacao"

8 - Escolher RaizenUserRegister.API = Iniciar  e  RaizenUserRegister.Presentation = Iniciar

9 - Clicar Ok

10 - Rodar Aplicacao

Ambos os projetos irão rodar em paralelo, verificar se a Api rodara na porta https://localhost:44348/,
caso na maquina aonde sera feito o teste essa porta estiver ocupada devera alterar no arquivo
Environment.ts do front end a nova porta da api. 


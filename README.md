## Objetivo
Desenvolver uma API em C# com .NET Core que simule algumas funcionalidades de um banco digital.
Nesta simulação considere que não há necessidade de autenticação.

## Desafio
Você deverá garantir que o usuário conseguirá realizar uma movimentação de sua conta corrente para quitar uma dívida.

## Cenários

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor válido<br>
ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo<br>
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor maior do que o meu saldo<br>
ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `depositar` informando o número da conta e um valor válido<br>
ENTÃO a mutation atualizará o saldo da conta no banco de dados<br>
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API <br>
QUANDO eu chamar a query `saldo` informando o número da conta<br>
ENTÃO a query retornará o saldo atualizado.

## Execução do Projeto
Restauração dos pacotes

```sh
dotnet restore
```

Criação do banco de dados
- Utilizado Entity Framework

Criação do banco pelo .NET CLI

```sh
dotnet ef database update
```

Para criação do banco pelo Visual Studio, abrir o Package Manage Console e digitar:
```sh
Update-Database
```
Para rodar o projeto pelo .NET CLI
```sh
dotnet run
```
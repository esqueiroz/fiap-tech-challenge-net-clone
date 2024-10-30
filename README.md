# FIAP Tech Challenge

## Tema

O Tech Challenge desta fase será desenvolver um aplicativo utilizando a plataforma .NET 8 para cadastro de contatos regionais, considerando a persistência de dados e a qualidade do software.

## Tecnologias Utilizadas
- .NET Core 8.0
- BD Postgres
- FluentValidation
- EF Core
- XUnit

## Configuração do Banco de dados

Para criação e configuração dos bancos de dados devem ser executados comandos abaixo. 

```
docker pull postgres:latest
```
```
docker run --name db-local -e POSTGRES_PASSWORD=102030 -d -p 5432:5432 postgres
```

PS.: É necessário que máquina possua Docker instalado

## Execução de migration do Banco de dados

Para criação e atualização do migration no banco de dados da aplicação devem ser seguidos os comandos abaixo.

```
Update-Database -Project TechChallenge.Infrastructure -StartupProject TechChallenge.Infrastructure -Connection "Host=localhost;Port=5432;Database=TechChallenge;User ID=postgres;Password=102030;Pooling=true;Connection Lifetime=0;"
```

# Estudo de Identity com ASP.NET Core Web API

Este repositório é dedicado ao estudo e implementação do ASP.NET Core Identity em uma API Web com ASP.NET Core. O objetivo é entender e aplicar conceitos de autenticação, autorização e gerenciamento de usuários usando o Identity em uma API RESTful.

## Tecnologias Utilizadas

- **ASP.NET Core** - Framework para criação da API Web.
- **ASP.NET Core Identity** - Sistema de autenticação e gerenciamento de usuários.
- **Entity Framework Core** - ORM para interagir com o banco de dados.
- **JWT (JSON Web Tokens)** - Para autenticação baseada em token.
- **AutoMapper** - Para o mapeamento das entidades e DTOs.
- **Swagger** - Para documentação da AP.

## Funcionalidades Implementadas

- **Cadastro de Usuário**: Implementação de um endpoint para registrar novos usuários.
- **Login de Usuário**: Endpoint para autenticação e emissão de tokens JWT.
- **Autenticação e Autorização**: Proteção de endpoints com autenticação baseada em JWT.
- **Cadastro de Roles (Funções)**: Criação de funções personalizadas para controle de permissões.
- **Swagger UI**: Interface para explorar a API de maneira interativa.

## Estrutura do Projeto

O projeto é dividido em várias pastas principais:

- **Controllers**: Contém os controladores da API, incluindo os endpoints para login, registro de usuário e outros.
- **Models**: Contém a model User, usado para representar um usário.
- **DTO**: Contém os Data Transfer Object usados para as operações de registro, login, e resposta de autenticação
- **Data**: Contém o Contexto do Banco de dados (EntityFrameWork DbContext).
- **Migrations**: Contém as migrations para que será usado para criar a base de dado e as tabelas.
- **MappingsProfile** : Os perfis de mapeamento das entidade de Dados.

## Configuração do Ambiente

### Requisitos

- **.NET 6 ou superior**: Para executar o projeto.
- **SQL Server** (ou outro banco de dados, caso configurado): Para armazenar os dados de autenticação.

### Passos para rodar o projeto

1. Clone o repositório:

   ```bash
      git clone https://github.com/salakiaku/AspNetCoreIdentityWebApi.git

2. Entre na pasta do projeto:
   ```bash
      cd AspNetCoreIdentityWebApi
   
3. Restaure as dependências do projeto:
   ```bash
       dotnet restore

4. Realize Migrations do Banco de Dados:
   ```bash
      dotnet ef database update
   
5. Execute o projeto:
```bash
   dotnet run

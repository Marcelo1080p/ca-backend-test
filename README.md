# Billing API

API para gerenciamento de faturamento (billing), clientes e produtos, construída com foco em boas práticas de desenvolvimento, arquitetura limpa e testes automatizados.

---

## Descrição do Projeto

Este projeto é uma API RESTful desenvolvida para gerenciar clientes, produtos e faturas, utilizando uma arquitetura em camadas baseada no **Domain-Driven Design (DDD)**. Foi desenvolvido seguindo os princípios do **Test-Driven Development (TDD)**, garantindo maior qualidade e confiabilidade no código.

---

## Arquitetura e Boas Práticas

- **Arquitetura em Camadas:** Separação clara entre as camadas de aplicação, domínio e infraestrutura, promovendo baixo acoplamento e alta coesão.
- **Domain-Driven Design (DDD):** Modelagem do domínio focada em entidades, repositórios e serviços, respeitando as regras de negócio.
- **Test-Driven Development (TDD):** Desenvolvimento guiado por testes automatizados usando **xUnit**, garantindo cobertura e qualidade do código.
- **Injeção de Dependências:** Uso do padrão para desacoplar as dependências e facilitar testes e manutenção.
- **Tratamento centralizado de erros:** Para melhorar a consistência das respostas e facilitar o diagnóstico.
- **Uso de DTOs:** Para separar os modelos de domínio dos modelos usados nas requisições e respostas da API.
- **Documentação automática:** Utilização do Swagger para documentação e teste dos endpoints.

---

## Tecnologias Utilizadas

- **.NET 8** — Plataforma principal para desenvolvimento da API.
- **Entity Framework Core 8** — ORM para acesso ao banco de dados SQL Server.
- **SQL Server** — Banco de dados relacional para persistência dos dados.
- **Swagger / Swashbuckle** — Geração automática da documentação e interface para testar a API.
- **xUnit** — Framework de testes unitários para garantir qualidade do código.
- **Visual Studio / VS Code** — IDEs recomendadas para desenvolvimento.

---

## Endpoints

Todos os endpoints disponíveis podem ser acessados e testados via Swagger UI na URL base do projeto


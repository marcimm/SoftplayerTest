# SoftplayerTest - App demostração

## Descrição

Aplicação Asp.Net Core 5 com C#, WebApi, SQL Server, Identity e DOCKER.

## Tecnologias e recursos
Utilização de SOLID e Clean Code além de inúmeras tecnologias e recursos proporcionando solução robusta e funcional:

* Documentação da API com Swagger
* Versionamento da API
* Otimização da resposta da API com Gzip Compression
* Health Checks com Xabaril UI
* Autenticação com JWT
* Api de gerenciamento de usuários e acessos com Identity e EF Core
* Customização de autorização com CLAIMS
* Serilog
* Notification Patern
* View Model Pattern
* Retry Pattern e Circuit Breaker com Polly
* FluentValitation
* AutoMapper
* Projetos de Testes (Unit Tests, Integration Tests, Functional Tests)
* xUnit - FluentAssertions - Moq e AutoMoq
* Docker Compose (Criação das imagens, containers, importação do Banco de dados)
* Projeto Postman para validação e testes
 
**Diagrama:** 

![Alt text](docs/img/drawIO_diagram.PNG?raw=true "Diagrama")

**Resumo:** 

- **api-01-taxa-juros**: api com um único endpoint que retorna a taxa de juros;
- **api-02-calculo-juros**: api com um endpoint para calculo de juros (consultando a taxa de - juros da api-01) e outro endpoint que retorna a Url GitHub do projeto;
- **api-identity**: Api para gerenciamento de usuários e acessos com o Microsoft Identity. Faz cadastro de usuários e fornece o token de acesso para as demais Apis;
- **sql-server**: banco de dados com Microsoft SQL Server para utilização do Identity;


## Instalação no Docker Desktop
```
- Abrir o diretório da solution scr/docker no console
- Executar o comando "docker-compose up --build" 
- Aguardar o provisionamento dos containers
```

Todos os containers estão configurados com portas de acesso externo:
- http://localhost:5001/index.html - api-identity
- http://localhost:5101/index.html - api-01-taxa-juros
- http://localhost:5201/index.html - api-02-calculo-juros
- http://localhost:5201/healthchecks-ui#/healthchecks
- sql-server: **localhost, 1430** (usuário: "sa", senha: "My_PassW0rd")

### Database com usuário de ADM para testes:
-- Ao subir o container sql-server, será criada automaticamente utilizando p arquivo: /sql/database-generator.sql
-- No startup da api-identity também será criada a database com ADM caso ainda não exista:
"email": "adm@adm.com"
"senha": "Adm@12345"
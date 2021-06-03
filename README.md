# SoftplayerTest





# Descrição

Aplicação Asp.Net Core 5

## Instalação no Docker

```
Abrir diretório scr/docker no console e executar o comando "docker-compose up --build" para montar o ambiente em Docker.
```

## Arquitetura e conceitos
```
SOLID
Clean Code
Notification Pattern

- Health Checks Endpoints:
/healthz
/healthchecks-ui

- Retry Pattern com Polly
Trata falhas transitórias ao tentar se conectar a um serviço ou recurso de rede e repete de forma transparente uma operação com falha. Isso pode melhorar a estabilidade do aplicativo.



Unit Tests
```

## Technologias e recursos

* .NET Core 5.0 e C#
* Documentação da API com Swagger
* Versionamento da API
* Otimização da resposta da API com Gzip Compression and Cache
* Logging com KissLog provider
* FluentValitation
* xUnit


# API de Controle de Validade

## Uma api capaz de fazer o crud de um produto , alertar o usario quando um produto está proximo de vencer e pode extrair texto e validades de uma imagem.

Bem-vindo à API de Controle de Validade, uma aplicação desenvolvida em .NET Core integrada ao SQL Server. Esta API tem como propósito principal auxiliar as equipes da cozinha da Faculdade Salvador Arena, proporcionando um controle mais rigoroso sobre a validade dos produtos utilizados.

## Funcionalidades

- Notificações quando um produto está perto de vencer.
- Capacidade de retirar texto ou validade de uma imagem.

### Extração de Texto de Imagem

A API oferece a capacidade de extrair texto de imagens, simplificando a entrada de dados relacionados aos produtos na cozinha. Ao utilizar esse recurso, as equipes podem agilizar a atualização do status de validade dos itens, melhorando a eficiência operacional.

#### Exemplo de Requisição

```http
POST /Image/texto
```

```json 
{
    "base64": "IyBBUE...hLCB"
}
```

#### Resposta

```json
{
    [
        {
            "id": 1,
            "data" : "resposta" 
        }
    ]
}
```

### Alerta de Produtos Próximos ao Vencimento

A API disponibiliza um endpoint específico para fornecer alertas sobre produtos que estão prestes a vencer. Essa funcionalidade é essencial para garantir que a equipe da cozinha seja notificada antecipadamente, permitindo a tomada de medidas preventivas, como a remoção de produtos ou usar-los antes de vencer.

#### Requisição dos Alertas

```http
POST /Produto/validade
```

```json
{
    "ultimaAtulizacao" : "2023-11-29T10:15:30Z"
}
```

#### Resposta dos Alertas

```json
{
    [
        {
            "id": "dcf8b5ee-6cbf-4d48-9e24-0c8f3e6b3b88",
            "nome": "Abacate",
            "lote": "12sda",
            "validade": "2023-11-29T10:15:30Z"
        }
    ]
}

```

### Configuração

Certifique-se de configurar corretamente a conexão com o banco de dados SQL Server no arquivo `appsettings.json`. Insira as informações apropriadas para garantir o correto funcionamento da aplicação.

```json 
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaCadeiaDeConexaoSQLServer"
  },
  // Outras configurações...
}
```

### Instalação e Execução

- 1. Clone o repositorio: git clone <https://github.com/BotAldaris/QualiWatchApI.git>
- 2. Navegue até o diretório do projeto: cd QualiWatchApI
- 3. Execute a aplicação: dotnet run

Certifique-se de ter o SDK do .NET Core 8 instalado em sua máquina.

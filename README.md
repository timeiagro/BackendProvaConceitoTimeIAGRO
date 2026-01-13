# Catálogo de Livros - API REST

API RESTful desenvolvida em .NET Core para gerenciamento de catálogo de livros, permitindo busca, ordenação e cálculo de frete.

## 📋 Sobre o Projeto

Este projeto é a solução da [prova conceito do time IAGRO](https://github.com/timeiagro/BackendProvaConceitoTimeIAGRO)   

A API permite:

- ✅ Buscar livros em um catálogo JSON
- ✅ Filtrar livros por especificações (autor, nome, gênero, etc.)
- ✅ Ordenar resultados por preço (ascendente e descendente)
- ✅ Calcular valor do frete (20% do valor do livro)

## 🏗️ Arquitetura do Projeto

O projeto foi estruturado em **3 camadas** seguindo princípios SOLID e boas práticas de desenvolvimento:

```
BackendProvaConceitoTimeIAGRO_PedroHenriqueJanini/
├── Hamurabi.Api/          # Camada de apresentação (Controllers e API)
├── Hamurabi.Core/         # Camada de negócio (Models, Interfaces, Services)
├── Hamurabi.Tests/        # Testes unitários
└── books.json             # Base de dados (arquivo JSON)
```

### Hamurabi.Api (Camada de API)
- **Controllers**: Endpoints REST
- **Program.cs**: Configuração da aplicação
  
### Hamurabi.Core (Núcleo da Aplicação)
- **Models**: Classes que representam as entidades (Book, BookSpecifications)
- **Interfaces**: Contratos para Repository e Service
- **Services**: Lógica de negócio (busca, ordenação)
- **Repositories**: Acesso aos dados (leitura do JSON)

### Hamurabi.Tests
- Testes unitários utilizando xUnit

## 🔧 Tecnologias Utilizadas

- **.NET 10.0** (compatível com .NET Core 3.1+)
- **ASP.NET Core Web API**
- **System.Text.Json** (para manipulação de JSON)
- **xUnit** (para testes unitários)

## 📦 Pré-requisitos

Para executar este projeto, você precisa ter instalado:

- [.NET SDK 6.0 ou superior](https://dotnet.microsoft.com/download)

## 🚀 Como Executar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/BackendProvaConceitoTimeIAGRO_PedroHenriqueJanini.git
cd BackendProvaConceitoTimeIAGRO_PedroHenriqueJanini
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Compile o projeto

```bash
dotnet build
```

### 4. Execute a API

```bash
cd Hamurabi.Api
dotnet run
```

A API estará disponível. Verifique no terminal a URL exibida (geralmente `http://localhost:5161/`).

### 5. Acesse a documentação Swagger

Abra o navegador e acesse a URL `/index.html` junto do localhost exibido no terminal, por exemplo:
```
http://localhost:5161/index.html
```

## 🧪 Como Executar os Testes

Para executar todos os testes unitários, retorne para a raíz do projeto e entre na camada de testes:

```bash
cd ..
cd Hamurabi.Tests
dotnet test
```

Para executar com detalhes:

```bash
dotnet test --logger "console;verbosity=detailed"
```

## 📚 Endpoints da API

| Método | Endpoint | Descrição | Exemplo |
|--------|----------|-----------|---------|
| GET | `/api/books` | Retorna todos os livros | `GET /api/books` |
| GET | `/api/books/search?term={termo}` | Busca livros por termo (nome, autor, gênero, etc) | `GET /api/books/search?term=Jules` |
| GET | `/api/books/ordered?ascending={true/false}` | Retorna livros ordenados por preço | `GET /api/books/ordered?ascending=false` |
| GET | `/api/books/{id}/shipping` | Calcula frete de um livro específico | `GET /api/books/1/shipping` |

### Exemplos de Uso

**1. Buscar todos os livros:**
```bash
curl -X GET "http://localhost:5161/api/books"
```

**2. Buscar livros por autor (Jules Verne):**
```bash
curl -X GET "http://localhost:5161/api/books/search?term=Jules"
```

**3. Ordenar livros por preço (descendente):**
```bash
curl -X GET "http://localhost:5161/api/books/ordered?ascending=false"
```

**4. Calcular frete do livro ID 1:**
```bash
curl -X GET "http://localhost:5161/api/books/1/shipping"
```
**Resposta:**
```json
{
  "bookId": 1,
  "bookName": "Journey to the Center of the Earth",
  "price": 10.00,
  "shipping": 2.00,
  "totalPrice": 12.00
}
```

## 🎯 Padrões de Projeto Utilizados

- **Repository Pattern**: Abstração da camada de acesso a dados
- **Dependency Injection**: Inversão de dependência e baixo acoplamento
- **Service Layer**: Separação da lógica de negócio

- **SOLID Principles**: Código organizado e manutenível

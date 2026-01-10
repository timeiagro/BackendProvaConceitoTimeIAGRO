# 📚 DesafioMiltec – API de Livros (.NET 8)

API REST desenvolvida em **ASP.NET Core (.NET 8)** como prova de conceito, responsável por listar livros a partir de um arquivo JSON, permitir buscas flexíveis (inclusive em campos dinâmicos de especificações), ordenação por preço e cálculo de frete.

O projeto segue princípios de **Clean Architecture**, separando claramente **Domain**, **Application**, **Infrastructure** e **API**.

---

## 🚀 Tecnologias Utilizadas

- .NET 8  
- ASP.NET Core Web API  
- Swagger (Swashbuckle)  
- xUnit (testes unitários)  
- Injeção de Dependência nativa do ASP.NET Core  
- JSON como fonte de dados  

---

## ▶️ Como executar o projeto

### Pré-requisitos
- .NET SDK 8 instalado  
https://dotnet.microsoft.com/download/dotnet/8.0

### Executar a API
```bash
dotnet restore
dotnet run
```

A aplicação será iniciada em:
```
https://localhost:7254
```

---

## 📖 Documentação Swagger

```
https://localhost:7254/swagger
```

---

## 🔌 Endpoints

### Listar livros
```
GET /api/Book
```

### Ordenar por preço
```
GET /api/Book?order=asc
GET /api/Book?order=desc
```

### Buscar por ID
```
GET /api/Book/{id}
```

Exemplo:
```
https://localhost:7254/api/Book/5
```

### Buscar por termo
```
GET /api/Book?search={termo}
```

Exemplos:
- Autor: `search=Jules`
- Gênero: `search=Fantasy`
- Páginas: `search=183`
- Ilustrador: `search=Édouard`

### Calcular frete
```
GET /api/Book/{id}/calcularfrete
```

---

## 🧪 Testes

Executar:
```bash
dotnet test
```

---

## 🗂 Estrutura

```
src/DesafioMiltec
tests/DesafioMiltec.Tests
```

---

## 👤 Autor

Projeto desenvolvido por Silvio Dias Ferreira como prova de conhecimento técnico.

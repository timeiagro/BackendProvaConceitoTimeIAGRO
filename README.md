# Desafio Miltec – API de Catálogo de Livros

## 📖 Descrição
API desenvolvida em **ASP.NET Core (.NET 8)** para consulta de um catálogo de livros a partir de um arquivo JSON imutável.  
Permite busca por diferentes critérios, ordenação por preço e cálculo de frete.

---

## 🚀 Tecnologias Utilizadas
- .NET 8
- ASP.NET Core Web API
- Swagger (Swashbuckle)
- xUnit (testes unitários)
- Arquitetura em camadas (Domain, Application, Infrastructure)

---

## ▶️ Como Executar o Projeto

### Pré-requisitos
- .NET SDK 8 instalado

### Executar a API
```bash
dotnet run
```

A API estará disponível em:
```
https://localhost:7254
```

---

## 📘 Swagger
A documentação interativa pode ser acessada em:

```
https://localhost:7254/swagger
```

---

## 🔗 Endpoints Disponíveis

### Buscar todos os livros (ordenado por preço)
```
GET /api/Book?order=asc
GET /api/Book?order=desc
```

### Buscar por ID
```
GET /api/Book/5
```

### Buscar por termo (nome, autor, gênero, páginas, ilustrador, etc.)
```
GET /api/Book?search=Jules
GET /api/Book?search=Fantasy
GET /api/Book?search=183
GET /api/Book?search=Édouard
```

### Calcular frete (20% do valor do livro)
```
GET /api/Book/{id}/calcularfrete
```

---

## 🧪 Como Executar os Testes Unitários

Os testes estão localizados no projeto:

```
tests/DesafioMiltec.Tests
```

### Executar todos os testes
A partir da raiz da solução, execute:

```bash
dotnet test
```

### O que está sendo testado
- Busca de livro por ID (existente e inexistente)
- Busca geral de livros
- Filtro por nome
- Filtro por autor
- Termo inexistente
- Cálculo de frete

Os testes utilizam:
- **FakeBookRepository** (repositório fake em memória)
- **FakeCalculateShipping** (serviço fake de frete)
- xUnit como framework de testes

---

## 📂 Estrutura do Projeto

```
src/
 └── DesafioMiltec
     ├── Application
     ├── Controllers
     ├── Domain
     ├── DTOs
     ├── Infrastructure
     └── Program.cs

tests/
 └── DesafioMiltec.Tests
     ├── Application
     └── Fakes
```

---

## ✅ Observações
- O arquivo `books.json` é versionado e **não deve ser alterado**
- O projeto segue princípios de:
  - SOLID
  - Clean Code
  - Separação de responsabilidades
- O Swagger é utilizado apenas para documentação (não é framework de negócio)

---

## 👤 Autor
Projeto desenvolvido por Silvio Dias Ferreira como prova técnica / desafio de backend em .NET.

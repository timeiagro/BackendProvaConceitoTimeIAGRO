# Book Catalog API

API REST para busca e consulta de livros em catálogo JSON, desenvolvida em C# com .NET 8.

---

## Requisitos Implementados

**Busca de livros** a partir de arquivo JSON (leitura apenas, sem modificação)  
**Filtros por especificações**: nome, autor, gênero, ilustrador  
**Ordenação por preço**: crescente (asc) e decrescente (desc)  
**Cálculo de frete**: 20% do valor do livro  
**Testes unitários**: 70+ testes cobrindo toda a lógica  

---

## Tecnologias Utilizadas

- **.NET 8.0** (compatível com .NET Core 3.1+)
- **ASP.NET Core Web API**
- **System.Text.Json** para serialização
- **xUnit + Moq + FluentAssertions** para testes

---

## Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado

### Passo 1: Clonar o repositório
```bash
git clone 
cd BackendProvaConceitoTimeIAGRO
```

### Passo 2: Restaurar dependências
```bash
dotnet restore
```

### Passo 3: Executar a API
```bash
cd BookCatalogApi
dotnet run
```

### Passo 4: Executar os testes
```bash
# Na raiz da solution
dotnet test
```

---

## Endpoints da API

### 1. Listar/Buscar Livros

**`GET /api/books`**

Retorna todos os livros ou filtra por parâmetros.

---

### 2. Buscar Livro por ID

**`GET /api/books/{id}`**

Retorna um livro específico.

---

### 3. Calcular Frete

**`GET /api/books/{id}/shipping`**

Calcula o frete como **20% do valor do livro**.

---

## Testes

O projeto possui **70+ testes unitários** cobrindo:

Cálculo de frete (20% do valor)  
Busca por nome, autor, gênero, ilustrador  
Ordenação ascendente e descendente  
Tratamento de JSON dinâmico (campos que podem ser string ou array)  
Casos de borda (livro não encontrado, busca vazia, validações)  

**Executar testes:**
```bash
dotnet test
```

---

### Sem Frameworks Externos

Conforme solicitado, o projeto **não utiliza frameworks adicionais**:
- Sem Entity Framework
- Sem AutoMapper
- Sem FluentValidation
- Apenas bibliotecas nativas do .NET

---

## Notas Importantes

- O arquivo `books.json` **não é modificado** pela aplicação (apenas leitura)
- Todas as buscas são **case-insensitive** e aceitam **buscas parciais**
- O cálculo de frete é **sempre 20%** do valor do livro, arredondado para 2 casas decimais
- A API possui **documentação Swagger** acessível em `/swagger`

---

## Autor

**Matheus Braga**

Desenvolvido como parte do teste técnico para a vaga de Desenvolvedor Backend .NET na Time IAGRO.
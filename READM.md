# API de Livros

## Descrição
Esta API fornece endpoints para acessar e manipular informações sobre livros.

## Endpoints

### [GET] /api/Book/GetBooks
Retorna todos os livros disponíveis.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".

#### Exemplo de uso:

### [GET] /api/Book/search-by-author
Retorna os livros filtrados pelo autor especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **author**: (Obrigatório) O autor dos livros a serem pesquisados.

### [GET] /api/Book/search-by-name
Retorna os livros filtrados pelo nome especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) O nome dos livros a serem pesquisados.

### [GET] /api/Book/search-by-price
Retorna os livros filtrados pelo preço especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) O preço dos livros a serem pesquisados.

### [GET] /api/Book/search-by-published
Retorna os livros filtrados pela data de publicação especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) Data de publicação dos livros a serem pesquisados.

### [GET] /api/Book/search-by-Illustrator
Retorna os livros filtrados pela ilustrador especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) Ilustrador dos livros a serem pesquisados.

### [GET] /api/Book/search-by-Genres
Retorna os livros filtrados pelo genêro especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros por preço em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) Genêro dos livros a serem pesquisados.

### [GET] /api/Book/calculate-shipping
Calcula o custo de envio para um livro especificado.

#### Parâmetros de consulta:
- **ordem**: (Opcional) Ordena os livros em ordem ascendente ou descendente. Valores possíveis: "Asc" ou "Desc".
- **name**: (Obrigatório) O nome do livro para o qual o custo de envio será calculado.

## Autor
[Felipe Dutra de Carvalho](https://github.com/Carvalho2099)



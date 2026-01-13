Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

    Criar uma API para buscar produtos no arquivo JSON disponibilizado.
    Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
    É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
    Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

    Organização de código;
    Manutenibilidade;
    Princípios de orientação à objetos;
    Padrões de projeto;
    Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

----------------------------------------

Para executar o projeto, é necessário ter o .NET 8.0 instalado. A aplicação é uma API feita em ASP.NET Core que lê os livros a partir de um arquivo JSON apenas para consulta. A API permite buscar livros por autor, título ou outras informações, ordenar os resultados pelo preço (crescente ou decrescente) e calcular o valor do frete, que corresponde a 20% do preço do livro.
Os testes unitários são executados separadamente da API e servem para verificar apenas as regras de negócio. Eles utilizam xUnit, Moq e FluentAssertions para simular dependências, garantindo que os testes funcionem sem acessar o arquivo JSON ou outros recursos externos. 

Arquitetura
O projeto segue boas práticas de orientação a objetos e separação de responsabilidades:

- Controllers → Exposição da API
- Services → Regras de negócio
- Repositories → Leitura do JSON
- Models→ Estrutura de domínio
- Tests → Testes unitários (xUnit)

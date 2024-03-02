## Como executar o projeto

###### Requisito: possuir o Microsoft .Net SDK 6.0

1 - Clone o repositório e vá até a pasta do projeto
    
    git clone https://github.com/BrunoUmbelino/BackendProvaConceitoTimeIAGRO.git
    cd .\BackendProvaConceitoTimeIAGRO\BuscadorDeLivros\
    
2 - Build e execute o projeto

    dotnet build
    dotnet run
  
3 - Abra o Swagger em seu navegador

    https://localhost:7014/swagger/index.html

## Como executar os testes

1_ Abra a solução do projeto de testes

    cd .\BackendProvaConceitoTimeIAGRO\BuscadorDeLivros.Testes.Unidade\

2_ Build e execute os testes

    dotnet test

<hr>

Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado.
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

- Organização de código;
- Manutenibilidade;
- Princípios de orientação à objetos;
- Padrões de projeto;
- Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

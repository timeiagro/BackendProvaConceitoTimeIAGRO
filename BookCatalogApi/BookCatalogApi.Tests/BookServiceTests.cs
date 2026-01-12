using BookCatalogApi.Dtos;
using BookCatalogApi.Models;
using BookCatalogApi.Repository;
using BookCatalogApi.Services;
using FluentAssertions;
using Moq;
using System.Text.Json;

namespace BookCatalogApi.Tests;

public class BookServiceTests
{
    private readonly Mock<IBookRepository> _repositoryMock;
    private readonly BookService _service;
    private readonly List<Book> _testBooks;

    public BookServiceTests()
    {
        _repositoryMock = new Mock<IBookRepository>();
        _service = new BookService(_repositoryMock.Object);
        _testBooks = CreateTestBooks();

        _repositoryMock.Setup(r => r.GetAll()).Returns(_testBooks);
    }

    #region Constructor Tests
    [Fact]
    public void Constructor_WithNullRepository_ThrowsArgumentNullException()
    {
        var act = () => new BookService(null!);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("repository");
    }
    #endregion

    #region Search by Name Tests
    [Fact]
    public void Search_ByName_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Name = "Harry Potter" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
        result[0].Name.Should().Contain("Harry Potter");
    }

    [Fact]
    public void Search_ByName_IsCaseInsensitive()
    {
        var request = new BookSearchRequest { Name = "harry potter" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
        result[0].Name.Should().Contain("Harry Potter");
    }

    [Fact]
    public void Search_ByPartialName_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Name = "Potter" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
    }

    [Theory]
    [InlineData("Journey")]
    [InlineData("JOURNEY")]
    [InlineData("journey")]
    [InlineData("Center")]
    public void Search_ByNameVariations_WorksCorrectly(string searchName)
    {
        var request = new BookSearchRequest { Name = searchName };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
        result[0].Name.Should().Contain("Journey");
    }
    #endregion

    #region Search by Author Tests
    [Fact]
    public void Search_ByAuthor_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Author = "Jules Verne" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(2);
        result.Should().AllSatisfy(b =>
            b.Specifications.Author.Should().Contain("Jules Verne"));
    }

    [Fact]
    public void Search_ByPartialAuthor_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Author = "Rowling" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(2);
        result.Should().AllSatisfy(b =>
            b.Specifications.Author.Should().Contain("Rowling"));
    }

    [Theory]
    [InlineData("Tolkien", 1)]
    [InlineData("Verne", 2)]
    [InlineData("Rowling", 2)]
    [InlineData("NonExistent", 0)]
    public void Search_ByVariousAuthors_ReturnsCorrectCount(string author, int expectedCount)
    {
        var request = new BookSearchRequest { Author = author };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(expectedCount);
    }
    #endregion

    #region Search by Genre Tests
    [Fact]
    public void Search_ByGenre_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Genre = "Fantasy" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(3);
        result.Should().AllSatisfy(b =>
            b.Specifications.Genres.Should().Contain(g => g.Contains("Fantasy")));
    }

    [Fact]
    public void Search_ByGenre_MatchesSingleStringGenre()
    {
        var request = new BookSearchRequest { Genre = "Adventure" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public void Search_ByGenre_IsCaseInsensitive()
    {
        var request = new BookSearchRequest { Genre = "fantasy" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(3);
    }

    [Theory]
    [InlineData("Science", 1)]
    [InlineData("Adventure", 3)]
    [InlineData("Fantasy", 3)]
    public void Search_ByDifferentGenres_ReturnsCorrectBooks(string genre, int expectedCount)
    {
        var request = new BookSearchRequest { Genre = genre };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(expectedCount);
    }
    #endregion

    #region Search by Illustrator Tests
    [Fact]
    public void Search_ByIllustrator_ReturnsMatchingBooks()
    {
        var request = new BookSearchRequest { Illustrator = "Cliff Wright" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
    }

    [Fact]
    public void Search_ByIllustrator_IsCaseInsensitive()
    {
        var request = new BookSearchRequest { Illustrator = "cliff wright" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
    }
    #endregion

    #region Generic Query Search Tests
    [Fact]
    public void Search_ByGenericQuery_SearchesAllFields()
    {
        var request = new BookSearchRequest { Query = "Tolkien" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
        result[0].Specifications.Author.Should().Contain("Tolkien");
    }

    [Fact]
    public void Search_ByGenericQuery_FindsInName()
    {
        var request = new BookSearchRequest { Query = "Potter" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(1);
        result[0].Name.Should().Contain("Potter");
    }

    [Fact]
    public void Search_ByGenericQuery_FindsInGenres()
    {
        var request = new BookSearchRequest { Query = "Science Fiction" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCountGreaterThan(0);
    }
    #endregion

    #region Sorting Tests
    [Fact]
    public void Search_SortByPriceAsc_ReturnsOrderedResults()
    {
        var request = new BookSearchRequest { SortBy = "price", SortOrder = "asc" };

        var result = _service.Search(request).ToList();

        result.Should().BeInAscendingOrder(b => b.Price);
        result[0].Price.Should().Be(6.15m);
        result[^1].Price.Should().Be(11.15m);
    }

    [Fact]
    public void Search_SortByPriceDesc_ReturnsOrderedResults()
    {
        var request = new BookSearchRequest { SortBy = "price", SortOrder = "desc" };

        var result = _service.Search(request).ToList();

        result.Should().BeInDescendingOrder(b => b.Price);
        result[0].Price.Should().Be(11.15m);
        result[^1].Price.Should().Be(6.15m);
    }

    [Fact]
    public void Search_SortByPriceDesc_CaseInsensitive()
    {
        var request = new BookSearchRequest { SortBy = "PRICE", SortOrder = "DESC" };

        var result = _service.Search(request).ToList();

        result.Should().BeInDescendingOrder(b => b.Price);
    }

    [Fact]
    public void Search_SortByNameAsc_ReturnsAlphabeticalOrder()
    {
        var request = new BookSearchRequest { SortBy = "name", SortOrder = "asc" };

        var result = _service.Search(request).ToList();

        result.Should().BeInAscendingOrder(b => b.Name);
    }

    [Fact]
    public void Search_SortByNameDesc_ReturnsReverseAlphabeticalOrder()
    {
        var request = new BookSearchRequest { SortBy = "name", SortOrder = "desc" };

        var result = _service.Search(request).ToList();

        result.Should().BeInDescendingOrder(b => b.Name);
    }

    [Fact]
    public void Search_SortWithoutOrder_DefaultsToAscending()
    {
        var request = new BookSearchRequest { SortBy = "price" };

        var result = _service.Search(request).ToList();

        result.Should().BeInAscendingOrder(b => b.Price);
    }

    [Fact]
    public void Search_WithInvalidSortBy_ReturnsUnsorted()
    {
        var request = new BookSearchRequest { SortBy = "invalid", SortOrder = "asc" };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(_testBooks.Count);
    }
    #endregion

    #region Multiple Filters Tests
    [Fact]
    public void Search_WithMultipleFilters_AppliesAllFilters()
    {
        var request = new BookSearchRequest
        {
            Author = "Rowling",
            SortBy = "price",
            SortOrder = "asc"
        };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(2);
        result.Should().BeInAscendingOrder(b => b.Price);
        result.Should().AllSatisfy(b =>
            b.Specifications.Author.Should().Contain("Rowling"));
    }

    [Fact]
    public void Search_GenreAndSorting_CombinesCorrectly()
    {
        var request = new BookSearchRequest
        {
            Genre = "Fantasy",
            SortBy = "price",
            SortOrder = "desc"
        };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(3);
        result.Should().BeInDescendingOrder(b => b.Price);
    }
    #endregion

    #region GetById Tests
    [Fact]
    public void GetById_ExistingId_ReturnsBook()
    {
        _repositoryMock.Setup(r => r.GetById(1)).Returns(_testBooks[0]);

        var result = _service.GetById(1);

        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        _repositoryMock.Setup(r => r.GetById(999)).Returns((Book?)null);

        var result = _service.GetById(999);

        result.Should().BeNull();
    }
    #endregion

    #region CalculateShipping Tests
    [Fact]
    public void CalculateShipping_ExistingBook_ReturnsCorrectValue()
    {
        var book = new Book { Id = 1, Price = 10.00m };
        _repositoryMock.Setup(r => r.GetById(1)).Returns(book);

        var result = _service.CalculateShipping(1);

        result.Should().Be(2.00m);
    }

    [Fact]
    public void CalculateShipping_NonExistingBook_ThrowsKeyNotFoundException()
    {
        _repositoryMock.Setup(r => r.GetById(999)).Returns((Book?)null);

        var act = () => _service.CalculateShipping(999);

        act.Should().Throw<KeyNotFoundException>()
            .WithMessage("*999*");
    }
    #endregion

    #region Response Mapping Tests
    [Fact]
    public void Search_ResponseIncludesShippingCost()
    {
        var request = new BookSearchRequest();

        var result = _service.Search(request).First();

        result.ShippingCost.Should().Be(result.Price * 0.20m);
    }

    [Fact]
    public void Search_ResponseIncludesTotalPrice()
    {
        var request = new BookSearchRequest();

        var result = _service.Search(request).First();

        result.TotalPrice.Should().Be(result.Price + result.ShippingCost);
    }

    [Fact]
    public void Search_ResponseIncludesAllSpecifications()
    {
        var request = new BookSearchRequest { Name = "Lord" };

        var result = _service.Search(request).First();

        result.Specifications.Should().NotBeNull();
        result.Specifications.Author.Should().Be("J. R. R. Tolkien");
        result.Specifications.Genres.Should().NotBeEmpty();
    }
    #endregion

    #region Edge Cases Tests
    [Fact]
    public void Search_EmptyRequest_ReturnsAllBooks()
    {
        var request = new BookSearchRequest();

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(_testBooks.Count);
    }

    [Fact]
    public void Search_NoMatches_ReturnsEmptyList()
    {
        var request = new BookSearchRequest { Name = "NonExistentBook12345" };

        var result = _service.Search(request).ToList();

        result.Should().BeEmpty();
    }

    [Fact]
    public void Search_WithNullValues_HandlesGracefully()
    {
        var request = new BookSearchRequest
        {
            Name = null,
            Author = null,
            Genre = null
        };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(_testBooks.Count);
    }

    [Fact]
    public void Search_WithWhitespaceValues_IgnoresFilter()
    {
        var request = new BookSearchRequest
        {
            Name = "   ",
            Author = "  "
        };

        var result = _service.Search(request).ToList();

        result.Should().HaveCount(_testBooks.Count);
    }
    #endregion

    #region Test Data
    private static List<Book> CreateTestBooks()
    {
        var json = @"[
            {
                ""id"": 1,
                ""name"": ""Journey to the Center of the Earth"",
                ""price"": 10.00,
                ""specifications"": {
                    ""Author"": ""Jules Verne"",
                    ""Genres"": [""Science Fiction"", ""Adventure fiction""]
                }
            },
            {
                ""id"": 2,
                ""name"": ""20,000 Leagues Under the Sea"",
                ""price"": 10.10,
                ""specifications"": {
                    ""Author"": ""Jules Verne"",
                    ""Genres"": ""Adventure fiction""
                }
            },
            {
                ""id"": 3,
                ""name"": ""Harry Potter and the Goblet of Fire"",
                ""price"": 7.31,
                ""specifications"": {
                    ""Author"": ""J. K. Rowling"",
                    ""Genres"": [""Fantasy Fiction"", ""Drama""]
                }
            },
            {
                ""id"": 4,
                ""name"": ""The Lord of the Rings"",
                ""price"": 6.15,
                ""specifications"": {
                    ""Author"": ""J. R. R. Tolkien"",
                    ""Genres"": [""Fantasy Fiction"", ""Adventure Fiction""]
                }
            },
            {
                ""id"": 5,
                ""name"": ""Fantastic Beasts"",
                ""price"": 11.15,
                ""specifications"": {
                    ""Author"": ""J. K. Rowling"",
                    ""Illustrator"": ""Cliff Wright"",
                    ""Genres"": [""Fantasy Fiction""]
                }
            }
        ]";

        return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }
    #endregion
}

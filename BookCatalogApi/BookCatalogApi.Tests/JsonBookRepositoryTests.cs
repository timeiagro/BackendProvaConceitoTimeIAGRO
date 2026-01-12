using BookCatalogApi.Repository;
using FluentAssertions;

namespace BookCatalogApi.Tests;

public class JsonBookRepositoryTests : IDisposable
{
    private readonly string _tempFilePath;

    public JsonBookRepositoryTests()
    {
        _tempFilePath = Path.GetTempFileName();
    }

    #region Constructor Tests
    [Fact]
    public void Constructor_WithValidJson_LoadsBooks()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Test Book"", ""price"": 10.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);

        var repository = new JsonBookRepository(_tempFilePath);
        var books = repository.GetAll().ToList();

        books.Should().HaveCount(1);
        books[0].Name.Should().Be("Test Book");
        books[0].Price.Should().Be(10.00m);
    }

    [Fact]
    public void Constructor_WithMultipleBooks_LoadsAllBooks()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Book 1"", ""price"": 10.00, ""specifications"": {}},
            {""id"": 2, ""name"": ""Book 2"", ""price"": 20.00, ""specifications"": {}},
            {""id"": 3, ""name"": ""Book 3"", ""price"": 30.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);

        var repository = new JsonBookRepository(_tempFilePath);
        var books = repository.GetAll().ToList();

        books.Should().HaveCount(3);
        books.Select(b => b.Id).Should().Equal(1, 2, 3);
    }

    [Fact]
    public void Constructor_WithNonExistentFile_ThrowsFileNotFoundException()
    {
        var invalidPath = "/nonexistent/path/books.json";

        var act = () => new JsonBookRepository(invalidPath);

        act.Should().Throw<FileNotFoundException>()
            .WithMessage($"*{invalidPath}*");
    }

    [Fact]
    public void Constructor_WithNullPath_ThrowsArgumentNullException()
    {
        var act = () => new JsonBookRepository(null!);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("jsonFilePath");
    }

    [Fact]
    public void Constructor_WithEmptyPath_ThrowsArgumentNullException()
    {
        var act = () => new JsonBookRepository(string.Empty);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("jsonFilePath");
    }

    [Fact]
    public void Constructor_WithEmptyJsonArray_LoadsEmptyCollection()
    {
        var json = @"[]";
        File.WriteAllText(_tempFilePath, json);

        var repository = new JsonBookRepository(_tempFilePath);
        var books = repository.GetAll().ToList();

        books.Should().BeEmpty();
    }
    #endregion

    #region GetById Tests
    [Fact]
    public void GetById_ExistingId_ReturnsBook()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Book 1"", ""price"": 10.00, ""specifications"": {}},
            {""id"": 2, ""name"": ""Book 2"", ""price"": 20.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);
        var repository = new JsonBookRepository(_tempFilePath);

        var book = repository.GetById(2);

        book.Should().NotBeNull();
        book!.Id.Should().Be(2);
        book.Name.Should().Be("Book 2");
        book.Price.Should().Be(20.00m);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Book 1"", ""price"": 10.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);
        var repository = new JsonBookRepository(_tempFilePath);

        var book = repository.GetById(999);

        book.Should().BeNull();
    }

    [Fact]
    public void GetById_WithEmptyRepository_ReturnsNull()
    {
        var json = @"[]";
        File.WriteAllText(_tempFilePath, json);
        var repository = new JsonBookRepository(_tempFilePath);

        var book = repository.GetById(1);

        book.Should().BeNull();
    }
    #endregion

    #region GetAll Tests
    [Fact]
    public void GetAll_ReturnsReadOnlyCollection()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Book 1"", ""price"": 10.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);
        var repository = new JsonBookRepository(_tempFilePath);

        var books = repository.GetAll();

        books.Should().BeAssignableTo<IEnumerable<BookCatalogApi.Models.Book>>();
        books.Should().NotBeNull();
    }

    [Fact]
    public void GetAll_CalledMultipleTimes_ReturnsSameData()
    {
        var json = @"[
            {""id"": 1, ""name"": ""Book 1"", ""price"": 10.00, ""specifications"": {}}
        ]";
        File.WriteAllText(_tempFilePath, json);
        var repository = new JsonBookRepository(_tempFilePath);

        var books1 = repository.GetAll().ToList();
        var books2 = repository.GetAll().ToList();

        books1.Should().HaveCount(1);
        books2.Should().HaveCount(1);
        books1[0].Name.Should().Be(books2[0].Name);
    }
    #endregion

    public void Dispose()
    {
        if (File.Exists(_tempFilePath))
        {
            File.Delete(_tempFilePath);
        }
    }
}

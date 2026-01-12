using BookCatalogApi.Models;
using FluentAssertions;
using System.Text.Json;

namespace BookCatalogApi.Tests;

public class BookSpecificationsTests
{
    #region GetGenres Tests
    [Fact]
    public void GetGenres_WithArrayValue_ReturnsAllGenres()
    {
        var json = @"{
            ""Genres"": [""Fantasy"", ""Adventure"", ""Drama""]
        }";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var genres = specs.GetGenres().ToList();

        genres.Should().HaveCount(3);
        genres.Should().Contain("Fantasy");
        genres.Should().Contain("Adventure");
        genres.Should().Contain("Drama");
    }

    [Fact]
    public void GetGenres_WithSingleStringValue_ReturnsSingleItemList()
    {
        var json = @"{
            ""Genres"": ""Adventure fiction""
        }";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var genres = specs.GetGenres().ToList();

        genres.Should().HaveCount(1);
        genres[0].Should().Be("Adventure fiction");
    }

    [Fact]
    public void GetGenres_WithNullValue_ReturnsEmptyList()
    {
        var json = @"{}";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var genres = specs.GetGenres().ToList();

        genres.Should().BeEmpty();
    }

    [Fact]
    public void GetGenres_WithEmptyArray_ReturnsEmptyList()
    {
        var json = @"{
            ""Genres"": []
        }";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var genres = specs.GetGenres().ToList();

        genres.Should().BeEmpty();
    }
    #endregion

    #region GetIllustrators Tests
    [Fact]
    public void GetIllustrators_WithArrayValue_ReturnsAllIllustrators()
    {
        var json = @"{
            ""Illustrator"": [""Alan Lee"", ""Ted Nashmith"", ""J. R. R. Tolkien""]
        }";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var illustrators = specs.GetIllustrators().ToList();

        illustrators.Should().HaveCount(3);
        illustrators.Should().Contain("Alan Lee");
        illustrators.Should().Contain("Ted Nashmith");
    }

    [Fact]
    public void GetIllustrators_WithSingleStringValue_ReturnsSingleItemList()
    {
        var json = @"{
            ""Illustrator"": ""Cliff Wright""
        }";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var illustrators = specs.GetIllustrators().ToList();

        illustrators.Should().HaveCount(1);
        illustrators[0].Should().Be("Cliff Wright");
    }

    [Fact]
    public void GetIllustrators_WithNullValue_ReturnsEmptyList()
    {
        var json = @"{}";
        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        var illustrators = specs.GetIllustrators().ToList();

        illustrators.Should().BeEmpty();
    }
    #endregion

    #region Complete Deserialization Tests
    [Fact]
    public void Deserialization_WithCompleteJson_MapsAllProperties()
    {
        var json = @"{
            ""Originally published"": ""July 29, 1954"",
            ""Author"": ""J. R. R. Tolkien"",
            ""Page count"": 715,
            ""Illustrator"": [""Alan Lee"", ""Ted Nashmith""],
            ""Genres"": [""Fantasy Fiction"", ""Adventure Fiction""]
        }";

        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        specs.OriginallyPublished.Should().Be("July 29, 1954");
        specs.Author.Should().Be("J. R. R. Tolkien");
        specs.PageCount.Should().Be(715);
        specs.GetIllustrators().Should().HaveCount(2);
        specs.GetGenres().Should().HaveCount(2);
    }

    [Fact]
    public void Deserialization_WithMixedStringAndArray_HandlesCorrectly()
    {
        var json = @"{
            ""Author"": ""Jules Verne"",
            ""Illustrator"": ""Édouard Riou"",
            ""Genres"": [""Science Fiction"", ""Adventure fiction""]
        }";

        var specs = JsonSerializer.Deserialize<BookSpecifications>(json)!;

        specs.Author.Should().Be("Jules Verne");
        specs.GetIllustrators().Should().ContainSingle()
            .Which.Should().Be("Édouard Riou");
        specs.GetGenres().Should().HaveCount(2);
    }
    #endregion
}

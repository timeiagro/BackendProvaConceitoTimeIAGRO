using Arbooks.Business.Repository.Interface;
using Moq;
using Arbooks.Business.DTOs;
using Arbooks.Business.Services;
using Arbooks.Business.Repository;

namespace Arbooks.Test.Business
{
    public class BookDTOServiceTests
    {
        public BookDTOServiceTests() { }

        [Fact]
        public void Search_GetAll()
        {
            // Arrange (Preparar)
            var completeList = new List<BookDTO> {
                    new BookDTO {}, new BookDTO {}, new BookDTO {}, new BookDTO {}, new BookDTO {} };

            var mockBookDTORepo = new Mock<IBookRepository>();
            mockBookDTORepo.Setup(repo => repo.Load()).Returns(completeList);

            var service = new BookService(mockBookDTORepo.Object);

            // Act (Agir)
            var result = service.Search(null, "any");

            // Assert (Verificar)
            Assert.Equal(completeList.Count(), result.Count());
        }

        [Fact]
        public void Search_ByNameInsensitive()
        {
            // Arrange (Preparar)
            var completeList = new List<BookDTO> {
                new BookDTO { name = "Savage Pokemons"}, new BookDTO { name = "The Best Training Centers"},
                new BookDTO { name = "Domestic Pokemons"}, new BookDTO { name = "The Best pokemon Foods"},
                new BookDTO { name = "Synanthropic Pokemoms"}, new BookDTO { name = "The Best Coach Accessories"}};
            string term = "pokemon";
            int quantity = 3;

            var mockBookDTORepo = new Mock<IBookRepository>();
            mockBookDTORepo.Setup(repo => repo.Load()).Returns(completeList);

            var service = new BookService(mockBookDTORepo.Object);

            // Act (Agir)
            var result = service.Search(term, "any");

            // Assert (Verificar)
            Assert.Equal(quantity, result.Count());
        }

        [Fact]
        public void Search_NotFound()
        {
            // Arrange (Preparar)
            var completeList = new List<BookDTO> {
                new BookDTO { name = "Savage Pokemons"}, new BookDTO { name = "The Best Training Centers"},
                new BookDTO { name = "Domestic Pokemons"}, new BookDTO { name = "The Best pokemon Foods"},
                new BookDTO { name = "Synanthropic Pokemoms"}, new BookDTO { name = "The Best Coach Accessories"}};
            string term = "snorlax";

            var mockBookDTORepo = new Mock<IBookRepository>();
            mockBookDTORepo.Setup(repo => repo.Load()).Returns(completeList);

            var service = new BookService(mockBookDTORepo.Object);

            // Act (Agir)
            var result = service.Search(term, "any");

            // Assert (Verificar)
            Assert.Empty(result);
        }

        [Fact]
        public void Search_OrderByPriceAsc()
        {
            // Arrange (Preparar)
            var completeList = new List<BookDTO> {
                new BookDTO { price = 60 }, new BookDTO { price = 90 }, new BookDTO { price = 10 },
                new BookDTO { price = 35 }, new BookDTO { price = 95 }, new BookDTO { price = 80 }
            };
            string term = String.Empty; // get all
            string order = "priceAsc";
            decimal[] orderedPrices = completeList.OrderBy(x => x.price).Select(x => x.price).ToArray();

            var mockBookDTORepo = new Mock<IBookRepository>();
            mockBookDTORepo.Setup(repo => repo.Load()).Returns(completeList);

            var service = new BookService(mockBookDTORepo.Object);

            // Act (Agir)
            var result = service.Search(term, order);
            var pricesResult = result.Select(x => x.price).ToArray();

            // Assert (Verificar)
            Assert.Equal(pricesResult, orderedPrices);
        }

        [Fact]
        public void Search_OrderByPriceDesc()
        {
            // Arrange (Preparar)
            var completeList = new List<BookDTO> {
                new BookDTO { price = 60 }, new BookDTO { price = 90 }, new BookDTO { price = 10 },
                new BookDTO { price = 35 }, new BookDTO { price = 95 }, new BookDTO { price = 80 }
            };
            string term = String.Empty; // GET ALL
            string order = "priceDesc";
            decimal[] orderedPrices = completeList.OrderByDescending(x => x.price).Select(x => x.price).ToArray();

            var mockBookDTORepo = new Mock<IBookRepository>();
            mockBookDTORepo.Setup(repo => repo.Load()).Returns(completeList);

            var service = new BookService(mockBookDTORepo.Object);

            // Act (Agir)
            var result = service.Search(term, order);
            var pricesResult = result.Select(x => x.price).ToArray();

            // Assert (Verificar)
            Assert.Equal(pricesResult, orderedPrices);
        }
    }
}

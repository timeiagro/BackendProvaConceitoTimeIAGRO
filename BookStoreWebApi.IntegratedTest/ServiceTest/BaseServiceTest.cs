using AutoFixture;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApi.IntegratedTest.ServiceTest
{
    public class BaseServiceTest
    {
        protected readonly Fixture _fixture;
        protected readonly IConfiguration _config;

        public BaseServiceTest()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _fixture = new Fixture();
        }
    }
}

using AutoFixture;

namespace BookStoreWebApi.IntegratedTest.ControllerTest
{
    public class BaseControllerTest<T>
    {
        protected readonly Fixture _fixture;
        public BaseControllerTest()
        {
            _fixture = new Fixture();
        }
    }
}

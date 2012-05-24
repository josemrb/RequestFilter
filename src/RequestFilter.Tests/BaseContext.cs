using AutoMoq;
using Machine.Specifications;
using Ploeh.AutoFixture;

namespace RequestFilter.Tests
{
    public abstract class BaseContext
    {
        protected static AutoMoqer _moqer;
        protected static Fixture _fixture;

        private Establish context = () =>
                                        {
                                            _moqer = new AutoMoqer();
                                            _fixture = new Fixture();
                                        };        
    }
}

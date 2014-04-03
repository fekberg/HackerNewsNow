using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsNow.IntegrationTests
{
    public abstract class TestBase
    {
        [TestInitialize]
        public void Setup()
        {
            Scope = Container.Current.BeginLifetimeScope();
            Scope.InjectUnsetProperties(this);
        }

        public ILifetimeScope Scope { get; set; }
    }
}
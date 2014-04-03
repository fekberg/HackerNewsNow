using Autofac;
using HackerNewsNow.Shared;

namespace HackerNewsNow.IntegrationTests
{
    public static class Container
    {
        public static IContainer Current { get; set; }

        static Container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof (EntryRepository).Assembly);

            Current = builder.Build();
        }
    }
}
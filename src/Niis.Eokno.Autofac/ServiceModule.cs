using Autofac;
using Niis.Eokno.Abstractions;

namespace Niis.Eokno.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerTrademarkService>()
                .As<ICustomerTrademarkService>()
                .InstancePerLifetimeScope();
        }
    }
}

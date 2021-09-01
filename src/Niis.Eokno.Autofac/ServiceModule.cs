using Autofac;
using Niis.Eokno.Abstractions;
using Niis.Eokno.Handlers.Dictionaries;
using Niis.Eokno.Handlers.Trademarks;

namespace Niis.Eokno.Autofac
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<IntegrationService>()
				.As<IIntegrationService>()
				.InstancePerLifetimeScope();

			builder.RegisterType<GetPatentTypeDictionaryHandler>()
				.As<IHandler>()
				.InstancePerLifetimeScope();

			builder.RegisterType<GetTrademarkClassificationDictionaryHandler>()
				.As<IHandler>()
				.InstancePerLifetimeScope();

			builder.RegisterType<GetTrademarkInfoHandler>()
				.As<IHandler>()
				.InstancePerLifetimeScope();
		}
	}
}
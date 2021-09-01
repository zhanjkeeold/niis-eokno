using Autofac;
using Niis.Eokno.Configuration;
using Niis.Eokno.DataAccess.Abstractions;
using Serilog;

namespace Niis.Eokno.DataAccess.Autofac
{
	public class DataAccessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(x =>
			{
				var configuration = x.Resolve<NiisEoknoConfiguration>();
				var logger = x.Resolve<ILogger>();
				return new UnitOfWork(configuration.ConnectionString, logger);
			}).As<IUnitOfWork>()
			.InstancePerLifetimeScope();
		}
	}
}
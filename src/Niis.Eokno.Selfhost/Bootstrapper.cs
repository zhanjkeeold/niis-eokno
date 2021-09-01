using Autofac;
using Niis.Eokno.Autofac;
using Niis.Eokno.Configuration;
using Niis.Eokno.DataAccess.Autofac;
using Serilog;

namespace Niis.Eokno.Selfhost
{
	public static class Bootstrapper
	{
		public static IContainer Container { get; private set; }

		public static void Build()
		{
			BuildContainer();
		}

		/// <summary>
		///		Build autofac containers.
		/// </summary>
		private static void BuildContainer()
		{
			var builder = new ContainerBuilder();

			RegisterLogger(builder);
			RegisterConfiguration(builder);
			RegisterModules(builder);
			RegisterHostedServices(builder);

			Container = builder.Build();
		}

		/// <summary>
		///		Register configuration.
		/// </summary>
		private static void RegisterConfiguration(ContainerBuilder builder)
		{
			builder.Register(x => new NiisEoknoConfigurationReader().Read())
				.SingleInstance()
				.AsSelf()
				.AutoActivate();
		}

		/// <summary>
		///		Register modules.
		/// </summary>
		private static void RegisterModules(ContainerBuilder builder)
		{
			builder.RegisterModule<ServiceModule>();
			builder.RegisterModule<DataAccessModule>();
		}

		/// <summary>
		///		Register hosted services.
		/// </summary>
		private static void RegisterHostedServices(ContainerBuilder builder)
		{
			builder.RegisterType<IntegrationHostedService>().SingleInstance();
		}

		/// <summary>
		///		Register logger.
		/// </summary>
		private static void RegisterLogger(ContainerBuilder builder)
		{
			builder.Register(x => CreateLogger())
				.AsSelf()
				.AutoActivate();
		}

		/// <summary>
		///		Create logger.
		/// </summary>
		private static ILogger CreateLogger()
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.CreateLogger();

			return Log.Logger;
		}
	}
}

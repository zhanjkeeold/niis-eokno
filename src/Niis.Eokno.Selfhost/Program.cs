using System;
using Topshelf;
using Topshelf.Autofac;
namespace Niis.Eokno.Selfhost
{
	internal class Program
	{
		private static int Main()
		{
			return (int)HostFactory.Run(app =>
			{
				Bootstrapper.Build();

				app.UseSerilog();

				app.UseAutofacContainer(Bootstrapper.Container);

				app.UseAssemblyInfoForServiceInfo();

				app.Service<IntegrationHostedService>(serviceFactory =>
				{
					serviceFactory.ConstructUsingAutofacContainer();
					serviceFactory.WhenStarted((service, control) => service.Start(control));
					serviceFactory.WhenStopped((service, control) => service.Stop(control));
				});

				app.OnException(exception => { Console.WriteLine("Exception thrown - " + exception.Message); });
			});
		}
	}
}
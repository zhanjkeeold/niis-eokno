using Niis.Eokno.Abstractions;
using Niis.Eokno.Configuration;
using Serilog;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Topshelf;

namespace Niis.Eokno.Selfhost
{
	internal class IntegrationHostedService : ServiceControl
	{
		private readonly IIntegrationService _integrationService;
		private readonly NiisEoknoConfiguration _configuration;
		private readonly ILogger _logger;
		private ServiceHost _selfHost;

		public IntegrationHostedService(IIntegrationService integrationService, NiisEoknoConfiguration configuration, ILogger logger)
		{
			if (integrationService == null)
			{
				throw new ArgumentNullException(nameof(integrationService));
			}

			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			if (logger == null)
			{
				throw new ArgumentNullException(nameof(logger));
			}

			_integrationService = integrationService;
			_configuration = configuration;
			_logger = logger;
		}

		public bool Start(HostControl hostControl)
		{
			try
			{
				// Create a URI to serve as the base address.
				var baseAddress = new Uri(_configuration.WebAddress);

				// Create a ServiceHost instance.
				_selfHost = new ServiceHost(_integrationService, baseAddress);

				// Add a service endpoint.
				_selfHost.AddServiceEndpoint(
					typeof(IIntegrationService),
					new BasicHttpBinding(),
					"");

				// Enable metadata exchange.
				var smb = new ServiceMetadataBehavior { HttpGetEnabled = true, HttpsGetEnabled = true };
				_selfHost.Description.Behaviors.Add(smb);

				// Start the wcf service.
				_selfHost.Open();

				_logger.Information("The receive status service is running.");
				_logger.Information($"The receive service is available at {_configuration.WebAddress}");
			}
			catch (Exception e)
			{
				_logger.Error(e, nameof(Start));
			}

			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			// Close the ServiceHost to stop the service.
			_selfHost.Close();
			_logger.Information("The receive service was stopped.");
			return true;
		}
	}
}
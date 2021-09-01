using Niis.Eokno.Abstractions;
using Niis.Eokno.Abstractions.Requests;
using Niis.Eokno.Abstractions.Responses;
using Niis.Eokno.Builders;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
#if NET462
using System.ServiceModel;
#endif

namespace Niis.Eokno
{
#if NET462
	[ServiceBehavior(
		InstanceContextMode = InstanceContextMode.Single,
		IncludeExceptionDetailInFaults = true)]
#endif
	public class IntegrationService : IIntegrationService
	{
		private readonly IEnumerable<IHandler> _handlers;
		private readonly ILogger _logger;

		public IntegrationService(IEnumerable<IHandler> handlers, ILogger logger)
		{
			if (handlers == null)
			{
				throw new ArgumentNullException(nameof(handlers));
			}

			if (logger == null)
			{
				throw new ArgumentNullException(nameof(logger));
			}

			_handlers = handlers;
			_logger = logger;
		}

		public SendMessageResponse SendMessage(SendMessageRequest request)
		{
			if (request?.Request == null)
			{
				throw new ArgumentNullException(nameof(Request));
			}

			_logger.Information("Handling request with message id: {0}", request.Request.RequestInfo.MessageId);

			var data = request?.Request?.RequestData;
			if (data == null)
			{
				_logger.Error("Request with empty data");

				return new SendMessageResponseBuilder()
					.AddRequest(request)
					.BindResponseInfoFromRequestInfo()
					.WithFailedStatus()
					.WithEmptyData()
					.Build();
			}

			var handler = _handlers.FirstOrDefault(x => x.ActionName == data.GetActionName());
			if (handler == null)
			{
				_logger.Error("Request handler not found. ActionName: {0}", data.GetActionName());

				return new SendMessageResponseBuilder()
					.AddRequest(request)
					.BindResponseInfoFromRequestInfo()
					.WithFailedStatus()
					.WithEmptyData()
					.Build();
			}

			var response = handler.Handle(request).GetAwaiter().GetResult();

			return new SendMessageResponseBuilder()
					.AddRequest(request)
					.BindResponseInfoFromRequestInfo()
					.WithSuccessStatus()
					.WithData(response)
					.Build();
		}
	}
}
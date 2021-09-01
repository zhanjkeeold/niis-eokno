using Niis.Eokno.Abstractions;
using Niis.Eokno.Abstractions.Requests;
using Niis.Eokno.DataAccess.Abstractions;
using Serilog;
using System;
using Niis.Eokno.Mappers;
using Niis.Eokno.Utils;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Niis.Eokno.Abstractions.Responses.Trademarks;

namespace Niis.Eokno.Handlers.Trademarks
{
	public sealed class GetTrademarkInfoHandler : IHandler
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public GetTrademarkInfoHandler(IUnitOfWork unitOfWork, ILogger logger)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			if (logger == null)
			{
				throw new ArgumentNullException(nameof(logger));
			}

			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public ActionName ActionName => ActionName.TrademarkInfoRequest;

		public async Task<XElement> Handle(SendMessageRequest request, CancellationToken cancellationToken = default)
		{
			var trademarkRepository = _unitOfWork.CustomerTrademarkRepository;

			var trademarkInfoRequest = request.Request.RequestData.TrademarkInfoRequest;

			var response = (await trademarkRepository
				.GetTrademarkInfoAsync(
					trademarkInfoRequest.PatentTypeId,
					trademarkInfoRequest.GosNumber,
					cancellationToken))
				.ToResponse();

			return response.ToXElement<TrademarkInfoResponse>();
		}
	}
}

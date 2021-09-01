using Niis.Eokno.Abstractions;
using Niis.Eokno.Abstractions.Requests;
using Niis.Eokno.Abstractions.Responses.Dictionaries;
using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Mappers;
using Niis.Eokno.Utils;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Niis.Eokno.Handlers.Dictionaries
{
	public sealed class GetPatentTypeDictionaryHandler : IHandler
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;

		public GetPatentTypeDictionaryHandler(IUnitOfWork unitOfWork, ILogger logger)
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

		public ActionName ActionName => ActionName.PatentTypeDictionaryRequest;

		public async Task<XElement> Handle(SendMessageRequest request, CancellationToken cancellationToken = default)
		{
			var patentDictionaryRepository = _unitOfWork.PatentDictionaryRepository;

			var response = new PatentTypeDictionaryResponse
			{
				PatentTypes = (await patentDictionaryRepository.GetAllAsync(cancellationToken)).Select(x => x?.ToResponse())?.ToArray()
			};

			return response.ToXElement<PatentTypeDictionaryResponse>();
		}
	}
}

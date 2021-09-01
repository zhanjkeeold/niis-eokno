using Niis.Eokno.DataAccess.Abstractions;
using Serilog;
using System;

namespace Niis.Eokno.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(string connectionString, ILogger logger)
		{
			if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
			if (logger == null) throw new ArgumentNullException(nameof(logger));

			PatentDictionaryRepository = new PatentDictionaryRepository(connectionString, logger);
			TrademarkDictionaryRepository = new TrademarkDictionaryRepository(connectionString, logger);
			CustomerTrademarkRepository = new CustomerTrademarkRepository(connectionString, logger);
		}

		public IPatentDictionaryRepository PatentDictionaryRepository { get; }
		public ITrademarkDictionaryRepository TrademarkDictionaryRepository { get; }
		public ICustomerTrademarkRepository CustomerTrademarkRepository { get; }
	}
}
using Niis.Eokno.DataAccess.Abstractions;
using System;

namespace Niis.Eokno.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            PatentDictionaryRepository = new PatentDictionaryRepository(connectionString);
            TrademarkDictionaryRepository = new TrademarkDictionaryRepository(connectionString);
            CustomerTrademarkRepository = new CustomerTrademarkRepository(connectionString);
        }

        public IPatentDictionaryRepository PatentDictionaryRepository { get; }

        public ITrademarkDictionaryRepository TrademarkDictionaryRepository { get; }

        public ICustomerTrademarkRepository CustomerTrademarkRepository { get; }
    }
}

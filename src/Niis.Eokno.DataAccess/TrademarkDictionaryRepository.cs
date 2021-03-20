using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess
{
    public class TrademarkDictionaryRepository : ITrademarkDictionaryRepository
    {
        public TrademarkDictionaryRepository(string connectionString)
        {

        }

        public IReadOnlyCollection<TrademarkClassification> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TrademarkClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

using Niis.Eokno.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess.Abstractions
{
    public interface ITrademarkDictionaryRepository
    {
        IReadOnlyCollection<TrademarkClassification> GetAll();

        Task<IReadOnlyCollection<TrademarkClassification>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}

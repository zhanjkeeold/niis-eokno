using Niis.Eokno.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess.Abstractions
{
    public interface ICustomerTrademarkRepository
    {
        CustomerTrademarkValidityInfo GetTrademarkValidityInfo(int patentDictionaryId, string gosNumber);

        Task<CustomerTrademarkValidityInfo> GetTrademarkValidityInfoAsync(int patentDictionaryId, string gosNumber, CancellationToken cancellationToken = default);
    }
}

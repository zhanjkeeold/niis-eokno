using Niis.Eokno.DataAccess.Abstractions;
using Niis.Eokno.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess
{
    public class CustomerTrademarkRepository : ICustomerTrademarkRepository
    {
        public CustomerTrademarkRepository(string connectionString)
        {

        }

        public CustomerTrademarkValidityInfo GetTrademarkValidityInfo(int patentDictionaryId, string gosNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerTrademarkValidityInfo> GetTrademarkValidityInfoAsync(int patentDictionaryId, string gosNumber, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}

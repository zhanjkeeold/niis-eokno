using Niis.Eokno.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Niis.Eokno.DataAccess.Abstractions
{
	public interface ICustomerTrademarkRepository
	{
		TrademarkInfo GetTrademarkInfo(int patentTypeId, string gosNumber);

		Task<TrademarkInfo> GetTrademarkInfoAsync(int patentTypeId, string gosNumber,
			CancellationToken cancellationToken = default);
	}
}
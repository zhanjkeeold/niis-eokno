using Niis.Eokno.Abstractions.Dtos;
using Niis.Eokno.Abstractions.Requests;
using System.ServiceModel;

namespace Niis.Eokno.Abstractions
{
    [ServiceContract(Namespace = "http://bip.bee.kz/SyncChannel/v10/Types")]
    public interface ICustomerTrademarkService
    {
        [OperationContract]
        Response<CustomerTrademarkValidityInfoDto> SendMessage(SendMessageRequest request);
    }
}

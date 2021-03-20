using Niis.Eokno.Abstractions;
using Niis.Eokno.Abstractions.Dtos;
using Niis.Eokno.Abstractions.Requests;

namespace Niis.Eokno
{
    public class CustomerTrademarkService : ICustomerTrademarkService
    {
        public Response<CustomerTrademarkValidityInfoDto> SendMessage(SendMessageRequest request)
        {
            return new Response<CustomerTrademarkValidityInfoDto>(1, "asdf", "asdf-1234");
        }
    }
}

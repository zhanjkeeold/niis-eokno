using System;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Dtos
{
    [DataContract(Name = "response")]
    public class Response<T> where T : class
    {
        public Response()
        {

        }

        public Response(int code, string message, string sessionId)
        {
            ResponseInfo = new ResponseInfo
            {
                MessageId = Guid.NewGuid().ToString(),
                ResponseDate = DateTime.Now,
                SessionId = sessionId,
                Status = new Status
                {
                    Code = code,
                    Message = message
                }
            };
        }

        [DataMember(Name = "responseInfo")]
        public ResponseInfo ResponseInfo { get; set; }

        [DataMember(Name = "responseData")]
        public T ResponseData { get; set; }
    }
}
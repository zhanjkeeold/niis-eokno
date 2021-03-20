using System;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Dtos
{
    [DataContract(Name = "responseInfo")]
    public class ResponseInfo
    {
        [DataMember(Name = "messageId")]
        public string MessageId { get; set; }

        [DataMember(Name = "responseDate")]
        public DateTime ResponseDate { get; set; }

        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }

        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }
}
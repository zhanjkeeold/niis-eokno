using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Dtos
{
    [DataContract(Name = "status")]
    public class Status
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}

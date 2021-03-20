using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions
{
    [DataContract(Name = "requestData")]
    public class RequestData
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "gosNumber")]
        public string GosNumber { get; set; }
    }
}

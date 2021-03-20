using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Dtos
{
    [DataContract(Name = "sender")]
    public class Sender
    {
        [DataMember(Name = "senderId")]
        public string SenderId { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}

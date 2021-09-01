using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Niis.Eokno.Abstractions.Responses
{
	/// <summary>
	///		Объект "данные ответа".
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class ResponseData
	{
		/// <summary>
		///		Объект данные сообщения.
		///		(Формат определяется системой получателя сообщения).
		/// </summary>
		[DataMember(Name = "data")]
		public XElement Data { get; set; }
	}
}

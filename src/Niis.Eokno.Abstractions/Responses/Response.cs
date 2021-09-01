using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Niis.Eokno.Abstractions.Responses
{
	/// <summary>
	///		Ответ.
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class Response
	{
		/// <summary>
		///		Информация об ответе.
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "responseInfo")]
		public ResponseInfo ResponseInfo { get; set; }

		/// <summary>
		///		Объект "данные ответа".
		/// </summary>
		[DataMember(
			Order = 1,
			Name = "responseData")]
		public XElement ResponseData { get; set; }
	}
}
using System.ServiceModel;
using System.Xml.Linq;

namespace Niis.Eokno.Abstractions.Requests
{
	/// <summary>
	///     Сообщение от ШЭП-а.
	/// </summary>
	[MessageContract(
		IsWrapped = true,
		WrapperName = Global.SendMessage,
		WrapperNamespace = Global.ServiceContractNamespace)]
	public class SendMessageRequest
	{
		/// <summary>
		///     Заголовок с подписью.
		/// </summary>
		[MessageHeader(
			MustUnderstand = true,
			Namespace = Global.SecurityHeaderNamespace)]
		public XElement Security { get; set; }

		/// <summary>
		///     Запрос от ИБД.
		/// </summary>
		[MessageBodyMember(
			Name = "request",
			Namespace = Global.Empty)]
		public Request Request { get; set; }
	}
}
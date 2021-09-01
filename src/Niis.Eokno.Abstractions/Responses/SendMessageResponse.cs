using System.ServiceModel;

namespace Niis.Eokno.Abstractions.Responses
{
	/// <summary>
	///     Ответ для ШЭП-а.
	/// </summary>
	[MessageContract(
		IsWrapped = true,
		WrapperName = Global.SendMessageResponse,
		WrapperNamespace = Global.ServiceContractNamespace)]
	public class SendMessageResponse
	{
		/// <summary>
		///     Ответ.
		/// </summary>
		[MessageBodyMember(
			Name = "response",
			Namespace = Global.Empty)]
		public Response Response { get; set; }
	}
}
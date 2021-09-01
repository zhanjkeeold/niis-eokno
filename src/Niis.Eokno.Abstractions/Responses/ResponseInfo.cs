using System;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Responses
{
	/// <summary>
	///		Информация об ответе.
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class ResponseInfo
	{
		/// <summary>
		///     Идентификатор сообщения.
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "messageId")]
		public string MessageId { get; set; }

		/// <summary>
		///		Дата ответа.
		/// </summary>
		[DataMember(
			Order = 1,
			Name = "responseDate")]
		public DateTime ResponseDate { get; set; }

		/// <summary>
		///		Объект "Информация о статусе".
		/// </summary>
		[DataMember(
			Order = 2,
			Name = "status")]
		public Status Status { get; set; }

		/// <summary>
		///		Идентификатор сессии ШЭП.
		/// </summary>
		[DataMember(
			Order = 3,
			Name = "sessionId")]
		public string SessionId { get; set; }
	}
}
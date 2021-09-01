using System;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Requests
{
	/// <summary>
	///     Метаданные сообщения.
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class RequestInfo
	{
		/// <summary>
		///     Идентификатор сообщения в системе получателя
		///     (заполняет система получателя запроса (система отрабатывающая сообщение).
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "messageId")]
		public string MessageId { get; set; }

		/// <summary>
		///     Идентификатор сервиса.
		/// </summary>
		[DataMember(
			Order = 2,
			Name = "serviceId")]
		public string ServiceId { get; set; }

		/// <summary>
		///     Дата создания сообщения.
		/// </summary>
		[DataMember(
			Order = 4,
			Name = "messageDate")]
		public DateTime? MessageDate { get; set; }

		/// <summary>
		///     Объект информация об отправителе (заполняется отправителем).
		/// </summary>
		[DataMember(
			Order = 5,
			Name = "sender")]
		public Sender Sender { get; set; }

		/// <summary>
		///     Идентификатор сессии ШЭП.
		///     (Заполняется на ШЭП, отправителю заполнять не надо).
		/// </summary>
		[DataMember(
			Order = 6,
			Name = "sessionId")]
		public string SessionId { get; set; }
	}
}
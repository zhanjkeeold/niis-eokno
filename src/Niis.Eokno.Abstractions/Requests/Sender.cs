using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Requests
{
	/// <summary>
	///     Объект информация об отправителе (заполняется отправителем).
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class Sender
	{
		/// <summary>
		///     Идентификатор отправителя (системы отправителя).
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "senderId")]
		public string SenderId { get; set; }

		/// <summary>
		///     Пароль отправителя.
		/// </summary>
		[DataMember(
			Order = 1,
			Name = "password")]
		public string Password { get; set; }
	}
}
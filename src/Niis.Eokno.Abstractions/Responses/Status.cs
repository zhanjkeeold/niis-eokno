using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Responses
{
	/// <summary>
	///		Объект "Информация о статусе".
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	public class Status
	{
		/// <summary>
		///		Код статуса сообщения.
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "code")]
		public string Code { get; set; }

		/// <summary>
		///		Сообщение статуса.
		/// </summary>
		[DataMember(
			Order = 1,
			Name = "message")]
		public string Message { get; set; }
	}
}
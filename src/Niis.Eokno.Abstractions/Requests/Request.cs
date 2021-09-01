using Niis.Eokno.Abstractions.Requests.Dictionaries;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Requests
{
	/// <summary>
	///     Запрос.
	/// </summary>
	[DataContract(Namespace = Global.Empty)]
	[KnownType(typeof(PatentTypeDictionaryRequest))]
	public class Request
	{
		/// <summary>
		///     Метаданные сообщения.
		/// </summary>
		[DataMember(
			Order = 0,
			Name = "requestInfo")]
		public RequestInfo RequestInfo { get; set; }

		/// <summary>
		///     Объект передачи данных.
		/// </summary>
		[DataMember(
			Order = 1,
			Name = "requestData")]
		public RequestData RequestData { get; set; }
	}
}
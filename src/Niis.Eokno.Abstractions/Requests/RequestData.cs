using Niis.Eokno.Abstractions.Requests.Dictionaries;
using Niis.Eokno.Abstractions.Requests.Trademarks;
using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Requests
{
	[DataContract(Namespace = Global.Empty)]
	public class RequestData : IExtensibleDataObject
	{
		#region Possible handle requests.

		[DataMember(
			Order = 0,
			Name = "patentTypeDictionaryRequest")]
		public PatentTypeDictionaryRequest PatentTypeDictionaryRequest { get; set; }

		[DataMember(
			Order = 1,
			Name = "trademarkClassificationDictionaryRequest")]
		public TrademarkClassiciationDictionaryRequest TrademarkClassiciationDictionaryRequest { get; set; }

		[DataMember(
			Order = 2,
			Name = "trademarkInfoRequest")]
		public TrademarkInfoRequest TrademarkInfoRequest { get; set; }

		#endregion

		public ExtensionDataObject ExtensionData { get; set; }

		/// <summary>
		///		Gets the action name.
		/// </summary>
		/// <returns></returns>
		public ActionName GetActionName()
		{
			return PatentTypeDictionaryRequest != null
				? ActionName.PatentTypeDictionaryRequest
				: TrademarkClassiciationDictionaryRequest != null
				? ActionName.TrademarkClassiciationDictionaryRequest
				: TrademarkInfoRequest != null
				? ActionName.TrademarkInfoRequest
				: ActionName.Undefined;
		}
	}
}
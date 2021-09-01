using System.Runtime.Serialization;

namespace Niis.Eokno.Abstractions.Requests.Trademarks
{
	[DataContract(
		Name = "trademarkInfoRequest",
		Namespace = Global.Empty)]
	public class TrademarkInfoRequest
	{
		[DataMember(
			Name = "id",
			Order = 0)]
		public int PatentTypeId { get; set; }

		[DataMember(
			Name = "gosNumber",
			Order = 1)]
		public string GosNumber { get; set; }
	}
}

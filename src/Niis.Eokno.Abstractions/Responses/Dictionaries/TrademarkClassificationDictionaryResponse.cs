using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Dictionaries
{
	[XmlRoot(
		"trademarkClassificationDictionaryResponse",
		Namespace = Global.Empty)]
	public class TrademarkClassificationDictionaryResponse
	{
		[XmlElement(
			"trademarkClassificationType",
			Form = XmlSchemaForm.Unqualified)]
		public TrademarkClassificationType[] TrademarkClassificationTypes { get; set; }
	}
}

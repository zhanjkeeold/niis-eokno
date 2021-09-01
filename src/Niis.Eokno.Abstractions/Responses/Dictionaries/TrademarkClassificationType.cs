using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Dictionaries
{
	[XmlType(
		"trademarkClassificationType",
		Namespace = Global.Empty)]
	public class TrademarkClassificationType
	{
		[XmlElement(
			"id",
			Form = XmlSchemaForm.Unqualified,
			Order = 0)]
		public int Id { get; set; }
		[XmlElement(
			"code",
			Form = XmlSchemaForm.Unqualified,
			Order = 1)]
		public string Code { get; set; }
		[XmlElement(
			"description",
			Form = XmlSchemaForm.Unqualified,
			Order = 2)]
		public string Description { get; set; }
	}
}

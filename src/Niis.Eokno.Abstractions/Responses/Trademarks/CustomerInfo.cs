using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Trademarks
{
	[XmlType(
	"customerInfo",
	Namespace = Global.Empty)]
	public class CustomerInfo
	{
		[XmlElement(
			"xin",
			Form = XmlSchemaForm.Unqualified,
			Order = 0)]
		public string Xin { get; set; }

		[XmlElement(
			"customerType",
			Form = XmlSchemaForm.Unqualified,
			Order = 1)]
		public int CustomerType { get; set; }

		[XmlElement(
			"ownerNameEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 2)]
		public string OwnerNameEn { get; set; }

		[XmlElement(
			"ownerNameRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 3)]
		public string OwnerNameRu { get; set; }

		[XmlElement(
			"ownerNameKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 4)]
		public string OwnerNameKz { get; set; }

		[XmlElement(
			"locationId",
			Form = XmlSchemaForm.Unqualified,
			Order = 5)]
		public int? LocationId { get; set; }

		[XmlElement(
			"location",
			Form = XmlSchemaForm.Unqualified,
			Order = 6)]
		public string Location { get; set; }

		[XmlElement(
			"addressEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 7)]
		public string AddressEn { get; set; }

		[XmlElement(
			"addressRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 8)]
		public string AddressRu { get; set; }

		[XmlElement(
			"addressKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 9)]
		public string AddressKz { get; set; }

		[XmlElement(
			"addressPostCode",
			Form = XmlSchemaForm.Unqualified,
			Order = 10)]
		public string AddressPostCode { get; set; }
	}
}
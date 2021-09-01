using Niis.Eokno.Abstractions.Responses.Dictionaries;
using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Trademarks
{
	[XmlRoot(
		"trademarkInfoResponse",
		Namespace = Global.Empty)]
	public class TrademarkInfoResponse
	{
		[XmlElement(
			"patentId",
			Form = XmlSchemaForm.Unqualified,
			Order = 0)]
		public int PatentId { get; set; }

		[XmlElement(
			"documentId",
			Form = XmlSchemaForm.Unqualified,
			Order = 1)]
		public int DocumentId { get; set; }

		[XmlElement(
			"patentNameEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 2)]
		public string PatentNameEn { get; set; }

		[XmlElement(
			"patentNameRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 3)]
		public string PatentNameRu { get; set; }

		[XmlElement(
			"patentNameKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 4)]
		public string PatentNameKz { get; set; }

		[XmlElement(
			"registrationDate",
			Form = XmlSchemaForm.Unqualified,
			Order = 5)]
		public DateTime? RegistrationDate { get; set; }

		[XmlElement(
			"validityDate",
			Form = XmlSchemaForm.Unqualified,
			Order = 6)]
		public DateTime? ValidityDate { get; set; }

		[XmlElement(
			"image",
			Form = XmlSchemaForm.Unqualified,
			Order = 7)]
		public byte[] Image { get; set; }

		[XmlArray(
			"icgs",
			Form = XmlSchemaForm.Unqualified,
			Order = 8)]
		public TrademarkClassificationType[] TrademarkClassificationTypes { get; set; }

		[XmlArray(
			"owners",
			Form = XmlSchemaForm.Unqualified,
			Order = 9)]
		public CustomerInfo[] Owners { get; set; }

		[XmlArray(
			"contracts",
			Form = XmlSchemaForm.Unqualified,
			Order = 10)]
		public ContractInfo[] Contracts { get; set; }
	}
}
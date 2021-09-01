using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Trademarks
{
	[XmlType(
		"contractInfo",
		Namespace = Global.Empty)]
	public class ContractInfo
	{
		[XmlElement(
			"number",
			Form = XmlSchemaForm.Unqualified,
			Order = 0)]
		public string Number { get; set; }

		[XmlElement(
			"registrationDate",
			Form = XmlSchemaForm.Unqualified,
			Order = 1)]
		public string RegistrationDate { get; set; }

		[XmlElement(
			"contractTypeEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 2)]
		public string ContractTypeEn { get; set; }

		[XmlElement(
			"contractTypeKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 3)]
		public string ContractTypeKz { get; set; }

		[XmlElement(
			"contractTypeRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 4)]
		public string ContractTypeRu { get; set; }

		[XmlElement(
			"subjectEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 5)]
		public string SubjectEn { get; set; }

		[XmlElement(
			"subjectKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 6)]
		public string SubjectKz { get; set; }

		[XmlElement(
			"subjectRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 7)]
		public string SubjectRu { get; set; }

		[XmlElement(
			"side1",
			Form = XmlSchemaForm.Unqualified,
			Order = 8)]
		public string Side1 { get; set; }

		[XmlElement(
			"side2",
			Form = XmlSchemaForm.Unqualified,
			Order = 9)]
		public string Side2 { get; set; }
	}
}
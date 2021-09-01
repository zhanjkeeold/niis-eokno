using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Dictionaries
{
	[XmlRoot(
		"patentType",
		Namespace = Global.Empty)]
	public class PatentType
	{
		[XmlElement(
			"id",
			Form = XmlSchemaForm.Unqualified,
			Order = 0)]
		public int Id { get; set; }

		[XmlElement(
			"nameRu",
			Form = XmlSchemaForm.Unqualified,
			Order = 1)]
		public string NameRu { get; set; }

		[XmlElement(
			"nameEn",
			Form = XmlSchemaForm.Unqualified,
			Order = 2)]
		public string NameEn { get; set; }

		[XmlElement(
			"nameKz",
			Form = XmlSchemaForm.Unqualified,
			Order = 3)]
		public string NameKz { get; set; }
	}
}
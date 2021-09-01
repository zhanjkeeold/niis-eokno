using System.Xml.Schema;
using System.Xml.Serialization;

namespace Niis.Eokno.Abstractions.Responses.Dictionaries
{
	[XmlRoot(
		"patentTypeDictionaryResponse",
		Namespace = Global.Empty)]
	public class PatentTypeDictionaryResponse
	{
		[XmlElement(
			"patentType",
			Form = XmlSchemaForm.Unqualified)]
		public PatentType[] PatentTypes { get; set; }
	}
}

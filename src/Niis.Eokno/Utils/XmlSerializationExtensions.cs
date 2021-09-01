using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Niis.Eokno.Utils
{
	public static class XmlSerializationExtensions
	{
        public static XElement ToXElement<T>(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    var xml = Encoding.UTF8.GetString(memoryStream.ToArray());
                    return XElement.Parse(xml.Replace("&#xC;", ""));
                }
            }
        }
    }
}

using System.Configuration;

namespace Niis.Eokno.Configuration
{
    public sealed class NiisEoknoConfigurationReader
    {
        public NiisEoknoConfiguration Read()
        {
            var configuration = ConfigurationManager.GetSection(NiisEoknoConfiguration.SectionName) as NiisEoknoConfiguration;

            return configuration;
        }
    }
}

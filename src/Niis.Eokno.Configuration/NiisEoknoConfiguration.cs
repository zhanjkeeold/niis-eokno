using System.Configuration;

namespace Niis.Eokno.Configuration
{
    public class NiisEoknoConfiguration : ConfigurationSection
    {
        /// <summary>
        ///     Названия секции.
        /// </summary>
        public const string SectionName = "NiisEoknoSettings";

        private const string WebAddressKey = "webAddress";
        private const string ConnectionStringKey = "connectionString";

        /// <summary>
        ///     Адрес сервиса.
        /// </summary>
        [ConfigurationProperty(WebAddressKey, IsRequired = true)]
        public string WebAddress
        {
            get => this[WebAddressKey].ToString();
            set => this[WebAddressKey] = value;
        }

        /// <summary>
        ///     Строка подключения к базе данных.
        /// </summary>
        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionString
        {
            get => this[ConnectionStringKey].ToString();
            set => this[ConnectionStringKey] = value;
        }
    }
}

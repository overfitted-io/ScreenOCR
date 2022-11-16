using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ScreenOCR
{
    class Config
    {
        public static readonly String CONFIG_PATH = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private const String CONFIG_NAME = "config.xml";


        public static String getConfigPath()
        {
            return CONFIG_PATH;
        }

        /// <summary>
        /// Parses local XML config and returns content in a dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, String> loadConfig()
        {
            XmlDocument xmldoc = new XmlDocument();

            try
            {
                xmldoc.Load(CONFIG_PATH + "/" + CONFIG_NAME);

                XmlNode langNode = xmldoc.SelectSingleNode("/config/lang");
                String lang = langNode.InnerText;

                XmlNode apiKeyNode = xmldoc.SelectSingleNode("/config/api_key");
                String apiKey = apiKeyNode.InnerText;

                XmlNode startupNode = xmldoc.SelectSingleNode("/config/startup");
                String startup = apiKeyNode.InnerText;

                return new Dictionary<string, string> () { { "api_key", apiKey }, { "lang", lang }, { "startup", "y" } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, string>() { { "api_key", "" }, { "lang", "" }, { "startup", "n" }, { "err", ex.Message } };
            }
        }

        /// <summary>
        /// Receives current config and saves it as an XML file
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="apiKey"></param>
        /// <param name="startup"></param>
        public static void saveConfig(String lang, String apiKey, String startup)
        {
            using (XmlWriter writer = XmlWriter.Create(CONFIG_PATH + "/" + CONFIG_NAME))
            {
                writer.WriteStartElement("config");
                writer.WriteElementString("lang", lang);
                writer.WriteElementString("api_key", apiKey);
                writer.WriteElementString("startup", startup);
                writer.WriteEndElement();
                writer.Flush();
            }
        }
    }
}

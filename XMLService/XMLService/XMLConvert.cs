using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XMLService
{
    public static class XMLConvert
    {
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static T DeserializeObject<T>(string xmlstr)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            Stream st = GenerateStreamFromString(xmlstr);
            XmlReader reader = XmlReader.Create(st);

            T obj;

            obj = (T)serializer.Deserialize(reader);
            st.Close();
            return obj;
        }

        private static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

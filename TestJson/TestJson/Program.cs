using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestJson
{
    class Program
    {
        static void Main(string[] args)
        {

            string xml = string.Empty;

            using (StreamReader sr = new StreamReader(@"C:\Projects\LoanCalculatorService\Test.xml"))
            {
                xml = sr.ReadToEnd();
            }

            var sched = DeserializeObject<schedule>(xml);

            var stuff = Serialize<schedule>(sched);

            

            string json = string.Empty;

            using (StreamReader sr = new StreamReader(@"C:\Projects\LoanCalculatorService\Team.txt"))
            {
                json = sr.ReadToEnd();
            }

            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);

            using (StreamReader sr = new StreamReader(@"C:\Projects\LoanCalculatorService\Json.txt"))
            {
                json = sr.ReadToEnd();
            }

            LoanSchedule ls = JsonConvert.DeserializeObject<LoanSchedule>(json);


            Console.ReadKey();
        }

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

        private static T DeserializeObject<T>(string xmlstr)
        {
            // Console.WriteLine("Reading with XmlReader");

            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            // A FileStream is needed to read the XML document.
            Stream st = GenerateStreamFromString(xmlstr);
            XmlReader reader = XmlReader.Create(st);

            // Declare an object variable of the type to be deserialized.
            T i;

            // Use the Deserialize method to restore the object's state.
            i = (T)serializer.Deserialize(reader);
            st.Close();
            return i;
        }

        public static Stream GenerateStreamFromString(string s)
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

using System;
using System.Net;
using System.Xml;
using XMLService;

namespace EatRESTMortCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest req = WebRequest.Create(@"http://localhost:4030/ScheduleXML?Amount=100000&Intrest=.08&Length=30");
            req.Method = "GET";
            req.ContentType = @"application/xml; charset=utf-8";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument myXMLDocument = new XmlDocument();
                XmlReader myXMLReader = new XmlTextReader(resp.GetResponseStream());
                myXMLDocument.Load(myXMLReader);

                var json = myXMLDocument.InnerText;
                var sched = XMLConvert.DeserializeObject<schedule>(json);
                var stuff = XMLConvert.Serialize<schedule>(sched);

                Console.WriteLine(myXMLDocument.InnerText);
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LoanCalculatorService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoanCalculatorService : ILoanCalculatorService
    {
       [WebGet(UriTemplate = "/Payment?Amount={pAmount}&Intrest={pIntrestRate}&Length={pLength}", ResponseFormat = WebMessageFormat.Json)]
       public string GetPayment(decimal pAmount, double pIntrestRate, double pLength)
       {
           decimal result = Calculation.GetPayment(pAmount, pIntrestRate, pLength);

           return result.ToString(CultureInfo.InvariantCulture);
       }

       [WebGet(UriTemplate = "/Schedule?Amount={pAmount}&Intrest={pIntrestRate}&Length={pLength}", ResponseFormat = WebMessageFormat.Json)]
       public string GetLoanSchedule(decimal pAmount, double pIntrestRate, double pLength)
       {
           string json = Calculation.PaymentSchedule(pAmount, pIntrestRate, pLength);

           //var sched = JsonConvert.DeserializeObject<LoanSchedule>(json);

           return json;
       }

       [WebGet(UriTemplate = "/ScheduleXML?Amount={pAmount}&Intrest={pIntrestRate}&Length={pLength}", ResponseFormat = WebMessageFormat.Xml)]
       public string GetLoanScheduleXML(decimal pAmount, double pIntrestRate, double pLength)
       {
           string json = Calculation.PaymentScheduleXML(pAmount, pIntrestRate, pLength);

           //var sched = DeserializeObject<schedule>(json);
           //var stuff = Serialize<schedule>(sched);
           return json;
       }

       [WebGet(UriTemplate = "/FuckIt?Amount={pAmount}&Intrest={Intrest}", ResponseFormat = WebMessageFormat.Json)]
       public string FuckIt(decimal pAmount, double Intrest)
       {
           return "Hi! + " + pAmount.ToString() + "-" + Intrest.ToString();
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

       private T DeserializeObject<T>(string xmlstr)
       {
            // Console.WriteLine("Reading with XmlReader");

            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new
                XmlSerializer(typeof(T));

            // A FileStream is needed to read the XML document.
            Stream st = GenerateStreamFromString(xmlstr);
            XmlReader reader = XmlReader.Create(st);

            // Declare an object variable of the type to be deserialized.
            T i;

            // Use the Deserialize method to restore the object's state.
            i = (T)serializer.Deserialize(reader);
            st.Close();

            // Write out the properties of the object.
            //Console.Write(
            //i.ItemName + "\t" +
            //i.Description + "\t" +
            //i.UnitPrice + "\t" +
            //i.Quantity + "\t" +
            //i.LineTotal);

           return i;
       }

       public Stream GenerateStreamFromString(string s)
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

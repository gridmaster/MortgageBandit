using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestJson
{
    [XmlRoot("schedule")]
    public class Schedulexxx
    {
        [XmlArray(ElementName = "payment")]
        public List<XMLPaymentsxxx> schedulexxx { get; set; }
    }

    public class XMLPaymentsxxx
    {
        public int PaymentNo { get; set; }
        public double Ballance { get; set; }
        public double Principal { get; set; }
        public double Intrest { get; set; }
        public double Payment { get; set; }
    }
}

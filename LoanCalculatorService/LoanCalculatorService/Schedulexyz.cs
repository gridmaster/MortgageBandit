using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoanCalculatorService
{
    [XmlRoot("schedule")]
    public class Schedulexyz
    {
        [XmlArray(ElementName = "payment")]
        public List<XMLPayments> schedule { get; set; }
    }

    public class XMLPayments
    {
        public int PaymentNo { get; set; }
        public double Ballance { get; set; }
        public double Principal { get; set; }
        public double Intrest { get; set; }
        public double Payment { get; set; }
    }
}

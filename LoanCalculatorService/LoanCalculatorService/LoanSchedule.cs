using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LoanCalculatorService
{
    [XmlRoot("schedule")]
    public class LoanSchedule
    {
        public List<Payments> schedule { get; set; }
    }

    public class Payments
    {
        public int PaymentNo { get; set; }
        public double Ballance { get; set; }
        public double Principal { get; set; }
        public double Intrest { get; set; }
        public double Payment { get; set; }
    }
}

//PaymentNo\": {0}, \"Ballance\": {1:F}, \"Principal\": {2:F}, \"Intrest\": {3:F}, \"Payment\

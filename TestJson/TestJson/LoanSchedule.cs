
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestJson
{
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

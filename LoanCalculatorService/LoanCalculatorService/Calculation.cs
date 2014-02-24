using System;
/*
{ "schedule": {
    "Payments": [ 
	{ "PaymentNo": 1, "Ballance": 99932.91, "Principal": 67.09, "Intrest": 666.67, "Payment": 733.76},
	{ "PaymentNo": 2, "Ballance": 99865.37, "Principal": 67.54, "Intrest": 666.22, "Payment": 733.76},

	{ "PaymentNo": 360, "Ballance": 6.85, "Principal": 728.86, "Intrest": 4.90, "Payment": 733.76},
	{ "PaymentNo": 361, "Ballance": 6.85, "Principal": 6.80, "Intrest": 0.05, "Payment": 6.85} 
 ] 
}}
*/
namespace LoanCalculatorService
{
    public static class Calculation
    {
        public static string PaymentSchedule(decimal mAmount, double mIntrestRate, double mLength)
        {
            decimal amount = mAmount;
            decimal payment = Calculation.GetPayment(mAmount, .08, 30);
            int paynum = 1;
            string result = "{ \"Schedule\": [ ";

            do
            {
                result += RunLoanSchedule(ref paynum, ref amount, .08, 30, payment, false);
            } while (amount > 0);
            result += " ] }";
            return result;
        }

        public static string PaymentScheduleXML(decimal mAmount, double mIntrestRate, double mLength)
        {
            decimal amount = mAmount;
            decimal payment = Calculation.GetPayment(mAmount, .08, 30);
            int paynum = 1;
            string result = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><schedule>";

            do
            {
                result += RunLoanSchedule(ref paynum, ref amount, .08, 30, payment, true);
            } while (amount > 0);
            result += "</schedule>";
            return result;
        }

        public static decimal GetPayment(decimal mAmount = 0, double mIntrestRate = 0, double mLength = 0)
        {
            double PVal = 0;
            double APR = 0;
            double TotPmts = 0;
            double Payment = 0;
            double PointOh = 0;

            PVal = Convert.ToDouble(mAmount);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR / 100; // Ensure proper form.
            }

            TotPmts = mLength * 12;

            // here is the actual formula!
            PointOh = 1 + (APR * 100) / 1200;
            Payment = (PVal * (APR * 100) * (Math.Pow(PointOh, TotPmts))) / (1200 * (Math.Pow(PointOh, TotPmts) - 1));

            return Math.Round(System.Convert.ToDecimal(Payment), 2);
        }

        public static string RunLoanSchedule(ref int paynum, ref decimal mAmount, double mIntrestRate, double mLength,
                                             decimal mpayment, bool xml)
        {
            double PVal = 0;
            double APR = 0;
            double Payment = 0;
            decimal Intrest = 0;
            decimal Principal = 0;

            Payment = Convert.ToDouble(mpayment);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR/100; // Ensure proper form.
            }
            PVal = Convert.ToDouble(mAmount);
            Intrest = Math.Round(System.Convert.ToDecimal(PVal*(APR)/12), 2);
            Principal = Math.Round(System.Convert.ToDecimal(Payment - System.Convert.ToDouble(Intrest)), 2);

            if (Payment > (double) mAmount)
            {
                Payment = (double) (mAmount);
                Principal = Math.Round(Convert.ToDecimal(Payment - (double) Intrest), 2);
                // Console.WriteLine("{0}: {1:F} - {2:F} - {3:F} - {4:F}", paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                string lastOne = string.Empty;

                if (xml)
                {
                    lastOne =
                        string.Format(
                            "<payment><PaymentNo>{0}</PaymentNo><Ballance>{1:F}</Ballance><Principal>{2:F}</Principal><Intrest>{3:F}</Intrest><Payment>{4:F}</Payment></payment>",
                            paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                    mAmount = 0;
                    return lastOne;
                }
                else
                {
                    lastOne =
                        string.Format(
                            "\"PaymentNo\": {0}, \"Ballance\": {1:F}, \"Principal\": {2:F}, \"Intrest\": {3:F}, \"Payment\": {4:F}",
                            paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                    mAmount = 0;
                    return "{ " + lastOne + "},";
                }
           }

            mAmount = System.Convert.ToDecimal(mAmount) - Math.Round(System.Convert.ToDecimal(Principal), 2);
            string result = string.Empty;

            if (xml)
            {
                result =
                    string.Format(
                        "<payment><PaymentNo>{0}</PaymentNo><Ballance>{1:F}</Ballance><Principal>{2:F}</Principal><Intrest>{3:F}</Intrest><Payment>{4:F}</Payment></payment>",
                        paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                return result;
            }
            else
            {
                result =
                    string.Format(
                        "\"PaymentNo\": {0}, \"Ballance\": {1:F}, \"Principal\": {2:F}, \"Intrest\": {3:F}, \"Payment\": {4:F}",
                        paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                return "{ " + result + "},";
            }
        }

        public static decimal RunLoan(ref int paynum, decimal mAmount, double mIntrestRate, double mLength, decimal mpayment)
        {
            double PVal = 0;
            double APR = 0;
            double Payment = 0;
            decimal Intrest = 0;
            decimal Principal = 0;

            Payment = Convert.ToDouble(mpayment);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR / 100; // Ensure proper form.
            }
            PVal = Convert.ToDouble(mAmount);
            Intrest = Math.Round(System.Convert.ToDecimal(PVal * (APR) / 12), 2);
            Principal = Math.Round(System.Convert.ToDecimal(Payment - System.Convert.ToDouble(Intrest)), 2);

            if (Payment > (double)mAmount)
            {
                Payment = (double)(mAmount);
                Principal = Math.Round(Convert.ToDecimal(Payment - (double)Intrest), 2);
                Console.WriteLine("{0}: {1:F} - {2:F} - {3:F} - {4:F}", paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));
                return 0;
            }

            Console.WriteLine("{0}-{1:F}-{2:F}-{3:F}-{4:F}", paynum++, mAmount, Principal, Intrest, Math.Round(Convert.ToDecimal(Payment), 2));

            decimal result = System.Convert.ToDecimal(mAmount) - Math.Round(System.Convert.ToDecimal(Principal), 2);

            return result;
        }


        public static decimal Calculate(decimal mAmount = 0, double mIntrestRate = 0, double mLength = 0)
        {
            double PVal = 0;
            double APR = 0;
            double TotPmts = 0;
            double Payment = 0;
            decimal Intrest = 0;
            decimal Principal = 0;
            double PointOh = 0;
            double PointOhOne = 0;
            int PayType = 0;
            string cFormat = string.Empty;

            string m_LengthInterval = "Years";
            int m_Beginning = 0;

            //UpdateData(TRUE);
            //if (m_Amount == 0) return;
            //if (m_IntrestRate == 0) return;
            //if (m_Length == 0) return;

            //Fmt = "###,###,##0.00"; // Define money format.
            //FVal = 0; // Usually 0 for a loan.
            PVal = Convert.ToDouble(mAmount);
            APR = mIntrestRate;

            if (APR > 1)
            {
                APR = APR / 100; // Ensure proper form.
            }

            TotPmts = mLength;
            if (m_LengthInterval == "Years")
            {
                TotPmts = TotPmts * 12;
            }


            if (m_Beginning == 0)
            {
                PayType = 1; // BEGINPERIOD
            }
            else
            {
                PayType = 0; // ENDPERIOD
            }

            // here is a function that derives the payment...
            // Payment = Pmt(APR / 12, TotPmts, -PVal, FVal, PayType)

            // here is the actual formula!
            PointOh = 1 + (APR * 100) / 1200;
            PointOhOne = Math.Pow(PointOh, TotPmts);
            Payment = (PVal * (APR * 100) * (Math.Pow(PointOh, TotPmts))) / (1200 * (Math.Pow(PointOh, TotPmts) - 1));
            //Console.WriteLine(cFormat, "%0.2f", Payment);

            // Payment = System.Convert.ToDouble(cFormat);
            decimal m_Payment = Math.Round(System.Convert.ToDecimal(Payment), 2);

            //m_Payment = m_Payment.To

            //Amortize TotPmts, PVal, APR, TxtPayment.Text

            Intrest = Math.Round(System.Convert.ToDecimal(PVal * (APR) / 12), 2);
            Principal = Math.Round(System.Convert.ToDecimal(Payment - System.Convert.ToDouble(Intrest)), 2);
            Console.WriteLine("1 - {0} - {1} - {2}", Math.Round(System.Convert.ToDecimal(Payment), 2), Intrest, Principal);

            decimal result = System.Convert.ToDecimal(mAmount) - Math.Round(System.Convert.ToDecimal(Principal), 2);

            return result;

            //m_LstSchedule.AddString(cFormat);

            //UpdateData(FALSE);

            //FillListCtrl();

            //UpdateData(FALSE);

            /*
            Example.  Find the monthly repayments on a loan of $20,000 over 15 
            years at 12 percent per year compound interest.

            Here we have n = 12*15 = 180 months, r = 12, and L = 20000.
            We want to find P.

            1+r/1200 = 1 + 12/1200 = 1.01   and the above formula becomes


                   P = {20000*12*1.01^180}/{1200*(1.01^180 - 1)}

                     = {20000*12*5.99}/{1200*(5.99 - 1)}

                     = 1437600/5988
 
                     = $240.08
            */

        }

    }
}
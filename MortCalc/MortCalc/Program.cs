using System;

namespace MortCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amount = 100000;
            decimal result = 100000;
            decimal payment = Calculation.GetPayment(amount, .08, 30);
            int paynum = 1;

            do
            {
                amount = result; 

                result = Calculation.RunLoan(ref paynum, amount, .08, 30, payment);
            } while( result > 0);

            Console.ReadKey();
        }
    }
}

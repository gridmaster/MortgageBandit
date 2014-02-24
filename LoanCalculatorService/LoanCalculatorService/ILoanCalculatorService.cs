using System.ServiceModel;

namespace LoanCalculatorService
{
    [ServiceContract]
    interface ILoanCalculatorService
    {
        [OperationContract]
        string GetPayment(decimal pAmount, double pIntrestRate, double pLength);

        [OperationContract]
        string GetLoanSchedule(decimal pAmount, double pIntrestRate, double pLength);

        [OperationContract]
        string GetLoanScheduleXML(decimal pAmount, double pIntrestRate, double pLength);
    }
}

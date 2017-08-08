using System.Collections.Generic;

namespace SwEngHomework.Commissions
{
    public interface ICommissionCalculator
    {
        Dictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput);
    }
}

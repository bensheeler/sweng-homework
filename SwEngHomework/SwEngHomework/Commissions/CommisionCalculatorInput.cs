using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwEngHomework.Commissions
{
    public class CommisionCalculatorInput
    {
        public IEnumerable<Advisor> Advisors { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}

using System;
using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test) : base(test)
        {
        }

        internal BudgetCreatePage Amount(int amount)
        {
            throw new NotImplementedException();
        }

        internal BudgetCreatePage Month(string yearMonth)
        {
            throw new NotImplementedException();
        }

        internal BudgetCreatePage AddBudget()
        {
            throw new NotImplementedException();
        }

        internal BudgetCreatePage ShouldDisplay(object message)
        {
            throw new NotImplementedException();
        }
    }
}
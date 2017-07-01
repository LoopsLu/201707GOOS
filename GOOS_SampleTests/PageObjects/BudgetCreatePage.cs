using System;
using FluentAutomation;
using GOOS_SampleTests.PageObjects;

namespace GOOS_SampleTests.PageObjects
{
    internal class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/budget/add";
        }

        internal BudgetCreatePage Amount(int amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        internal BudgetCreatePage Month(string yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        internal void AddBudget()
        {
            I.Click("input[type=\"submit\"]");
        }

        internal void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}
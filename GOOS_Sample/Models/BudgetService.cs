using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budget> _budgetRepositoryStub;

        public BudgetService(IRepository<Budget> _budgetRepositoryStub)
        {
            this._budgetRepositoryStub = _budgetRepositoryStub;
        }

        public void Create(BudgetAddViewModel model)
        {
            using (var dbcontext = new GOOSDbEntitiesProduction())
            {
                var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}
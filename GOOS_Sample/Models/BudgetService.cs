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
        private IRepository<Budget> _budgetRepository;

        public BudgetService(IRepository<Budget> _budgetRepository)
        {
            this._budgetRepository = _budgetRepository;
        }

        public event EventHandler Created;
        public event EventHandler Updated;

        public void Create(BudgetAddViewModel model)
        {
            // var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
            // _budgetRepositoryStub.Save(budget);


            var budget = this._budgetRepository.Read(x => x.YearMonth == model.Month);
            if (budget == null)
            {
                this._budgetRepository.Save(new Budget() { Amount = model.Amount, YearMonth = model.Month });

                var handler = this.Created;
                handler?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                budget.Amount = model.Amount;
                this._budgetRepository.Save(budget);

                var handler = this.Updated;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
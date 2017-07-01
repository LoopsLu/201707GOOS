using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;
using System;
using System.Linq;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budget>
    {
        public void Save(Budget entity)
        {
            using (var dbcontext = new GOOSDbEntitiesProduction())
            {
                var budgetFromDb = dbcontext.Budgets.FirstOrDefault(x => x.YearMonth == entity.YearMonth);

                if (budgetFromDb == null)
                {
                    dbcontext.Budgets.Add(entity);
                }
                else
                {
                    budgetFromDb.Amount = entity.Amount;
                }

                dbcontext.SaveChanges();
            }
        }

        public Budget Read(Func<Budget, bool> predicate)
        {
            using (var dbcontext = new GOOSDbEntitiesProduction())
            {
                var firstBudget = dbcontext.Budgets.FirstOrDefault(predicate);
                return firstBudget;
            }
        }
    }
}
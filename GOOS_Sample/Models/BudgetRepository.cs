using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;
using System;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budget>
    {
        public void Save(Budget entity)
        {
            using (var dbcontext = new GOOSDbEntitiesProduction())
            {
                dbcontext.Budgets.Add(entity);
                dbcontext.SaveChanges();
            }
        }
    }
}
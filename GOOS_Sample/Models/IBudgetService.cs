using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOOS_Sample.Models.ViewModels;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel budgetAddViewModel);
    }
}

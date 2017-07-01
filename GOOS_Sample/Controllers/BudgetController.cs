using GOOS_Sample.Models.DataModels;
using GOOS_Sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            // If...else 放到service中寫，並且由service引發事件
            // 而事件的委派內容由Controller決定
            // 如果把if...else寫在controller中，有20個地方要用到，每一次都要加if...else
            this.budgetService.Created += (sender, e) => { ViewBag.Message = "added successfully"; };
            this.budgetService.Updated += (sender, e) => { ViewBag.Message = "updated successfully"; };

            budgetService.Create(model);
            return View(model);
        }
    }
}
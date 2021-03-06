﻿using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_SampleTests.DataModelsForIntegrationTest;
using GOOS_SampleTests.Steps.Common;
using System;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Practices.Unity;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class BudgetControllerSteps
    {
        private BudgetController _budgetController;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _budgetController = Hooks.UnityContainer.Resolve<BudgetController>();
        }

        [When(@"add a budget")]
        public void WhenAddABudget(Table table)
        {
            var model = table.CreateInstance<BudgetAddViewModel>();
            var result = this._budgetController.Add(model);

            ScenarioContext.Current.Set<ActionResult>(result);
        }
        
        [Then(@"ViewBag should have a message for adding successfully")]
        public void ThenViewBagShouldHaveAMessageForAddingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetAddingSuccessfullyMessage());
        }
        
        [Then(@"it should exist a budget record in budget table")]
        public void ThenItShouldExistABudgetRecordInBudgetTable(Table table)
        {
            using (var dbcontext = new GOOSDbEntities())
            {
                var budget = dbcontext.Budgets
                    .FirstOrDefault();
                budget.Should().NotBeNull();
                table.CompareToInstance(budget);
            }
        }

        private static string GetAddingSuccessfullyMessage()
        {
            return "added successfully";
        }

        [Then(@"ViewBag should have a message for updating successfully")]
        public void ThenViewBagShouldHaveAMessageForUpdatingSuccessfully()
        {
            var result = ScenarioContext.Current.Get<ActionResult>() as ViewResult;
            string message = result.ViewBag.Message;
            message.Should().Be(GetUpdatingSuccessfullyMessage());
        }

        private string GetUpdatingSuccessfullyMessage()
        {
            return "updated successfully";
        }
    }
}

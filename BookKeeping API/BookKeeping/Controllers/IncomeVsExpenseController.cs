using BookKeeping.DataAccess.Entitties;
using BookKeeping.DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BookKeeping.WebApi.Controllers
{
    [Route("IncomeVsExpense")]
    public class IncomeVsExpenseController : Controller
    {

        private readonly IIncomeVsExpenseRepository _incomeVsExpenseRepository;
        public IncomeVsExpenseController(IIncomeVsExpenseRepository incomeVsExpenseRepository)
        {
            _incomeVsExpenseRepository = incomeVsExpenseRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetIncomeVsExpenseData")]
        public async Task<IActionResult> GetIncomeVsExpenseData(int year)
        {
            var data = await _incomeVsExpenseRepository.GetIncomeVsExpense(year);
            var income = data.Where(x => x.TypeId == 1).FirstOrDefault();
            var cost = data.Where(x => x.TypeId == 2).FirstOrDefault();
            var list = new List<IncomeVsExpense>();
            list.Add(income ?? new IncomeVsExpense());
            var incomeList = generateListFromObject(income ?? new IncomeVsExpense());
            var commulativeIncome = GetCommulativeSumForAllColumn(incomeList);
            list.Add(commulativeIncome);
            list.Add(cost ?? new IncomeVsExpense());
            var costList = generateListFromObject(cost ?? new IncomeVsExpense());
            var commulativeCost = GetCommulativeSumForAllColumn(costList);
            list.Add(commulativeCost);
            var result = GetResultOfInComeVsExpense(incomeList, costList);
            list.Add(result);
            return Ok(list);

        }

        private List<Decimal> generateListFromObject(IncomeVsExpense model)
        {
            var list = new List<Decimal>();

            list.Add(model.January ?? 0);
            list.Add(model.February ?? 0);
            list.Add(model.March ?? 0);
            list.Add(model.April ?? 0);
            list.Add(model.May ?? 0);
            list.Add(model.June ?? 0);
            list.Add(model.July ?? 0);
            list.Add(model.August ?? 0);
            list.Add(model.September ?? 0);
            list.Add(model.October ?? 0);
            list.Add(model.November ?? 0);
            list.Add(model.December ?? 0);

            return list;
        }
        private IncomeVsExpense GetCommulativeSumForAllColumn(List<decimal> incomeList)
        {
            var record = new IncomeVsExpense();
            PropertyInfo[] properties = typeof(IncomeVsExpense).GetProperties();
            decimal sum = 0;
            for (var i = 2; i < properties.Count() - 1; i++)
            {
                sum += incomeList[i - 2];
                properties[i].SetValue(record, sum);
            }

            return record;
        }
        private IncomeVsExpense GetResultOfInComeVsExpense(List<decimal> income, List<decimal> Expense)
        {
            var record = new IncomeVsExpense();
            PropertyInfo[] properties = typeof(IncomeVsExpense).GetProperties();
            decimal sum = 0;
            for (var i = 2; i < properties.Count() - 1; i++)
            {
                sum = income[i - 2] - Expense[i - 2];
                properties[i].SetValue(record, sum);
            }

            return record;
        }
    }
}

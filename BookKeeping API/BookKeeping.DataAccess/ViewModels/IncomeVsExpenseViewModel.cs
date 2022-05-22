using BookKeeping.DataAccess.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookKeeping.DataAccess.ViewModels
{
    public class IncomeVsExpenseModel : IncomeVsExpense
    {
        public string Name { get; set; }
    }
    public class IncomeVsExpenseViewModel
    {
       
        public List<IncomeVsExpense> IncomeVsExpenseList { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookKeeping.DataAccess.Entitties
{
    public class IncomeVsExpenseType
    {
        public int Id { get; set; }
        public bool IsIncome { get; set; }
        public bool IsExpense { get;set; }
        public int ItemType { get; set; }
    }
}

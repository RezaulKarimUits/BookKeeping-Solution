using BookKeeping.DataAccess.Entitties;
using BookKeeping.FrameWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.DataAccess.Repository
{
    public interface IIncomeVsExpenseRepository
    {
        Task<ResponseModel> Save(IncomeVsExpense model);
        Task<List<IncomeVsExpense>> GetIncomeVsExpense(int year);
        Task<ResponseModel> SaveType(IncomeVsExpenseType model);
    }
}

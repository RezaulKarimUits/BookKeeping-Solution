using BookKeeping.DataAccess.Entitties;
using BookKeeping.FrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.DataAccess.Repository.Implementation
{
    public class IncomeVsExpenseRepository : IIncomeVsExpenseRepository
    {
        private readonly PortalDBContext _dbContext;
        public IncomeVsExpenseRepository(PortalDBContext dBContext)
        {
            _dbContext = dBContext;

        }
        public async Task<List<IncomeVsExpense>> GetIncomeVsExpense(int year)
        {
            var data = await _dbContext.IncomeVsExpense.Where(x => x.Year == year).ToListAsync();
            
            return data;
        }

        public async Task<ResponseModel> Save(IncomeVsExpense model)
        {

            await _dbContext.AddAsync(model);

            var result = await _dbContext.SaveChangesAsync();


            return new ResponseModel { Success = result > 0 ? true : false, Message = result > 0 ? "Saved Successfully" : "Error In Save" };


        }
        public async Task<ResponseModel> SaveType(IncomeVsExpenseType model)
        {

            await _dbContext.AddAsync(model);

            var result = await _dbContext.SaveChangesAsync();


            return new ResponseModel { Success = result > 0 ? true : false, Message = result > 0 ? "Saved Successfully" : "Error In Save" };


        }
    }
}

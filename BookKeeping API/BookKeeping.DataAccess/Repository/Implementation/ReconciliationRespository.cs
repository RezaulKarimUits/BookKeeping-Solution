using BookKeeping.DataAccess.Entitties;
using BookKeeping.FrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookKeeping.FrameWork.ApplicationConstant;

namespace BookKeeping.DataAccess.Repository.Implementation
{

    public class ReconciliationRespository : IReconciliationRepository
    {
        private readonly PortalDBContext _dBContext;
        public ReconciliationRespository(PortalDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<Reconciliation>> GetAll(int year)
        {
            var data = await _dBContext.Reconciliation.Where(x => x.Year == year).ToListAsync();

            return data;
        }

        public async Task<ResponseModel> Save(List<Reconciliation> model)
        {
            
            foreach(var entity in model)
            {
                if(entity.Id == 0)
                {
                    _dBContext.Add(entity);
                }
                else
                {
                    _dBContext.Update(entity);
                }
            }
            var result = await _dBContext.SaveChangesAsync();

            return new ResponseModel { Success = result > 0 ? true : false };
        }

        public async Task<List<Reconciliation>> InitializeReconciliationData(int year)
        {
            var data = await _dBContext.Reconciliation.Where(x => x.Year == year).ToListAsync();
            var list = new List<Reconciliation>();
            if (data.Count == 0)
            {
                var result = await _dBContext.IncomeVsExpenseType.Where(x => x.Id > 0).OrderBy(x => x.ItemType).ToListAsync();

                var incomeList = result.Where(x => x.IsIncome == true).ToList();
                var costList = result.Where(x => x.IsExpense == true).ToList();
                foreach (var item in incomeList)
                {
                    list.Add(new Reconciliation { TypeId = item.ItemType,Year = year, StatusId = (int)IncomeExpenseStatus.Income });
                }
                foreach (var item in costList)
                {
                    list.Add(new Reconciliation { TypeId = item.ItemType,Year = year, StatusId = (int)IncomeExpenseStatus.Expense });
                }

            }
            return data.Count == 0 ? list : data;
        }
    }
}

using BookKeeping.DataAccess.Entitties;
using BookKeeping.FrameWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.DataAccess.Repository
{
    public interface IReconciliationRepository
    {
        Task<ResponseModel> Save(List<Reconciliation> model);
        Task<List<Reconciliation>> GetAll(int year);
        Task<List<Reconciliation>> InitializeReconciliationData(int year);
    }
}

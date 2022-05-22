using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookKeeping.DataAccess.Entitties
{
    public class PortalDBContext : DbContext
    {
        public PortalDBContext(DbContextOptions<PortalDBContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<IncomeVsExpense> IncomeVsExpense { get; set; }
        public virtual DbSet<IncomeVsExpenseType> IncomeVsExpenseType { get; set; }
        public virtual DbSet<Reconciliation> Reconciliation{ get; set; }
    }
}
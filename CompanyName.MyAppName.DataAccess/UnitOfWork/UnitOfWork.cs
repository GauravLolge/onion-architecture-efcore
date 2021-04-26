using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CompanyName.MyAppName.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext context;
        private readonly IDbContextTransaction dbContextTransaction = null;

        public UnitOfWork(AppDBContext context)
        {
            this.context = context;
        }

        public AppDBContext AppDbContext
        {
            get
            {
                if (context == null)
                {
                    context = new AppDBContext();
                }

                return context;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            if(dbContextTransaction == null)
            {
                context.Database.BeginTransaction();
            }
        }

        public void RollbackTransaction()
        {
            if (dbContextTransaction == null)
            {
                context.Database.RollbackTransaction();
            }
        }

        public void Commit()
        {
            if (dbContextTransaction == null)
            {
                context.Database.CommitTransaction();
            }
        }
    }
}

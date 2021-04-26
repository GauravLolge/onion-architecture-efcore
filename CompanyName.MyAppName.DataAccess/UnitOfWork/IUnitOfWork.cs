using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.MyAppName.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        AppDBContext AppDbContext { get; }

        void Save();

        void BeginTransaction();

        void RollbackTransaction();

        void Commit();

    }
}

using Microsoft.EntityFrameworkCore.Storage;
using RemAcademy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RemAcademyDbContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork(RemAcademyDbContext db)
        {
            _db = db;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
            throw new NotImplementedException();
        }

        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
            // Garbage Collector
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}

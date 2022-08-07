using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_AccessModel.Repositories.Auth;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Interfaces.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesManagement.DataAccess.Repositories;
using UtilitiesManagement.Domain.Interfaces;

namespace El_Lo2ma_AccessModel.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lo2maContext _DbCon;
        public IUserRepository Users { get; private set; }
        public UnitOfWork(Lo2maContext DbCon)
        {
            _DbCon = DbCon;
            Users = new UserRepository(_DbCon);
        }

        public IDatabaseTransaction BeginTransaction() => new EntityDatabaseTransaction(_DbCon);

        public async Task<int> CompleteAsync() => await _DbCon.SaveChangesAsync();

        public void Dispose() => _DbCon.Dispose();

        public int Complete() => _DbCon.SaveChanges();
    }
}

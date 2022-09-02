using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_AccessModel.Repositories.Auth;
using El_Lo2ma_AccessModel.Repositories.Chief;
using El_Lo2ma_AccessModel.Repositories.Clients;
using El_Lo2ma_AccessModel.Repositories.Delivery;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Interfaces.Auth;
using El_Lo2ma_DomainModel.Interfaces.Chief;
using El_Lo2ma_DomainModel.Interfaces.Clients;
using El_Lo2ma_DomainModel.Interfaces.Delivery;
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

        public IAchievmentsRepository Achievments { get; set; }

        public IRoleRepository Role { get; set; }

        public IUserLoginsRepository UserLogins { get; set; }

        public IUserRepository User { get; set; }

        public IUserRoleRepository UserRole { get; set; }

        public IUserTokenRepository UserToken { get; set; }

        public IUserTypeRepository UserType { get; set; }

        public IChiefPaymentRepository ChiefPayment { get; set; }

        public IFeastRepository Feast { get; set; }

        public IGradientsRepository Gradients { get; set; }

        public INegociationFeastRepository NegociationFeast { get; set; }

        public ISofraRepository Sofra { get; set; }

        public IDiscountsRepository Discounts { get; set; }

        public IMeelRepository Meel { get; set; }

        public IOrderDettailsRepository OrderDettails { get; set; }

        public IOrderRepository Order { get; set; }

        public ITongueMeelRepository TongueMeel { get; set; }

        public ITransactionLocationRepository TransactionLocation { get; set; }

        public IDeliveryPaymentRepository DeliveryPayment { get; set; }

        public IRefreshToken RefreshTokens { get; set; }

        public IAuthCodeRepository AuthCode { get; set; }

        public UnitOfWork(Lo2maContext DbCon)
        {
            _DbCon = DbCon;
            Achievments = new AchievementsRepository(_DbCon);
            Role = new RoleRepository(_DbCon);
            UserLogins = new UserLoginsRepository(_DbCon);
            User = new UserRepository(_DbCon);
            UserRole = new UserRoleRepository(_DbCon);
            UserToken = new UserTokenRepository(_DbCon);
            UserType = new UserTypeRepository(_DbCon);
            ChiefPayment = new ChiefPaymentRepository(_DbCon);
            Feast = new FeastRepository(_DbCon);
            Gradients = new GradientsRepository(_DbCon);
            NegociationFeast = new NegociationFeastRepository(_DbCon);
            Sofra = new SofraRepository(_DbCon);
            Discounts = new DiscountsRepository(_DbCon);
            Meel = new MeelRepository(_DbCon);
            OrderDettails = new OrderDettailsRepository(_DbCon);
            Order = new OrderRepository(_DbCon);
            TongueMeel = new TongueMeelRepository(_DbCon);
            TransactionLocation = new TransactionLocationRepository(_DbCon);
            DeliveryPayment = new DeliveryPaymentRepository(_DbCon);
            RefreshTokens = new RefreshTokenRepository(_DbCon);
            AuthCode = new AuthCodeRepository(_DbCon);
        }

        public IDatabaseTransaction BeginTransaction() => new EntityDatabaseTransaction(_DbCon);

        public async Task<int> CompleteAsync() => await _DbCon.SaveChangesAsync();

        public void Dispose() => _DbCon.Dispose();

        public int Complete() => _DbCon.SaveChanges();
    }
}

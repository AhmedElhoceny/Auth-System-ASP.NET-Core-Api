using El_Lo2ma_DomainModel.Interfaces.Auth;
using El_Lo2ma_DomainModel.Interfaces.Chief;
using El_Lo2ma_DomainModel.Interfaces.Clients;
using El_Lo2ma_DomainModel.Interfaces.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAchievmentsRepository Achievments { get; }
        public IRoleRepository Role { get; }
        public IUserLoginsRepository UserLogins { get; }
        public IUserRepository User { get; }
        public IUserRoleRepository UserRole { get; }
        public IUserTokenRepository UserToken { get; }
        public IUserTypeRepository UserType { get; }
        public IChiefPaymentRepository ChiefPayment { get; }
        public IFeastRepository Feast { get; }
        public IGradientsRepository Gradients { get; }
        public INegociationFeastRepository NegociationFeast { get; }
        public ISofraRepository Sofra { get; }
        public IDiscountsRepository Discounts { get; }
        public IMeelRepository Meel { get; }
        public IOrderDettailsRepository OrderDettails { get; }
        public IOrderRepository Order { get; }
        public ITongueMeelRepository TongueMeel { get; }
        public ITransactionLocationRepository TransactionLocation { get; }
        public IDeliveryPaymentRepository DeliveryPayment { get; }
        public IRefreshToken RefreshTokens { get; }
        public IAuthCodeRepository AuthCode { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}

using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_DomainModel.Interfaces.Delivery;
using El_Lo2ma_DomainModel.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Repositories.Delivery
{
    public class DeliveryPaymentRepository : BaseRepository<DeliveryPayment>, IDeliveryPaymentRepository
    {
        public DeliveryPaymentRepository(Lo2maContext DbCon) : base(DbCon)
        {
        }
    }
}

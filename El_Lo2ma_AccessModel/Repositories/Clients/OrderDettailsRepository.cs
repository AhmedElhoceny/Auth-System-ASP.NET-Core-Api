using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_DomainModel.Interfaces.Clients;
using El_Lo2ma_DomainModel.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Repositories.Clients
{
    public class OrderDettailsRepository : BaseRepository<OrderDetail>, IOrderDettailsRepository
    {
        public OrderDettailsRepository(Lo2maContext DbCon) : base(DbCon)
        {
        }
    }
}

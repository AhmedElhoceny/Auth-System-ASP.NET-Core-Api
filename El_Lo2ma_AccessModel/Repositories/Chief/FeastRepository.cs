using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_DomainModel.Interfaces.Chief;
using El_Lo2ma_DomainModel.Models.Chief;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_AccessModel.Repositories.Chief
{
    public class FeastRepository : BaseRepository<Feast>, IFeastRepository
    {
        public FeastRepository(Lo2maContext DbCon) : base(DbCon)
        {
        }
    }
}

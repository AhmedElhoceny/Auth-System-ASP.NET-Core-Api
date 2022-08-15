using El_Lo2ma_DomainModel.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Lo2ma_DomainModel.Interfaces.Auth
{
    public interface IUserTokenRepository:IBaseRepository<ApplicationUserToken>
    {
    }
}

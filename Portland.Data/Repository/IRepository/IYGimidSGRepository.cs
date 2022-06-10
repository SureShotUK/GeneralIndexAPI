using Portland.Data.SiteGround;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository.IRepository
{
    public interface IYGimidSGRepository : IRepository<YGimid>
    {
        void Update(YGimid source);

        Task UpdateAsync(YGimid source);
    }
}

    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository.IRepository
{
    public interface ISitegroundUnitOfWork : IDisposable
    {
        IYGimidSGRepository YGimidSGs { get; }


        void Save();
        Task SaveAsync();
    }
}

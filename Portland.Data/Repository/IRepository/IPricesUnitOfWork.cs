using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository.IRepository
{
    public interface IPricesUnitOfWork : IDisposable
    {
        IYGimidRepository YGimids { get; }

        void Save();
        Task SaveAsync();

        
    }

   

    //public interface ISitegroundUnitOfWork : IDisposable
    //{
    //    IYGimidSGRepository IYGimids { get; }

    //    void Save();
    //    Task SaveAsync();
    //}

   
}

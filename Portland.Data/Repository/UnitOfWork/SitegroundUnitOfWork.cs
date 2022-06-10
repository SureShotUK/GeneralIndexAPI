using Portland.Data.Repository.IRepository;
using Portland.Data.SiteGround;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository.UnitOfWork
{
    public class SitegroundUnitOfWork : ISitegroundUnitOfWork
    {
        private readonly SiteGroundContext _db;
        private IYGimidSGRepository _ygimid;

        public IYGimidSGRepository YGimidSGs => _ygimid ??= new YGimidSGRepository(_db);
        public SitegroundUnitOfWork(SiteGroundContext db)
        {
            _db = db;
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _db.DisposeAsync();
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

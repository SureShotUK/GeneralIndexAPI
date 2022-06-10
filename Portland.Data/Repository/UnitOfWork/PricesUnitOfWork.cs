using Portland.Data.Prices;
using Portland.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository
{
	public class PricesUnitOfWork : IPricesUnitOfWork
	{
		private readonly PricesContext _db;

		private IYGimidRepository _ygimids;
		
		public IYGimidRepository YGimids => _ygimids ??= new YGimidRepository(_db);
		


		public PricesUnitOfWork(PricesContext db)
		{
			_db = db;
		}

		public void Dispose()
		{
			_db.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task DisposeAsync()
		{
			await _db.DisposeAsync();
			GC.SuppressFinalize(this);
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

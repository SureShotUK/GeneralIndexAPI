using Portland.Data.Repository.IRepository;
using Portland.Data.SiteGround;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Portland.Data.Repository
{
    internal class YGimidSGRepository : Repository<YGimid>, IYGimidSGRepository
    {
        private readonly SiteGroundContext _db;

        public YGimidSGRepository(SiteGroundContext db) : base(db)
        {
            _db = db;
        }

        public void Update(YGimid source)
        {
            if (!ImportPrices(source)) return;
            var dbObj = _db.YGimids.FirstOrDefault(s => s.PublishedDate == source.PublishedDate);
            if (dbObj is null) _db.YGimids.Add(source);
            else UpdateDbObject(dbObj, source);
        }

        public async Task UpdateAsync(YGimid source)
        {
            if (!ImportPrices(source)) return;
            var dbObj = _db.YGimids.FirstOrDefault(s => s.PublishedDate == source.PublishedDate);
            if (dbObj is null) await _db.YGimids.AddAsync(source);
            else UpdateDbObject(dbObj, source);
        }

        private void UpdateDbObject(YGimid dbObj, YGimid source)
        {
            PropertyInfo[] properties = typeof(YGimid).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "PublishedDate") continue;
                var objValue = property.GetValue(source);
                if (objValue is null) continue;
                var value = Convert.ToDouble(objValue);
                property.SetValue(dbObj, value, null);
            }

            //dbObj.PublishedDate = source.PublishedDate;
            //dbObj.Gx0000006 = source.Gx0000006;
            //dbObj.Gx0000010 = source.Gx0000010;
            //dbObj.Gx0000015 = source.Gx0000015;
            //dbObj.Gx0000016 = source.Gx0000016;
            //dbObj.Gx0000082 = source.Gx0000082;
            //dbObj.Gx0000084 = source.Gx0000084;
            //dbObj.Gx0000093 = source.Gx0000093;
            //dbObj.Gx0000257 = source.Gx0000257;
            //dbObj.Gx0000258 = source.Gx0000258;
            //dbObj.Gx0000686 = source.Gx0000686;

        }
        private bool ImportPrices(YGimid source)
        {
            PropertyInfo[] properties = typeof(YGimid).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "PublishedDate") continue;
                var objValue = property.GetValue(source);
                if (objValue is not null) return true;
            }
            return false;


            //bool oneNotNull = false;
            //if (source.Gx0000006 is not null) oneNotNull = true;
            //if (source.Gx0000010 is not null) oneNotNull = true;
            //if (source.Gx0000015 is not null) oneNotNull = true;
            //if (source.Gx0000016 is not null) oneNotNull = true;
            //if (source.Gx0000082 is not null) oneNotNull = true;
            //if (source.Gx0000084 is not null) oneNotNull = true;
            //if (source.Gx0000093 is not null) oneNotNull = true;
            //if (source.Gx0000257 is not null) oneNotNull = true;
            //if (source.Gx0000258 is not null) oneNotNull = true;
            //if (source.Gx0000686 is not null) oneNotNull = true;
            //return oneNotNull;
        }
    }
}

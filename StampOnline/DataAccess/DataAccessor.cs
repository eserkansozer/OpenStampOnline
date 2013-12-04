using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StampOnline.Models;

namespace StampOnline.DataAccess
{
    public class DataAccessor : StampOnline.DataAccess.IDataAccessor
    {
        private IStampContainer _db;

        public DataAccessor(IStampContainer stampContainer)
        {
            _db = stampContainer;
        }
        
        public List<OStamp> GetTemplateStamps()
        {
            var templateList = _db.OStamps
                   .Where(s => s.IsTemplate == true)
                   .ToList<OStamp>();

            return templateList;
        }

        public OStamp GetStampById(int id)
        {
            var stamp = _db.OStamps.Find(id);
            return stamp;
        }

        public void SaveStampOrder(OStamp updatedStamp)
        {
            try
            {
                _db.OStamps.Add(updatedStamp);
                _db.SaveChanges();
            }
            catch (Exception e) {
                System.Diagnostics.Debugger.Break();
                throw e;
            }
        }

        public int GetOrderCount()
        {
            return _db.Orders.Count();
        }
    }
}
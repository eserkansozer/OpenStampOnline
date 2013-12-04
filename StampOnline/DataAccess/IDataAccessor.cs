using System;
namespace StampOnline.DataAccess
{
    public interface IDataAccessor
    {
        int GetOrderCount();
        StampOnline.Models.OStamp GetStampById(int id);
        System.Collections.Generic.List<StampOnline.Models.OStamp> GetTemplateStamps();
        void SaveStampOrder(StampOnline.Models.OStamp updatedStamp);
    }
}

using System;
using System.Data.Entity.Infrastructure;
namespace StampOnline.Models
{
    public interface IStampContainer
    {
        System.Data.Entity.DbSet<Graphic> Graphics { get; set; }
        System.Data.Entity.DbSet<Order> Orders { get; set; }
        System.Data.Entity.DbSet<OStamp> OStamps { get; set; }
        System.Data.Entity.DbSet<StampLine> StampLines { get; set; }
        void SaveChanges();

        void Dispose();

        DbEntityEntry<OStamp> Entry(OStamp ostamp);
    }
}

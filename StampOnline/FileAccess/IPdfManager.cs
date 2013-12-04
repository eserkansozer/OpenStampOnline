using System;
namespace StampOnline.FileAccess
{
    public interface IPdfManager
    {
        string CreatePdf(StampOnline.Models.OStamp stamp);
    }
}

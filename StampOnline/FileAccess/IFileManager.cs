using System;
namespace StampOnline.FileAccess
{
    public interface IFileManager
    {
        void DeleteFile(string fileName);
        string SaveFile(System.Web.HttpPostedFileBase uploadedFile, string hashCode);
    }
}

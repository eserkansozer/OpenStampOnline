using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using StampOnline.Models;

namespace StampOnline.FileAccess
{
    public class FileManager : StampOnline.FileAccess.IFileManager
    {
        public string SaveFile(HttpPostedFileBase uploadedFile, string hashCode)
        {
            var fileLen = uploadedFile.ContentLength;
            var input = new byte[fileLen];
            var stream = uploadedFile.InputStream;
            stream.Read(input, 0, fileLen);
            var fileName = hashCode + uploadedFile.FileName;
            var dataFile = HttpContext.Current.Server.MapPath("~/Graphics/" + fileName);
            System.IO.File.WriteAllBytes(@dataFile, input);
            return fileName;
        }

        public void DeleteFile(string fileName)
        {
            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Graphics/" + fileName));
        }
    }
}
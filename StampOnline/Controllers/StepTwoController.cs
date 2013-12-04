using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampOnline.Models;
using StampOnline.DataAccess;
using StampOnline.FileAccess;
using StampOnline.Domain;

namespace StampOnline.Controllers
{
    public class StepTwoController : Controller
    {
        private IFileManager _fileManager;
        private IPdfManager _pdfManager;
        private IDataAccessor _dataAccessor;
        private IUserSession _userSession;

        public StepTwoController(IFileManager fileManager, IPdfManager pdfManager, IDataAccessor dataAccessor, IUserSession userSession)
        {
            _fileManager = fileManager;
            _pdfManager = pdfManager;
            _dataAccessor = dataAccessor;
            _userSession = userSession;

            ViewBag.FontList = Constants.Fonts;
            ViewBag.FontSizeList = Constants.FontSizes;
        }

        private OStamp SessionStamp
        {
            get { return _userSession.GetValue<OStamp>(Constants.STAMP_SESSION_KEY); }
            set { _userSession.SetValue(Constants.STAMP_SESSION_KEY, value); }
        }

        public ActionResult Index()
        {            
            var blankStamp = new OStampBuilder().WithDefaultValues().Build();
            
            SessionStamp = blankStamp;
            return View(blankStamp);
        }

        public ActionResult DisplayFromTemplate(int id)
        {
            var stamp = (OStamp)_dataAccessor.GetStampById(id).Clone( );
            if(stamp == null)
            {
                Index();
            }

            SessionStamp = stamp;
            return View("Index", stamp);
        }

        public ActionResult UploadFile(Graphic graphic)
        {
            var stamp = SessionStamp;

            var uploadedFile = Request.Files[0];
            var fileName = _fileManager.SaveFile(uploadedFile, stamp.GetHashCode().ToString());

            stamp.Graphic = new Graphic() { Url = fileName };
            SessionStamp = stamp;
            return View("DisplayGraphicFrame", stamp.Graphic);
        }

        public ActionResult DisplayGraphicFrame()
        {
            var stamp = SessionStamp;
            if (stamp.Graphic == null)
                stamp.Graphic = new Graphic();

            return View(SessionStamp.Graphic);
        }

        public ActionResult RemoveFile()
        {
            var stamp = SessionStamp;
            
            _fileManager.DeleteFile(stamp.Graphic.Url);

            stamp.Graphic = null;

            SessionStamp = stamp;
            return View("DisplayGraphicFrame", stamp.Graphic);
        }

        public ActionResult Continue(OStamp stamp)
        {
            if (stamp.Graphic != null && SessionStamp.Graphic != null)
            {
                stamp.Graphic.Url = SessionStamp.Graphic.Url;
            }
            SessionStamp = stamp;
            return RedirectToAction("Index", "StepThree");
        }

        public FileResult GeneratePdf()
        {
            var stamp = SessionStamp;

            var fileName = _pdfManager.CreatePdf(stamp);

            stamp.PdfUrl = fileName;

            SessionStamp = stamp;

            return File(fileName, "application/pdf");
        }
    }
}

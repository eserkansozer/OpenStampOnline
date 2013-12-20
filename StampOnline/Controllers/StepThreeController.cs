using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampOnline.DataAccess;
using StampOnline.Domain;
using StampOnline.Models;

namespace StampOnline.Controllers
{
    public class StepThreeController : Controller
    {
        private IDataAccessor _dataAccessor;
        private IUserSession _userSession;

        public StepThreeController(IDataAccessor dataAccessor, IUserSession userSession)
        {
            _dataAccessor = dataAccessor;
            _userSession = userSession;
        }

        private OStamp SessionStamp
        {
            get { return _userSession.GetValue<OStamp>(Constants.STAMP_SESSION_KEY); }
            set { _userSession.SetValue(Constants.STAMP_SESSION_KEY, value); }
        }

        public ActionResult Index()
        {
            var stamp = SessionStamp;
            stamp.Order = new Order(stamp);
            stamp.NumberOfRows = stamp.StampLines.Count();
            SessionStamp = stamp;

            return View(stamp);
        }

        public ActionResult Save(OStamp updatedStamp)
        {
            if (ModelState.IsValid)
            {

                var stampToSave = SessionStamp;
                if (stampToSave.Graphic.Url == string.Empty)
                {
                    stampToSave.Graphic = null;
                }
                stampToSave.PadColour = updatedStamp.PadColour;
                stampToSave.HandleColour = updatedStamp.HandleColour;
                stampToSave.Order.Quantity = updatedStamp.Order.Quantity;

                _dataAccessor.SaveStampOrder(stampToSave);

                return View("Confirmation");
            }
            else
            {
                return View("Index",updatedStamp);
            }
        }
    }
}

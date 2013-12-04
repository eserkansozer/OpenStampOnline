using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampOnline.DataAccess;

namespace StampOnline.Controllers
{
    public class OrderCounterController : Controller
    {
        private IDataAccessor _dataAccessor;

        public OrderCounterController(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        public void Index()
        {
            int count = _dataAccessor.GetOrderCount();

            Response.ContentType = "text/event-stream";
            Response.Expires= -1;
            Response.Write("data:" + count.ToString() + "\n\n");
            Response.Flush();
        }
    }
}

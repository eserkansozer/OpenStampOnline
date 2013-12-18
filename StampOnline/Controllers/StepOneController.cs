using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StampOnline.Models;
using StampOnline.DataAccess;
using AutoMapper;

namespace StampOnline.Controllers
{
    public class StepOneController : Controller
    {
        private IDataAccessor _dataAccessor;

        public StepOneController(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        public ActionResult Index()
        {
            var templateList = _dataAccessor.GetTemplateStamps();
            var templateListVM = templateList
                .Select(ostamp => Mapper.Map<OStampDTO>(ostamp))
                .ToList();
            return View(templateListVM);
        }
    }
}

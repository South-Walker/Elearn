using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elearn.Controllers
{
    public class EnglishTextController : Controller
    {
        // GET: EnglishText
        public ActionResult GetText(string TextName)
        {
            return View(TextName + "view");
        }
    }
}
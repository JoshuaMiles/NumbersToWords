using NumbersToWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumbersToWords;

namespace NumbersToWords.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FormModel model = new FormModel();
            model.Word = "ZERO DOLLARS";
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormModel model)
        {
            if (ModelState.IsValid)
            {
                model.Word = Helper.NumbersToWords(model.Number);
            }
            
            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;

namespace FaqBuilder.Controllers
{
    public class FaqController : Controller
    {
        private readonly FaqBll _faqBll = new FaqBll();

        // GET: Faq
        public ActionResult Index()
        {
            return View(_faqBll.GetAllFaqVms());
        }

        public ActionResult CreateFaq()
        {
            return View(_faqBll.CreateFaq());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;

namespace FaqBuilder.Controllers
{
    public class MoveController : Controller
    {
        private readonly MoveBll _moveBll = new MoveBll();

        public ActionResult Create(int id)
        {
            return HttpNotFound();
        }
    }
}
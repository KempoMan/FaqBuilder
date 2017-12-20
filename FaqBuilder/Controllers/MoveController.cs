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

        public ActionResult CreateMove(int id)
        {
            var result = _moveBll.CreateNewMoveForCharacter(id);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(result);
        }
    }
}
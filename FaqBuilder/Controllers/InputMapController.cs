using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class InputMapController : Controller
    {
        private readonly InputMapBll _inputMapBll = new InputMapBll();

        public ActionResult CreateInputMap(int id)
        {
            return View(_inputMapBll.GetNewInputMapViewModelForGame(id));
        }

        [HttpPost]
        public ActionResult CreateInputMap(InputMapViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _inputMapBll.CreateInputMap(viewModel);

            if (result.Success) return RedirectToAction("GameDetails", "Game", new {id = viewModel.GameId});

            ModelState.AddModelError(string.Empty, viewModel.Error);
            return View(viewModel);
        }
    }
}
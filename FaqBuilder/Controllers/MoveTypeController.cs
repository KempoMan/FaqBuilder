using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class MoveTypeController : Controller
    {
        private readonly MoveTypeBll _moveTypeBll = new MoveTypeBll();

        public ActionResult MoveTypeIndex(int id)
        {
            return View(_moveTypeBll.GetMoveTypesForGame(id));
        }

        public ActionResult CreateMoveType(int gameId)
        {
            return View(_moveTypeBll.GetNewMoveTypeVm(gameId));
        }

        [HttpPost]
        public ActionResult CreateMoveType(MoveTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _moveTypeBll.CreateMoveType(viewModel);

            if (result.Success) return RedirectToAction("GameDetails", "Game", new { id = viewModel.GameId });

            ModelState.AddModelError(string.Empty, viewModel.Error);
            return View(viewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class MoveController : Controller
    {
        private readonly MoveBll _moveBll = new MoveBll();

        public ActionResult CreateMove(int id)
        {
            var result = _moveBll.GetCreateNewMoveVmForCharacter(id);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult CreateMove(MoveViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _moveBll.CreateMoveForCharacter(viewModel);

            if (result.Success)
                return RedirectToAction("CharacterDetails", "Character", new {id = viewModel.CharacterId});

            ModelState.AddModelError(string.Empty, result.Error);
            return View(_moveBll.GetViewModelLists(viewModel));
        }
    }
}
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

        public ActionResult CreateMoveOfType(int id, int typeId)
        {
            var result = _moveBll.GetCreateNewMoveVmForCharacterByType(id, typeId);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View("CreateMove", result);
        }

        [HttpPost]
        public ActionResult CreateMoveOfType(MoveViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateMove", viewModel);
            }

            var result = _moveBll.CreateMoveForCharacter(viewModel);

            if (result.Success)
                return RedirectToAction("CharacterDetails", "Character", new { id = viewModel.CharacterId });

            ModelState.AddModelError(string.Empty, result.Error);
            return View("CreateMove", _moveBll.GetViewModelLists(viewModel));
        }

        public ActionResult DeleteMove(int characterId, int moveId)
        {
            var result = _moveBll.DeleteMove(moveId);

            if (result)
                return RedirectToAction("CharacterDetails", "Character", new { id = characterId });

            ModelState.AddModelError(string.Empty, @"Error deleting move.");

            return RedirectToAction("CharacterDetails", "Character", new {id = characterId});
        }
    }
}
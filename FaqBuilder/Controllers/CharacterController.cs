using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class CharacterController : Controller
    {
        private readonly CharacterBll _characterBll = new CharacterBll();

        public ActionResult Create(int id)
        {            
            return View(_characterBll.GetNewCharacterVm(id));
        }

        [HttpPost]
        public ActionResult Create(CharacterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _characterBll.CreateCharacter(viewModel);

            if (result.Success) return RedirectToAction("GameDetails", "Game", new {id = viewModel.GameId});           

            ModelState.AddModelError(string.Empty, viewModel.Error);
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _characterBll.GetCharacterVm(id);

            if (!viewModel.Success) ModelState.AddModelError(string.Empty, viewModel.Error);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CharacterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _characterBll.UpdateCharacter(viewModel);

            if (result.Success) return RedirectToAction("GameDetails", "Game", new { id = viewModel.GameId });

            ModelState.AddModelError(string.Empty, viewModel.Error);
            return View(viewModel);
        }

        public ActionResult CharacterDetails(int id)
        {
            return View(_characterBll.GetCharacterVm(id));
        }
    }
}
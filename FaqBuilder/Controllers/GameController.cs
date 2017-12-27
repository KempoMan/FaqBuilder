using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class GameController : Controller
    {
        private readonly GameBll _gameBll = new GameBll();

        // GET: Game
        public ActionResult Index()
        {
            return View(_gameBll.GetAllGameVms());
        }

        public ActionResult CreateGame()
        {
            return View(_gameBll.GetNewGameVm());
        }

        [HttpPost]
        public ActionResult CreateGame(GameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(_gameBll.GetListsForViewModel(viewModel));
            }

            var result = _gameBll.CreateGame(viewModel);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return View(result);
        }

        public ActionResult GameDetails(int? gameId)
        {
            if (gameId == null)
            {
                return HttpNotFound();
            }

            var result = _gameBll.GetGameVmById(gameId.Value);

            if (result.Success)
            {
                return View(result);
            }

            return HttpNotFound();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var result = _gameBll.GetGameVmById(id.Value);

            if (result.Success)
            {
                return View(result);
            }

            return HttpNotFound();
        }
        
        [HttpPost]
        public ActionResult Edit(GameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _gameBll.UpdateGame(viewModel);

            if (result.Success)
            {
                return RedirectToAction("GameDetails", new {id = viewModel.Id});
            }

            ModelState.AddModelError(string.Empty, result.Error);

            return View(viewModel);
        }
    }
}
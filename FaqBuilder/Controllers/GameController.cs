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

            if (result.Success) RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, result.Error);

            return View(result);
        }
    }
}
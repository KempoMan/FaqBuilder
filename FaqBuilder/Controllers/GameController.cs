using System.Web.Mvc;
using FaqBuilder.Bll;

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
    }
}
using System.Web.Mvc;
using FaqBuilder.Bll;
using FaqBuilder.ViewModels;

namespace FaqBuilder.Controllers
{
    public class PlatformController : Controller
    {
        private readonly PlatformBll _platformBll = new PlatformBll();

        // GET: Platforms
        public ActionResult Index()
        {
            return View(_platformBll.GetAllPlatformVms());
        }

        public ActionResult CreatePlatform()
        {
            return View(_platformBll.GetNewPlatformVm());
        }

        [HttpPost]
        public ActionResult CreatePlatform(PlatformViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _platformBll.CreatePlatform(viewModel);

            if (result.Success) return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, result.Error);

            return View(result);
        }

        public ActionResult EditPlatform(int id)
        {
            var viewModel = _platformBll.GetPlatformVmById(id);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditPlatform(PlatformViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = _platformBll.UpdatePlatform(viewModel);

            if (result.Success) return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, result.Error);

            return View(result);
        }
    }
}

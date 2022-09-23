using BlogSystem.Web.App_Start;
using BlogSystem.Web.Areas.Administration.ViewModels.Excute;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    public class EXCController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Result = Session["Result"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Query(ExcuteViewModel model)
        {
            Session["Result"] = null;
            if (model != null && this.ModelState.IsValid)
                Session["Result"] = JsonConvert.SerializeObject(DA.FillDataTableSQL(model.Content));
            return this.RedirectToAction("Index");
        }
    }
}
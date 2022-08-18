using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult InternalServerError(string err)
        {
            return PartialView(err);
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            return PartialView();
        }
    }
}
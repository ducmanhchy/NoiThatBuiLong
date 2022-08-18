using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        public ActionResult ProductDetail()
        {
            return View();
        }
    }
}
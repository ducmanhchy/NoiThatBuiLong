using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.ViewModels.Posts;
using System.Net;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class BLController : BaseController
    {
        private readonly IDbRepository<Post> postsData;

        public BLController(IDbRepository<Post> postsData)
        {
            this.postsData = postsData;
        }
        // GET: BL
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var post = this.postsData.Find(id);
            if (post == null)
                return this.HttpNotFound();

            var model = this.Mapper.Map<PostViewModel>(post);
            return this.View(model);
        }
    }
}
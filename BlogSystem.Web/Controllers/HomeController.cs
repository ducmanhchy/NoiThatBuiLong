using System.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.ViewModels.Home;
using BlogSystem.Web.ViewModels.Posts;

namespace BlogSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDbRepository<Post> postsData;

        public HomeController(IDbRepository<Post> postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Index_Theme1()
        {
            return this.View();
        }

        public ActionResult Index_Theme2()
        {
            return this.PartialView();
        }

        //DANG SU DUNG
        public ActionResult Index_Theme3()
        {
            var postsPage = this.postsData.All().Where(x => x.ParentType == "HOME" && x.isPublish == true).OrderByDescending(p => p.CreatedOn);
            var posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();

            var blogsPage = this.postsData.All().Where(x => x.ParentType == "BL" && x.isPublish == true).OrderByDescending(p => p.CreatedOn);
            var blogs = this.Mapper.Map<PostViewModel>(blogsPage).ToList();

            var model = new IndexHomeViewModel
            {
                Posts = posts,
                Blogs = blogs
            };

            return this.View(model);
        }

        public ActionResult Detail(string ParentType = null, string Unit = null)
        {
            PostViewModel model = new PostViewModel();

            var postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == ParentType && x.type == Unit && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(1);
            model = this.Mapper.Map<PostViewModel>(postsPage).FirstOrDefault();
            if (model == null)
                return this.RedirectToAction(String.Format("Index_Theme{0}", ConfigurationManager.AppSettings["ThemeUsed"]), "Home");
            return this.View(model);
        }
    }
}

namespace BlogSystem.Web.Controllers
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Common;
    using BlogSystem.Data.Models;
    using BlogSystem.Data.Repositories;
    using BlogSystem.Web.ViewModels.Home;
    using BlogSystem.Web.ViewModels.Posts;

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

            var model = new IndexHomeViewModel
            {
                Posts = posts
            };

            return this.View(model);
        }
    }
}

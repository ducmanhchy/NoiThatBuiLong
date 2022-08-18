﻿namespace BlogSystem.Web.Controllers
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Common;
    using BlogSystem.Data.Models;
    using BlogSystem.Data.Repositories;
    using BlogSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDbRepository<Post> postsData;

        public HomeController(IDbRepository<Post> postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            var pagesCount = (int)Math.Ceiling(this.postsData.All().Count() / (decimal)perPage);
            var postsPage = this.postsData.All().OrderByDescending(p => p.CreatedOn).Skip(perPage * (page - 1)).Take(perPage);
            var posts = this.Mapper.Map<PostConciseViewModel>(postsPage).ToList();

            var model = new IndexPageViewModel
            {
                Posts = posts,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            //return this.View(model);

            return View(String.Format("Index_Theme{0}", ConfigurationManager.AppSettings["ThemeUsed"]), model);
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
            return this.View();
        }
    }
}

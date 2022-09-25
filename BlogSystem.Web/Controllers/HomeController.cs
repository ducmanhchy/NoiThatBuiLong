using System.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.ViewModels.Home;
using BlogSystem.Web.ViewModels.Posts;
using System.Web.Caching;
using System.Collections.Generic;

namespace BlogSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDbRepository<Post> postsData;
        private string ConfigHideADHomeControler = ConfigurationManager.AppSettings["ConfigHideADHomeControler"].ToString();
        private string[] ConfigShowADHomeControler = ConfigurationManager.AppSettings["ConfigShowADHomeControler"].ToString().Split(',');


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
            List<PostViewModel> posts = new List<PostViewModel>();
            List<PostViewModel> blogs = new List<PostViewModel>();
            Cache ca = new Cache();
            if (ca["CACHE_HOME_POST"] != null && ca["CACHE_HOME_POST"] != null)
                posts = (List<PostViewModel>)ca["CACHE_HOME_POST"];
            else
            {
                var postsPage = this.postsData.All().Where(x => x.ParentType == "HOME" && x.status != -1 && x.isPublish == true).OrderByDescending(p => p.CreatedOn);
                posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();
                ca.Insert("CACHE_HOME_POST", posts, null, DateTime.MaxValue, TimeSpan.FromHours(6));
            }
            
            if (ca["CACHE_HOME_BLOG"] != null && ca["CACHE_HOME_BLOG"] != null)
                blogs = (List<PostViewModel>)ca["CACHE_HOME_BLOG"];
            else
            {
                var blogsPage = this.postsData.All().Where(x => x.ParentType == "BL" && x.status != -1 && x.isPublish == true).OrderByDescending(p => p.CreatedOn);
                blogs = this.Mapper.Map<PostViewModel>(blogsPage).ToList();
                ca.Insert("CACHE_HOME_BLOG", blogs, null, DateTime.MaxValue, TimeSpan.FromHours(6));
            }

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

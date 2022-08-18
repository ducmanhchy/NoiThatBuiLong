using System.Web.Mvc;
using System.Collections.Generic;
using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using BlogSystem.Common;
using BlogSystem.Web.Areas.Administration.ViewModels.Posts;
using System.Linq;
using System;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IDbRepository<Post> postsData;

        public HomeController(IDbRepository<Post> postsData)
        {
            this.postsData = postsData;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            int pagesCount = (int)Math.Ceiling(this.postsData.All().Where(x => (x.type != "BST" && x.type != "YT") && x.status != -1).Count() / (decimal)perPage);

            var postsPage = this.postsData
                .All()
                .Where(x => (x.type != "BST" && x.type != "YT") && x.status != -1)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();

            var model = new IndexPostsPageViewModel
            {
                Posts = posts,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return this.View(model);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 6 * 10 * 60)]
        public PartialViewResult AdminMenu()
        {
            //var menuItems = Assembly
            //    .GetAssembly(typeof(AdministrationController))
            //    .GetTypes()
            //    .Where(type => type.IsSubclassOf(typeof(AdministrationController)) && !type.IsAbstract)
            //    .Select(c => c.Name.Replace("Controller", string.Empty))
            //    .ToList();
            MenuAdminViewModel menuItems = new MenuAdminViewModel();
            List<MenuAdmin> listmenu = new List<MenuAdmin>();
            listmenu.Add(new MenuAdmin { ControlerName = "Home", Name = "Trang chủ" });
            listmenu.Add(new MenuAdmin { ControlerName = "CustomerContact", Name = "Thông tin liên hệ" });
            listmenu.Add(new MenuAdmin { ControlerName = "YT", Name = "Ý tưởng" });
            listmenu.Add(new MenuAdmin { ControlerName = "BST", Name = "Bộ sưu tập" });
            listmenu.Add(new MenuAdmin { ControlerName = "Settings", Name = "Cài đặt" });
            menuItems.Menus = listmenu;
            return this.PartialView(menuItems);
        }
    }
}
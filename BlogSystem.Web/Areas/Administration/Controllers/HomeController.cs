using System.Web.Mvc;
using System.Collections.Generic;
using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Common;
using BlogSystem.Web.Areas.Administration.ViewModels.Posts;
using System.Linq;
using System;
using BlogSystem.Web.App_Start;
using System.IO;
using System.Net;

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
            //listmenu.Add(new MenuAdmin { ControlerName = "Settings", Name = "Cài đặt" });
            menuItems.Menus = listmenu;
            return this.PartialView(menuItems);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                try
                {
                    if (model.ImgPost != null && model.ImgPost.ContentLength > 0)
                    {
                        if (!string.IsNullOrEmpty(model.linkIMG))
                            Utility.removeFile(Path.Combine(Server.MapPath("~/UploadedFiles/"), model.linkIMG.Replace("/UploadedFiles/", "")));
                        ImageUpload imageUpload = new ImageUpload { Height = 210 };
                        ImageResult imageResult = imageUpload.RenameUploadFile(model.ImgPost);
                        if (imageResult.Success)
                            model.linkIMG = "/UploadedFiles/" + imageResult.ImageName;
                        else
                            ViewBag.Error = imageResult.ErrorMessage;
                    }
                }
                catch
                {
                    ViewBag.Error = "File upload failed!!";
                    return View();
                }

                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    ShortContent = model.ShortContent,
                    linkIMG = model.linkIMG,
                    TitleIMG = model.TitleIMG,
                    isPublish = model.isPublish,
                    type = model.type,
                    ParentType = model.ParentType,
                    Ord = model.Ord,
                    Desc = model.Desc,
                    LinkPost = model.LinkPost,
                    AuthorId = this.CurrentUser.GetUser().Id
                };

                this.postsData.Add(post);
                this.postsData.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.postsData.Find(id);

            if (post == null)
            {
                return this.HttpNotFound();
            }

            var model = this.Mapper.Map<PostViewModel>(post);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                try
                {
                    if (model.ImgPost != null && model.ImgPost.ContentLength > 0)
                    {
                        if (!string.IsNullOrEmpty(model.linkIMG))
                            Utility.removeFile(Path.Combine(Server.MapPath("~/UploadedFiles/"), model.linkIMG.Replace("/UploadedFiles/", "")));
                        ImageUpload imageUpload = new ImageUpload { };
                        ImageResult imageResult = imageUpload.RenameUploadFile(model.ImgPost);
                        if (imageResult.Success)
                            model.linkIMG = "/UploadedFiles/" + imageResult.ImageName;
                        else
                            ViewBag.Error = imageResult.ErrorMessage;
                    }
                }
                catch
                {
                    ViewBag.Error = "File upload failed!!";
                    return View();
                }

                var post = this.postsData.Find(model.Id);

                post.linkIMG = model.linkIMG;
                post.TitleIMG = model.TitleIMG;
                post.Title = model.Title;
                post.Content = model.Content;
                post.ShortContent = model.ShortContent;
                post.isPublish = model.isPublish;
                post.type = model.type;
                post.ParentType = model.ParentType;
                post.Ord = model.Ord;
                post.Desc = model.Desc;
                post.LinkPost = model.LinkPost;
                post.AuthorId = this.CurrentUser.GetUser().Id;

                this.postsData.Update(post);
                this.postsData.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.postsData.Find(id);

            if (post == null)
            {
                return this.HttpNotFound();
            }

            return this.View(post);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (this.ModelState.IsValid)
            {
                var post = this.postsData.Find(id);
                post.status = -1;
                this.postsData.Update(post);
                this.postsData.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.postsData.Find(id);

            if (post == null)
            {
                return this.HttpNotFound();
            }

            var model = this.Mapper.Map<PostViewModel>(post);

            return this.View(model);
        }
    }
}
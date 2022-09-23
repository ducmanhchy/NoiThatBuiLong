﻿using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.App_Start;
using BlogSystem.Web.Areas.Administration.ViewModels.Posts;
using BlogSystem.Web.Areas.Administration.ViewModels.Services;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    public class FTController : AdministrationController
    {
        private readonly IDbRepository<Service> postsData;
        private readonly IUrlGenerator urlGenerator;
        private string UploadPath = ConfigurationManager.AppSettings["uploadfile_SV"].ToString();

        public FTController(IDbRepository<Service> postsData, IUrlGenerator urlGenerator)
        {
            this.postsData = postsData;
            this.urlGenerator = urlGenerator;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            int pagesCount = (int)Math.Ceiling(this.postsData.All().Where(x => x.ParentType == "SV" && x.status != -1).Count() / (decimal)perPage);

            var postsPage = this.postsData
                .All()
                .Where(x => x.ParentType == "SV" && x.status != -1)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var posts = this.Mapper.Map<ServiceViewModel>(postsPage).ToList();

            var model = new IndexServicesPageViewModel
            {
                Posts = posts,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                try
                {
                    if (model.ImgPost != null && model.ImgPost.ContentLength > 0)
                    {
                        Utility.checkFolderPath(Server.MapPath("~" + UploadPath));
                        if (!string.IsNullOrEmpty(model.linkIMG))
                        {
                            var s = model.linkIMG.Split('/');
                            Utility.removeFile(Path.Combine(Server.MapPath("~" + model.linkIMG.Replace(s[s.Length - 1], "")), s[s.Length - 1]));
                        }
                        ImageUpload imageUpload = new ImageUpload { Height = 210, UploadPath = UploadPath };
                        ImageResult imageResult = imageUpload.RenameUploadFile(model.ImgPost);
                        if (imageResult.Success)
                            model.linkIMG = UploadPath + imageResult.ImageName;
                        else
                            ViewBag.Error = imageResult.ErrorMessage;
                    }
                }
                catch
                {
                    ViewBag.Error = "File upload failed!!";
                }

                var post = new Service
                {
                    Title = model.Title,
                    Content = model.Content,
                    ShortContent = model.ShortContent,
                    linkIMG = model.linkIMG,
                    TitleIMG = model.TitleIMG,
                    isPublish = model.isPublish,
                    type = model.type,
                    ParentType = "SV",
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

            var model = this.Mapper.Map<ServiceViewModel>(post);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {

                try
                {
                    if (model.ImgPost != null && model.ImgPost.ContentLength > 0)
                    {
                        Utility.checkFolderPath(Server.MapPath("~" + UploadPath));
                        if (!string.IsNullOrEmpty(model.linkIMG))
                        {
                            var s = model.linkIMG.Split('/');
                            Utility.removeFile(Path.Combine(Server.MapPath("~" + model.linkIMG.Replace(s[s.Length - 1], "")), s[s.Length - 1]));
                        }
                        ImageUpload imageUpload = new ImageUpload { Height = 210, UploadPath = UploadPath };
                        ImageResult imageResult = imageUpload.RenameUploadFile(model.ImgPost);
                        if (imageResult.Success)
                            model.linkIMG = UploadPath + imageResult.ImageName;
                        else
                            ViewBag.Error = imageResult.ErrorMessage;
                    }
                }
                catch
                {
                    ViewBag.Error = "File upload failed!!";
                }

                var post = this.postsData.Find(model.Id);

                post.linkIMG = model.linkIMG;
                post.TitleIMG = model.TitleIMG;
                post.Title = model.Title;
                post.Content = model.Content;
                post.ShortContent = model.ShortContent;
                post.isPublish = model.isPublish;
                post.type = model.type;
                post.ParentType = "SV";
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

            var model = this.Mapper.Map<ServiceViewModel>(post);

            return this.View(model);
        }

        [HttpGet]
        [ActionName("RemoveCache")]
        public ActionResult RemoveCache()
        {
            Cache.Remove("SERVICES");

            return this.RedirectToAction("Index");
        }

    }
}
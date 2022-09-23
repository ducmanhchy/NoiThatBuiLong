using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using BlogSystem.Web.ViewModels.Posts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class BSTController : BaseController
    {
        private readonly IDbRepository<Post> postsData;
        private readonly IUrlGenerator urlGenerator;
        private string UploadPath = ConfigurationManager.AppSettings["uploadfile_BST"].ToString();

        public BSTController(IDbRepository<Post> postsData, IUrlGenerator urlGenerator)
        {
            this.postsData = postsData;
            this.urlGenerator = urlGenerator;
        }

        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            int pagesCount = (int)Math.Ceiling(this.postsData.All().Where(x => x.ParentType == "BST").Count() / (decimal)perPage);

            var postsPage = this.postsData
                .All()
                .Where(x => x.ParentType == "BST" && x.isPublish == true)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();

            FileInfo[] fileArray = new DirectoryInfo(Server.MapPath("~" + UploadPath) + "Galleries/").GetFiles("*.jpg");
            var model = new IndexPostsViewModel
            {
                Posts = posts,
                CurrentPage = page,
                PagesCount = pagesCount
            };
            model.Galleries = fileArray.Select(x => UploadPath + "Galleries/" + x.Name).ToList();

            return this.View(model);
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
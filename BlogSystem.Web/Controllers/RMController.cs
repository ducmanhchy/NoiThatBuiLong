using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebPages;

namespace BlogSystem.Web.Controllers
{
    public class RMController : BaseController
    {
        private readonly IDbRepository<Post> postsData;

        public RMController(IDbRepository<Post> postsData)
        {
            this.postsData = postsData;
        }
        // GET: BL
        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize, string type = null)
        {
            int pagesCount = (int)Math.Ceiling(this.postsData.All().Where(x => x.ParentType == "RM" && x.type == (string.IsNullOrEmpty(type) ? x.type : type) && x.status != -1 && x.isPublish == true).Count() / (decimal)perPage);

            IQueryable postsPage = null;
            List<PostViewModel> posts = new List<PostViewModel>();
            if (type == null)
            {
                ViewBag.Title = "Phòng";
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "PK" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "PA" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "PN" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "PLV" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "TB" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == "HTT" && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(perPage);
                posts.AddRange(this.Mapper.Map<PostViewModel>(postsPage));
            }
            else
            {
                ViewBag.Title = "Phòng";
                postsPage = this.postsData
                    .All()
                    .Where(x => x.ParentType == "RM" && x.type == type && x.status != -1 && x.isPublish == true)
                    .OrderByDescending(p => p.CreatedOn)
                    .Skip(perPage * (page - 1))
                    .Take(perPage);
                posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();
            }    

            var model = new IndexPostsViewModel
            {
                Posts = posts,
                CurrentPage = page,
                PagesCount = pagesCount
            };

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

            var postsPage = this.postsData
                .All()
                .Where(x => x.ParentType == "RM" && x.type == post.type && x.status != -1 && x.isPublish == true)
                .OrderByDescending(p => p.CreatedOn)
                .Take(5);
            model.Posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();

            return this.View(model);
        }
    }
}
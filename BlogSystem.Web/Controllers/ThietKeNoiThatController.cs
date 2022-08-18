using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using BlogSystem.Web.ViewModels.Posts;
using System.Net;
using System;
using System.Web.Mvc;
using System.Linq;

namespace BlogSystem.Web.Controllers
{
    public class ThietKeNoiThatController : BaseController
    {
        private readonly IDbRepository<Post> postsData;
        private readonly IUrlGenerator urlGenerator;

        public ThietKeNoiThatController(IDbRepository<Post> postsData, IUrlGenerator urlGenerator)
        {
            this.postsData = postsData;
            this.urlGenerator = urlGenerator;
        }

        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            int pagesCount = (int)Math.Ceiling(this.postsData.All().Where(x => x.type == "BST").Count() / (decimal)perPage);

            var postsPage = this.postsData
                .All()
                .Where(x => x.type == "BST" && x.isPublish == true)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var posts = this.Mapper.Map<PostViewModel>(postsPage).ToList();

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
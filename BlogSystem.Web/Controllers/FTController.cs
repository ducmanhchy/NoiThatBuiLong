using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using BlogSystem.Web.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class FTController : BaseController
    {
        private readonly IDbRepository<Service> postsData;

        public FTController(IDbRepository<Service> postsData)
        {
            this.postsData = postsData;
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var post = this.postsData.Find(id);
            if (post == null)
                return this.HttpNotFound();

            var model = this.Mapper.Map<ServiceViewModel>(post);
            return this.View(model);
        }
    }
}
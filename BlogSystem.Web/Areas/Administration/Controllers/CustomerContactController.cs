using BlogSystem.Common;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.Areas.Administration.ViewModels;
using BlogSystem.Web.Infrastructure.Helpers.Url;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    public class CustomerContactController : AdministrationController
    {
        private readonly IDbRepository<CustomerContact> CustomerContact;

        public CustomerContactController(IDbRepository<CustomerContact> CustomerContact)
        {
            this.CustomerContact = CustomerContact;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int perPage = GlobalConstants.DefaultPageSize)
        {
            int pagesCount = (int)Math.Ceiling(this.CustomerContact.All().Where(x => x.Type == "H" && x.Status != -1).Count() / (decimal)perPage);

            var CustomerContactsPage = this.CustomerContact
                .All()
                .Where(x => x.Type == "H" && x.Status != -1)
                .OrderByDescending(p => p.CreatedOn)
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var CustomerContact = this.Mapper.Map<CustomerContactViewModel>(CustomerContactsPage).ToList();

            var model = new IndexCustomerContactViewModel
            {
                CustomerContact = CustomerContact,
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult ViewDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CustomerContact = this.CustomerContact.Find(id);

            if (CustomerContact == null)
            {
                return this.HttpNotFound();
            }

            CustomerContact.Status = 1;
            this.CustomerContact.Update(CustomerContact);
            this.CustomerContact.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.CustomerContact.Find(id);

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
                var post = this.CustomerContact.Find(id);
                post.Status = -1;
                this.CustomerContact.Update(post);
                this.CustomerContact.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }

    }
}
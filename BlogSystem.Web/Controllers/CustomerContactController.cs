using BlogSystem.Data.Models;
using System.Web.Mvc;
using BlogSystem.Data.Repositories;
using BlogSystem.Web.ViewModels.Home;

namespace BlogSystem.Web.Controllers
{
    public class CustomerContactController : BaseController
    {
        private readonly IDbRepository<CustomerContact> CustomerContactData;

        public CustomerContactController(IDbRepository<CustomerContact> CustomerContactData)
        {
            this.CustomerContactData = CustomerContactData;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerContactViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var custContact = new CustomerContact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Description = model.Description,
                    Status = 0,
                    Type = "H"
                };

                this.CustomerContactData.Add(custContact);
                this.CustomerContactData.SaveChanges();
            }

            return this.Redirect("/");
        }
    }
}
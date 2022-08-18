using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Data.Contracts;

namespace BlogSystem.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
            : base()
        {
            Posts = new HashSet<Post>();
        }

        public DateTime CreatedOn { get; set; }

        public string UserCreate { get; set; }

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string UserModify { get; set; }

        public bool IsDeleted { get; set; }

        public string UserDelete { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
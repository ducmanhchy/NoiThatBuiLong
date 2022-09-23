using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Data.Contracts;
using BlogSystem.Data.Models;
using System.Data.Entity.Validation;

namespace BlogSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(nameOrConnectionString: "DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Setting> Settings { get; set; }

        public virtual IDbSet<MenuItem> Menu { get; set; }

        public virtual IDbSet<CustomerContact> CustomerContact { get; set; }

        public virtual IDbSet<Service> Services { get; set; }

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            ApplyDeletableEntityRules();
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
            
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo) entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                        entity.CreatedOn = DateTime.Now;
                }
                else
                    entity.ModifiedOn = DateTime.Now;
            }
        }

        private void ApplyDeletableEntityRules()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity) entry.Entity;
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        public new IDbSet<TEntity> Set<TEntity>() 
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasRequired(c => c.Author).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
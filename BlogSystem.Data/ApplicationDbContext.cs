using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Data.Contracts;
using BlogSystem.Data.Models;

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

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            ApplyDeletableEntityRules();
            return base.SaveChanges();
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
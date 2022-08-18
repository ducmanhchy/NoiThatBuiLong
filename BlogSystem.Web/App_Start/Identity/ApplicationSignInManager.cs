using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BlogSystem.Data.Models;

namespace BlogSystem.Web.Identity
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}
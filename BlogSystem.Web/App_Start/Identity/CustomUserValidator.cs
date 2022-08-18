using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebSampleTool.App_Data.Localization;
using WebSampleTool.Models;

namespace WebSampleTool.App_Start.IdentityPolicy
{
    public class CustomUserValidator<TUser> : UserValidator<TUser, string>
    where TUser : ApplicationUser
    {
        private UserManager<TUser, string> Manager { get; set; }

        public CustomUserValidator(UserManager<TUser, string> manager) : base(manager)
        {
            Manager = manager;
        }

        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            var errors = new List<string>();
            ValidateUserName(item, errors);
            if (RequireUniqueEmail)
                await ValidateEmail(item, errors);
            if (errors.Count > 0)
                return IdentityResult.Failed(errors.ToArray());
            return IdentityResult.Success;
        }

        private void ValidateUserName(TUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PropertyTooShort, user.UserName));
                return;
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
                // Nếu có bất kì kí tự nào không phải chữ hoặc số thì đó là username không hợp pháp
                errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.InvalidUserName, user.UserName));
            else
            {
                var owner = Manager.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (owner != null && !Equals(owner.Id, user.Id))
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.DuplicateName, user.UserName));
            }
        }

        // make sure email is not empty, valid, and unique
        private async Task ValidateEmail(TUser user, List<string> errors)
        {
            if (!user.Email.IsNullOrWhiteSpace())
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PropertyTooShort, "Email"));
                    return;
                }
                try
                {
                    var m = new MailAddress(user.Email);
                }
                catch (FormatException)
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.InvalidEmail, user.Email));
                    return;
                }
            }
            var owner = await Manager.FindByEmailAsync(user.Email);
            if (owner != null && !Equals(owner.Id, user.Id))
                errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.DuplicateEmail, user.Email));
        }
    }
}
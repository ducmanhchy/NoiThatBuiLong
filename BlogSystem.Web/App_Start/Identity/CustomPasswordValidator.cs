using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebSampleTool.App_Data.Localization;

namespace WebSampleTool.App_Start.IdentityPolicy
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");
            var errors = new List<string>();
            if (password.Length < RequiredLength)
                await Task.Run(() =>
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PasswordTooShort, RequiredLength));
                });
            if (RequireNonLetterOrDigit && !Regex.IsMatch(password, @".*[0-9a-zA-Z]+.*"))
                await Task.Run(() =>
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PasswordRequireNonLetterOrDigit));
                });
            if (RequireDigit && !Regex.IsMatch(password, @".*[0-9]+.*"))
            {
                await Task.Run(() =>
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PasswordRequireDigit));
                });
            }
            if (RequireLowercase && !Regex.IsMatch(password, @".*[a-z]+.*"))
            {
                await Task.Run(() =>
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PasswordRequireLower));
                });
            }
            if (RequireUppercase && !Regex.IsMatch(password, @".*[A-Z]+.*"))
            {
                await Task.Run(() =>
                {
                    errors.Add(string.Format(CultureInfo.CurrentCulture, CustomResources.PasswordRequireUpper));
                });
            }
            if (errors.Count > 0)
                return IdentityResult.Failed(errors.ToArray());
            return IdentityResult.Success;
        }
    }
}
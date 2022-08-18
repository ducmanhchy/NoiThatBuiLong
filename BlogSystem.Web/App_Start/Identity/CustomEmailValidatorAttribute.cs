using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlogSystem.Web.Identity
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CustomEmailValidatorAttribute : ValidationAttribute
    {
        private const string RegexPattern = @"^[0-9a-zA-Z]+@[a-z]+(\.[a-z]+)+$";

        public CustomEmailValidatorAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }

        public bool IsValid(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return new Regex(RegexPattern).IsMatch(value);
            return true;
        }
    }
}
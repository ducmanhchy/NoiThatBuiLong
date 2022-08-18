using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;

namespace BlogSystem.Web.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PassSettingsToViewDataAttribute : ActionFilterAttribute
    {
        public IDbRepository<Setting> Settings { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var settings = this.Settings.All().ToList();
            var viewData = filterContext.Controller.ViewData;

            foreach(var setting in settings)
            {
                viewData.Add(setting.Key, setting.Value);
            }
            var LoadKeyConfig = ConfigurationManager.AppSettings["LoadKeyConfig"].Split(',');
            foreach(var key in LoadKeyConfig)
                try
                {
                    viewData.Add(key, ConfigurationManager.AppSettings[key]);
                }
                catch
                {
                }
        }
    }
}
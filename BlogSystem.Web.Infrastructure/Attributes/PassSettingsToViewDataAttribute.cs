using System;
using System.Configuration;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using BlogSystem.Data.Models;
using BlogSystem.Data.Repositories;

namespace BlogSystem.Web.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PassSettingsToViewDataAttribute : ActionFilterAttribute
    {
        public IDbRepository<Setting> Settings { get; set; }
        public IDbRepository<Service> Services { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var settings = this.Settings.All().ToList();
            var viewData = filterContext.Controller.ViewData;

            foreach(var setting in settings)
            {
                if (viewData.Where(x => x.Key == setting.Key).Count() == 0)
                    viewData.Add(setting.Key, setting.Value);
                else
                    viewData[setting.Key] = setting.Value;
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

            Cache ca = new Cache();
            if (ca["SERVICES"] != null && ca["SERVICES"] != null)
            {
                if (viewData.Where(x => x.Key == "SERVICES").Count() == 0)
                    viewData.Add("SERVICES", ca["SERVICES"]);
                else
                    viewData["SERVICES"] = ca["SERVICES"];
            }
            else
            {
                var services = this.Services.All().Where(x => x.ParentType == "SV" && x.status != -1 && x.isPublish == true).ToList();
                if (viewData.Where(x => x.Key == "SERVICES").Count() == 0)
                    viewData.Add("SERVICES", services);
                else
                    viewData["SERVICES"] = services;
                ca.Insert("SERVICES", services, null, DateTime.MaxValue, TimeSpan.Zero);
            }
        }
    }
}
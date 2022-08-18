namespace BlogSystem.Web
{
    using System.Configuration;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string ThemeUsed = ConfigurationManager.AppSettings["ThemeUsed"];

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Posts",
               url: "Posts/{slug}/{id}",
               defaults: new
               {
                   controller = "Blog",
                   action = "Post"
               },
               namespaces: new[]
               {
                   "BlogSystem.Web.Controllers"
               });

            routes.MapRoute(
                name: "Pages",
                url: "Pages/{slug}/{id}",
                defaults: new
                {
                    controller = "Blog",
                    action = "Page"
                },
                namespaces: new[]
                {
                    "BlogSystem.Web.Controllers"
                });


            routes.MapRoute(
                name: "san-pham",
                url: "san-pham",
                defaults: new { controller = "Product", action = "Index" }
            );

            routes.MapRoute(
                name: "chi-tiet-san-pham",
                url: "chi-tiet-san-pham/{id}",
                defaults: new { controller = "Product", action = "ProductDetail" }
            );

            routes.MapRoute(
                name: "bo-suu-tap",
                url: "bo-suu-tap",
                defaults: new { controller = "Collection", action = "Index" }
            );

            routes.MapRoute(
                name: "chi-tiet-bo-suu-tap",
                url: "chi-tiet-bo-suu-tap",
                defaults: new { controller = "Collection", action = "CollectionDetail" }
            );


            routes.MapRoute(
                name: "y-tuong",
                url: "y-tuong",
                defaults: new { controller = "Idea", action = "Index" }
            );

            routes.MapRoute(
                name: "chi-tiet-y-tuong",
                url: "chi-tiet-y-tuong",
                defaults: new { controller = "Idea", action = "IdeaDetail" }
            );

            routes.MapRoute(
                name: "tin-tuc",
                url: "tin-tuc",
                defaults: new { controller = "MauWeb", action = "Index" }
            );

            routes.MapRoute(
                name: "chinh-sach-quy-dinh",
                url: "chinh-sach-quy-dinh",
                defaults: new { controller = "Home", action = "ChinhSach" }
            );

            routes.MapRoute(
                name: "du-an-da-lam",
                url: "du-an-da-lam",
                defaults: new { controller = "Home", action = "DuAnDaLam" }
            );

            routes.MapRoute(
                name: "gioi-thieu",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "GioiThieu" }
            );

            routes.MapRoute(
                name: "thiet-ke",
                url: "thiet-ke",
                defaults: new { controller = "ThietKeNoiThat", action = "Index" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = string.Format("Index_Theme{0}", ThemeUsed), id = UrlParameter.Optional },
                namespaces: new[] { "BlogSystem.Web.Controllers" });
        }
    }
}
namespace BlogSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            #region PUBLISH
            bundles.Add(new StyleBundle("~/Publish/Theme1/Css")
                .Include("~/Content/Publish/Theme1/css/plugins.min.css")
                .Include("~/Content/Publish/Theme1/css/settings.css")
                .Include("~/Content/Publish/Theme1/css/layers.css")
                .Include("~/Content/Publish/Theme1/css/navigation.css")
                .Include("~/Content/Publish/Theme1/css/style.css")
                );

            bundles.Add(new StyleBundle("~/Publish/Theme3/Css")
                .Include("~/Content/Publish/Theme3/css/preloader.css")
                .Include("~/Content/Publish/Theme3/css/bootstrap.min.css")
                .Include("~/Content/Publish/Theme3/css/slick.css")
                .Include("~/Content/Publish/Theme3/css/metisMenu.css")
                .Include("~/Content/Publish/Theme3/css/owl.carousel.min.css")
                .Include("~/Content/Publish/Theme3/css/animate.min.css")
                .Include("~/Content/Publish/Theme3/css/jquery.fancybox.min.css")
                .Include("~/Content/Publish/Theme3/css/fontAwesome5Pro.css")
                .Include("~/Content/Publish/Theme3/css/ionicons.min.css")
                .Include("~/Content/Publish/Theme3/css/default.css")
                .Include("~/Content/Publish/Theme3/css/style.css")
                );
            #endregion PUBLISH

            #region ADMIN
            bundles.Add(new StyleBundle("~/Admin/Theme1/Css")
                .Include("~/Content/Admin/Theme1/Css/bootstrap.min.css")
                .Include("~/Content/Admin/Theme1/Css/bootstrap-select.css")
                .Include("~/Content/Admin/Theme1/Css/bootstrap-datepicker3.min.css")
                .Include("~/Content/Admin/Theme1/Css/font-awesome.min.css")
                .Include("~/Content/Admin/Theme1/Css/icheck/blue.min.css")
                .Include("~/Content/Admin/Theme1/Css/AdminLTE.css")
                .Include("~/Content/Admin/Theme1/Css/skins/skin-blue.css")
                );
            #endregion ADMIN
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            #region PUBLISH

            bundles.Add(new ScriptBundle("~/Publish/Theme1/js")
                .Include("~/Content/Publish/Theme1/js/plugins.min.js")
                .Include("~/Content/Publish/Theme1/js/main.js")
                .Include("~/Content/Publish/Theme1/js/jquery.themepunch.tools.min.js")
                .Include("~/Content/Publish/Theme1/js/jquery.themepunch.revolution.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.actions.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.carousel.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.kenburn.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.layeranimation.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.migration.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.navigation.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.parallax.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.slideanims.min.js")
                .Include("~/Content/Publish/Theme1/js/extensions/revolution.extension.video.min.js")
                );


            bundles.Add(new ScriptBundle("~/Publish/Theme2/jquery").Include("~/Content/Publish/Theme2/Scripts/js/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Publish/Theme2/jqueryval").Include("~/Content/Publish/Theme2/Scripts/js/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/Publish/Theme2/bootstrap").Include("~/Content/Publish/Theme2/Scripts/js/App.js"));
            bundles.Add(new ScriptBundle("~/Publish/Theme2/modernizr").Include("~/Content/Publish/Theme2/Scripts/js/modernizr-*"));


            bundles.Add(new ScriptBundle("~/Publish/Theme3/modernizr").Include("~/Content/Publish/Theme3/js/vendor/modernizr-3.5.0.min.js"));
            bundles.Add(new ScriptBundle("~/Publish/Theme3/js")
                .Include("~/Content/Publish/Theme3/js/vendor/jquery-3.6.0.min.js",
                        "~/Content/Publish/Theme3/js/vendor/waypoints.min.js",
                        "~/Content/Publish/Theme3/js/bootstrap.bundle.min.js",
                        "~/Content/Publish/Theme3/js/metisMenu.min.js",
                        "~/Content/Publish/Theme3/js/slick.min.js",
                        "~/Content/Publish/Theme3/js/jquery.fancybox.min.js",
                        "~/Content/Publish/Theme3/js/isotope.pkgd.min.js",
                        "~/Content/Publish/Theme3/js/owl.carousel.min.js",
                        "~/Content/Publish/Theme3/js/jquery-ui-slider-range.js",
                        "~/Content/Publish/Theme3/js/ajax-form.js",
                        "~/Content/Publish/Theme3/js/wow.min.js",
                        "~/Content/Publish/Theme3/js/imagesloaded.pkgd.min.js",
                        "~/Content/Publish/Theme3/js/main.js")
                );

            #endregion PUBLISH

            #region ADMIN
            bundles.Add(new ScriptBundle("~/Admin/Theme1/js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/bootstrap/bootstrap.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/fastclick/fastclick.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/moment/moment.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/icheck/icheck.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/validator/validator.js")
                .Include("~/Content/Admin/Theme1/Scripts/Plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/Admin/Theme1/Scripts/adminlte.js")
                .Include("~/Content/Admin/Theme1/Scripts/init.js")
                );
            #endregion ADMIN
        }
    }
}
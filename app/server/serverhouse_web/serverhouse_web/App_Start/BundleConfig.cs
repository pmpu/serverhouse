using System.Globalization;
using System.Web;
using System.Web.Optimization;

namespace serverhouse_web
{
    public class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                   "~/Content/bootstrap/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                   "~/Content/bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/main/css").Include(
                   "~/Content/main.css",

                   "~/Content/libs/sweet_alert/sweet-alert.css",

                   "~/Content/libs/select2/css/select2.css",

                   "~/Content/libs/animate.css",

                   "~/Content/libs/gridster/jquery.gridster.css",

                   "~/Content/libs/lightbox/css/lightbox.css"

                   ));

            bundles.Add(new ScriptBundle("~/main/js").Include(
                    "~/Content/libs/gridster/jquery.gridster.js",
                    "~/Content/libs/sweet_alert/sweet-alert.js",

                   "~/Content/libs/select2/js/select2.js",
                   "~/Content/libs/typeahead/typeahead.jquery.js",

                   "~/Content/libs/select2/js/i18n/en.js",
                   "~/Content/libs/select2/js/i18n/ru.js",

                   "~/Content/libs/noty/jquery.noty.js",

                   "~/Content/libs/lightbox/js/lightbox.js",

                   "~/Content/js/helpers.js",
                   "~/Content/js/ui_helpers.js",
                   "~/Content/js/async_navigation.js"
                   ));

            bundles.Add(new StyleBundle("~/objectEditing").Include(                    
                   "~/Content/js/objectEditing/types/text.js",
                   "~/Content/js/objectEditing/types/image.js",

                   "~/Content/js/objectEditing/object_editing.js"
                   ));

            bundles.Add(new StyleBundle("~/repoView").Include(

                   "~/Content/js/repoView/repo_view.js"

                   ));



        }
           
    }
}
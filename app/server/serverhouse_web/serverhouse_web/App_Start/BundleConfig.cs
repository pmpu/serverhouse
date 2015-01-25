using System.Globalization;
using System.Web;
using System.Web.Optimization;

namespace serverhouse_web
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.js"));

            /*bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));*/

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            /*bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));*/

           /* bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));*/


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



        }
           
    }
}
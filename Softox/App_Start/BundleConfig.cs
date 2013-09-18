using System.Web;
using System.Web.Optimization;

namespace Softox
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Script/javascript").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/site.css"));
        }
    }
}
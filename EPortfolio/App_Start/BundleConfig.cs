using System.Web.Optimization;

namespace EPortfolio.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/javascript").Include(
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                        "~/Content/site.css"));
        }
    }
}
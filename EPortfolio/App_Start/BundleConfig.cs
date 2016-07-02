namespace EPortfolio
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/javascript").Include(
                        "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                        "~/Content/site.css"));
        }
    }
}
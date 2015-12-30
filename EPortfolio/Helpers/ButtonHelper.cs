namespace EPortfolio.Helpers
{
    using System;
    using System.Web;

    public static class ButtonHelper
    {
        public static string FancyboxButton(string link)
        {
            string url = VirtualPathUtility.ToAbsolute(String.Format("~/Content/Images/preview/{0}", link));
            return String.Format(" <a class='fancybox btn btn-primary' href='{0}.png' rel='preview'>Aperçu</a>", url);
        }

        public static string TryButton(string link)
        {
            return String.Format(" <a class='btn btn-success' href='{0}' target='_blank'>Tester</a>", link);
        }

        public static string TryFreeButton(string link)
        {
            return String.Format(" <a class='btn btn-success' href='http://romain.parage.free.fr/{0}' target='_blank'>Tester</a>", link);
        }

        public static string GithubButton(string link)
        {
            return String.Format(" <a class='btn btn-danger' href='https://github.com/softcadbury/{0}' target='_blank'>Sources</a>", link);
        }

        public static string ImageButton(string folder, int num, string tilte = "")
        {
            string url = VirtualPathUtility.ToAbsolute(String.Format("~/Content/Images/galerie/{0}/{1}", folder, num));
            return String.Format(@"
                <div class='col-xs-6 col-sm-4 col-md-3'><a class='fancybox' rel=""{0}"" href='{1}.jpg' title=""{2}"">
	            <img src='{1}x.jpg' alt=""{2}"" /></a></div>", folder, url, tilte);
        }
    }
}
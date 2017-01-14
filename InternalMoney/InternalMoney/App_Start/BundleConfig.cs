using System.Web;
using System.Web.Optimization;

namespace InternalMoney.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
						"~/Scripts/angular.min.js",
						"~/Scripts/app/app.js",
						"~/Scripts/app/login-controller.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.min.css"));
		}
	}
}
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Project.Library.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibraryControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}
using System.Web.Mvc;

namespace koFun.Controllers
{
    public class AppController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
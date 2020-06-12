using System;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CuisineController : Controller
    {
        public ActionResult Search(string name = "french")
        {
            throw new Exception("Something terrible");
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
    }
}
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Test.Features
{
    public class FackHttpControllerContext : ControllerContext
    {
        public override HttpContextBase HttpContext

        { get => new FackHttpContextBase(); set => base.HttpContext = value; }
    }

    public class FackHttpContextBase : HttpContextBase
    {
        public override HttpRequestBase Request => new FackHttpRequest();
    }

    public class FackHttpRequest : HttpRequestBase
    {
        public override string this[string key] => null;
    }
}
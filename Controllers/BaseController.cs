namespace Cooking.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected BaseController(IRecipesData data)
        {
            this.Data = data;
        }

        protected IRecipesData Data { get; private set; }
    }
}
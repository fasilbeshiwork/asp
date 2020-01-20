namespace Cooking.Web.Controllers
{
    using System.Web.Mvc;
    using Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IRecipesData data) : base(data)
        {
        }
    }
}
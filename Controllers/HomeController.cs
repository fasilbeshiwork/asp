namespace Cooking.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
    using AutoMapper.QueryableExtensions;
    using ViewModels;
    using System.Linq;
    using Common;

    public class HomeController : BaseController
    {
        
        public HomeController(IRecipesData data) : base(data)
        {
          
        }

        public ActionResult Index()
        {
            var recipes = this.Data.Recipes
                .All()
                .OrderByDescending(x => x.Votes.Count())
                .Take(GlobalConstants.HomePageNumberOfBookmarks)
                .Project()
                .To<RecipeViewModel>();
            return View(recipes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
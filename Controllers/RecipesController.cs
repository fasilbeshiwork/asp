using System.Net;

namespace Cooking.Web.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data;
    using PagedList;
    using System.Linq;
    using ViewModels;
    using AutoMapper.QueryableExtensions;
    using System.Web.Mvc.Expressions;
    using AutoMapper;
    using Cooking.Models;
    using Cooking.Web.InputModels;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class RecipesController : BaseController
    {
        public RecipesController(IRecipesData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var recipes = this.Data.Recipes
                .All()
                .OrderByDescending(x => x.Title)
                .Project()
                .To<RecipeViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);
            return this.View(recipes);
        }
        public ActionResult Details(int id)
        {
            var recipe = this.Data.Recipes
                .All()
                .Include(x => x.Votes)
                .FirstOrDefault(x => x.Id == id);
            var recipeViewModel = Mapper.Map<RecipeDetailsViewModel>(recipe);

            var userId = this.User.Identity.GetUserId();
            recipeViewModel.UserHasVoted = recipe.Votes.Any(x => x.UserId == userId);
            return this.View(recipeViewModel);
        }

        public ActionResult Create()
        {
            this.LoadCategories();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var recipe = Mapper.Map<Recipe>(model);
                this.Data.Recipes.Add(recipe);
                this.Data.SaveChanges();

                return this.RedirectToAction(x => x.Details(recipe.Id));
            }

            this.LoadCategories();
            return this.View(model);
        }


        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.UserId = this.User.Identity.GetUserId();
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentDb);
            }

            return this.Json("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int commentId)
        {
            var comment = this.Data.Comments
                .All()
                .FirstOrDefault(x => x.Id == commentId);
            if (comment != null && comment.UserId == this.User.Identity.GetUserId())
            {
                this.Data.Comments.Delete(comment);
                this.Data.SaveChanges();

                return this.Content(string.Empty);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not delete the comment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int recipeId)
        {
            var recipe = this.Data.Recipes
                .All()
                .FirstOrDefault(x => x.Id == recipeId);
            if (recipe != null)
            {
                var userHasVoted = recipe.Votes.Any(x => x.UserId == this.User.Identity.GetUserId());
                if (!userHasVoted)
                {
                    this.Data.Votes.Add(new Vote
                    {
                        RecipeId = recipe.Id,
                        UserId = this.User.Identity.GetUserId(),
                        Value = 1
                    });
                    this.Data.SaveChanges();
                }

                var votesCount = recipe.Votes.Sum(x => x.Value);
                return this.Content(votesCount.ToString());
            }

            return new EmptyResult();
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = this.Data.Categories
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });
        }
    }
}
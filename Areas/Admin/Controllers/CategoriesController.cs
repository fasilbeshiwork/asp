namespace Cooking.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Cooking.Web.Controllers;
    using Cooking.Data;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Cooking.Models;
    using Cooking.Web.Areas.Admin.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    public class CategoriesController : AdminController
    {
        // GET: Admin/Categories
        public CategoriesController(IRecipesData data) : base(data)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.Data.Categories
                   .All()
                   .Project()
                   .To<CategoryAdminViewModel>();
            return this.Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Data.Categories.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ProductListing.Data.DAL;
using ProductListing.Data.Domain;
using ProductListing.Web.Client.Models.CategoryViewModels;

namespace ProductListing.Web.Client.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(EFContext db)
        {
            Db = db;
        }

        public EFContext Db { get; }

        public IActionResult Index()
        {
            var CategoryList = Db.Categories.ToList();
            return View(CategoryList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCEViewModel model)
        {
            var entity = new Category();
            entity.Name = model.Name;
            Db.Categories.Add(entity);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var entity = Db.Categories.FirstOrDefault(c => c.Id == Id);
            var model = new CategoryCEViewModel();
            model.Id = entity.Id;
            model.Name = entity.Name;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryCEViewModel model)
        {
            var entity = Db.Categories.FirstOrDefault(c => c.Id == model.Id);
            entity.Name = model.Name;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var entity = Db.Categories.FirstOrDefault(c => c.Id == Id);
            
            return View(entity);
        }

        [HttpPost ,ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int Id)
        {
            var entity = Db.Categories.FirstOrDefault(c => c.Id == Id);
            Db.Categories.Remove(entity);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

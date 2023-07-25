using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductListing.Data.DAL;
using ProductListing.Data.Domain;
using ProductListing.Web.Client.Models.ProductViewModels;

namespace ProductListing.Web.Client.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(EFContext db)
        {
            Db = db;
        }

        public EFContext Db { get; }

        public IActionResult Index()
        {
            var ProductList = Db.Products.ToList();
            return View(ProductList);
        }

        public IActionResult Create() {
            var model = new ProductCEViewModel();
            var categoryList = Db.Categories.ToList();
            foreach (var item in categoryList)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.Id.ToString(); 
                model.CategoryList.Add(selectListItem);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCEViewModel model)
        {
            var entity = new Product();
            entity.Name = model.Name;
            entity.CategoryId = model.CategoryId;   
            entity.Details = model.Details; 
            Db.Products.Add(entity);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var entity = Db.Products.FirstOrDefault(c => c.Id == Id);
            var model = new ProductCEViewModel();
            model.Id = entity.Id;
            model.CategoryId = entity.CategoryId;
            model.Name = entity.Name;
            model.Details = entity.Details;

            var categoryList = Db.Categories.ToList();
            foreach (var item in categoryList)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.Id.ToString();
                model.CategoryList.Add(selectListItem);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductCEViewModel model)
        {
            var entity = Db.Products.FirstOrDefault(c => c.Id == model.Id);
            entity.Name = model.Name;
            entity.CategoryId = model.CategoryId;
            entity.Details = model.Details;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var entity = Db.Products.FirstOrDefault(c => c.Id == Id);
            
            return View(entity);
        }

        [HttpPost ,ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int Id)
        {
            var entity = Db.Products.FirstOrDefault(c => c.Id == Id);
            Db.Products.Remove(entity);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

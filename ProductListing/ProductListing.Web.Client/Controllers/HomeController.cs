using Microsoft.AspNetCore.Mvc;
using ProductListing.Data.DAL;

namespace ProductListing.Web.Client.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(EFContext db)
        {
            Db = db;
        }

        public EFContext Db { get; }

        public IActionResult Index()
        {
            Db.Products.ToList();
            return View();
        }
    }
}

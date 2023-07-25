using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductListing.Web.Client.Models.ProductViewModels
{
    public class ProductCEViewModel

    {
        public ProductCEViewModel()
        {
            CategoryList = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
    }
}

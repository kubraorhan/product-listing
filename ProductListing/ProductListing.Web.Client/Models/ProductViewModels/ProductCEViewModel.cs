using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ProductListing.Web.Client.Models.ProductViewModels
{
    public class ProductCEViewModel

    {
        public ProductCEViewModel()
        {
            CategoryList = new List<SelectListItem>();
        }
        public int Id { get; set; }

        [DisplayName("Kategori")]

        public int CategoryId { get; set; }

        [DisplayName("Ürün Adı")]

        public string Name { get; set; }

        [DisplayName("Ürün Detayı")]

        public string Details { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
    }
}

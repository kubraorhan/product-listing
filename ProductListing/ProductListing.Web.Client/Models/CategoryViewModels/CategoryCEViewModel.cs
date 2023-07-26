using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductListing.Web.Client.Models.CategoryViewModels
{
    public class CategoryCEViewModel
    {

        public int Id { get; set; }

        [DisplayName("Kategori Adı")]

        public string Name { get; set; }
    }
}

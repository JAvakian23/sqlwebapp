using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }
        private readonly IProductService _productService;   
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public void OnGet()
        {
            var configurationManager = new ConfigurationManager();
            Products = _productService.GetProducts();    

        }
    }
}
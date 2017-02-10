using Microsoft.AspNet.Mvc;
using eStore.Models;
using eStore.ViewModels;
using System.Linq;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _db;
        public ProductController(AppDbContext context)
        {
            _db = context;
        }
        // GET: /<controller>/
        public IActionResult Index(BrandViewModel brand)
        {
            ProductModel model = new ProductModel(_db);
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.BrandName = _db.Brands.FirstOrDefault(b => b.Id == brand.BrandId).Name;
            viewModel.Products = model.GetAllByBrand(brand.BrandId);
            return View(viewModel);
        }
    }
}
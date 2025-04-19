using Microsoft.AspNetCore.Mvc;
using ECommerceProductSorting.Data;
using ECommerceProductSorting.Models;
using ECommerceProductSorting.Algorithms;

namespace ECommerceProductSorting.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortBy)
        {
            var products = _context.Products.ToList();

            // Apply sorting
            switch (sortBy)
            {
                case "price":
                    products = QuickSort.Sort(products, p => p.Price);
                    break;
                case "rating":
                    products = QuickSort.Sort(products, p => p.Rating);
                    break;
                case "category":
                    products = QuickSort.Sort(products, p => p.Category);
                    break;
                case "brand":
                    products = QuickSort.Sort(products, p => p.Brand);
                    break;
                default:
                    break;
            }

            return View(products);
        }
    }
}

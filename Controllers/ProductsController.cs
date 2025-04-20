using Microsoft.AspNetCore.Mvc;
using ECommerceProductSorting.Data;
using ECommerceProductSorting.Models;
using ECommerceProductSorting.Algorithms;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceProductSorting.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortBy, string algorithm, string brandFilter, string categoryFilter)
        {
            var products = _context.Products.ToList();

            // Apply filters if provided
            if (!string.IsNullOrEmpty(brandFilter))
            {
                products = BinarySearch.FilterByBrand(products, brandFilter);
            }

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                products = BinarySearch.FilterByCategory(products, categoryFilter);
            }

            // Apply sorting based on algorithm and property
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (algorithm)
                {
                    case "quick":
                        products=ApplyQuickSort(products, sortBy);
                        break;
                    case "merge":
                        products= ApplyMergeSort(products, sortBy);
                        break;
                    case "radix":
                        products= ApplyRadixSort(products, sortBy);
                        break;
                    case "bucket":
                        products = ApplyBucketSort(products, sortBy);
                        break;
                    default:
                        // Default to QuickSort if no algorithm specified
                        products= ApplyQuickSort(products, sortBy);
                        break;
                }
            }

            // Pass filter values to view for maintaining state
            ViewBag.BrandFilter = brandFilter;
            ViewBag.CategoryFilter = categoryFilter;
            
            // Get unique brands and categories for filter dropdowns
            ViewBag.Brands = _context.Products.Select(p => p.Brand).Distinct().OrderBy(b => b).ToList();
            ViewBag.Categories = _context.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();

            return View(products);
        }

        private List<Product> ApplyQuickSort(List<Product> products, string sortBy)
        {
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
                case "name":
                    products = QuickSort.Sort(products, p => p.Name);
                    break;
            }
            return products;
        }

        private List<Product> ApplyMergeSort(List<Product> products, string sortBy)
        {
            switch (sortBy)
            {
                case "price":
                    products = MergeSort.Sort(products, p => p.Price);
                    break;
                case "rating":
                    products = MergeSort.Sort(products, p => p.Rating);
                    break;
                case "category":
                    products = MergeSort.Sort(products, p => p.Category);
                    break;
                case "brand":
                    products = MergeSort.Sort(products, p => p.Brand);
                    break;
                case "name":
                    products = MergeSort.Sort(products, p => p.Name);
                    break;
            }
            return products;
        }

        private List<Product> ApplyRadixSort(List<Product> products, string sortBy)
        {
            switch (sortBy)
            {
                case "price":
                    products = RadixSort.SortByPrice(products);
                    break;
                case "rating":
                    products = RadixSort.SortByRating(products);
                    break;
                case "category":
                    products = RadixSort.SortByString(products, p => p.Category);
                    break;
                case "brand":
                    products = RadixSort.SortByString(products, p => p.Brand);
                    break;
                case "name":
                    products = RadixSort.SortByString(products, p => p.Name);
                    break;
            }
            return products;
        }

        private List<Product> ApplyBucketSort(List<Product> products, string sortBy)
        {
            switch (sortBy)
            {
                case "price":
                    products = BucketSort.SortByPrice(products);
                    break;
                case "rating":
                    products = BucketSort.SortByRating(products);
                    break;
                case "category":
                    products = BucketSort.SortByString(products, p => p.Category);
                    break;
                case "brand":
                    products = BucketSort.SortByString(products, p => p.Brand);
                    break;
                case "name":
                    products = BucketSort.SortByString(products, p => p.Name);
                    break;
            }
            return products;
        }
    }
}

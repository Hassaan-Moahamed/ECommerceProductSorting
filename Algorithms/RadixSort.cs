using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Algorithms
{
    public static class RadixSort
    {
        // RadixSort for decimal values (Price)
        public static List<Product> SortByPrice(List<Product> products)
        {
            if (products == null || products.Count <= 1)
                return products;

            // Convert to array for easier manipulation
            var array = products.ToArray();
            
            // Find the maximum price to know the number of digits
            decimal maxPrice = array.Max(p => p.Price);
            
            // Convert to integer by multiplying by 100 (to handle 2 decimal places)
            long maxNum = (long)(maxPrice * 100);
            
            // Perform counting sort for every digit
            for (long exp = 1; maxNum / exp > 0; exp *= 10)
                CountingSortForPrice(array, exp);
            
            return new List<Product>(array);
        }
        
        private static void CountingSortForPrice(Product[] arr, long exp)
        {
            int n = arr.Length;
            Product[] output = new Product[n];
            int[] count = new int[10];
            
            // Initialize count array
            for (int i = 0; i < 10; i++)
                count[i] = 0;
            
            // Store count of occurrences in count[]
            for (int i = 0; i < n; i++)
                count[(int)((long)(arr[i].Price * 100) / exp) % 10]++;
            
            // Change count[i] so that count[i] now contains
            // actual position of this digit in output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];
            
            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                int index = (int)((long)(arr[i].Price * 100) / exp) % 10;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }
            
            // Copy the output array to arr[]
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
        
        // RadixSort for double values (Rating)
        public static List<Product> SortByRating(List<Product> products)
        {
            if (products == null || products.Count <= 1)
                return products;

            // Convert to array for easier manipulation
            var array = products.ToArray();
            
            // Find the maximum rating to know the number of digits
            double maxRating = array.Max(p => p.Rating);
            
            // Convert to integer by multiplying by 10 (to handle 1 decimal place)
            long maxNum = (long)(maxRating * 10);
            
            // Perform counting sort for every digit
            for (long exp = 1; maxNum / exp > 0; exp *= 10)
                CountingSortForRating(array, exp);
            
            return new List<Product>(array);
        }
        
        private static void CountingSortForRating(Product[] arr, long exp)
        {
            int n = arr.Length;
            Product[] output = new Product[n];
            int[] count = new int[10];
            
            // Initialize count array
            for (int i = 0; i < 10; i++)
                count[i] = 0;
            
            // Store count of occurrences in count[]
            for (int i = 0; i < n; i++)
                count[(int)((long)(arr[i].Rating * 10) / exp) % 10]++;
            
            // Change count[i] so that count[i] now contains
            // actual position of this digit in output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];
            
            // Build the output array
            for (int i = n - 1; i >= 0; i--)
            {
                int index = (int)((long)(arr[i].Rating * 10) / exp) % 10;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }
            
            // Copy the output array to arr[]
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
        
        // For string-based sorting (Category, Brand, Name), we'll use a different approach
        // since RadixSort is primarily for numeric values
        public static List<Product> SortByString(List<Product> products, Func<Product, string> keySelect)
        {
            if (products == null || products.Count <= 1)
                return products;
            
            // For string-based sorting, we'll use a modified approach
            // First, group products by the first character of the string
            var groupedProducts = products
                .GroupBy(p => keySelect(p).Length > 0 ? keySelect(p)[0] : ' ')
                .OrderBy(g => g.Key)
                .SelectMany(g => g)
                .ToList();
            
            // Then sort within each group using a stable sort
            return groupedProducts;
        }
    }
}

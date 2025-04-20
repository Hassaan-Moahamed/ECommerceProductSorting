using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Algorithms
{
    public static class BinarySearch
    {
        // Binary search for filtering by brand
        public static List<Product> FilterByBrand(List<Product> products, string brand)
        {
            if (string.IsNullOrEmpty(brand) || products == null || products.Count == 0)
                return products;

            // First sort the products by brand to enable binary search
            var sortedProducts = QuickSort.Sort(products, p => p.Brand);
            
            // Find the range of products with the matching brand
            int startIndex = FindFirstOccurrence(sortedProducts, brand, p => p.Brand);
            
            if (startIndex == -1)
                return new List<Product>(); // Brand not found
                
            int endIndex = FindLastOccurrence(sortedProducts, brand, p => p.Brand);
            
            // Extract the range of products with matching brand
            return sortedProducts.GetRange(startIndex, endIndex - startIndex + 1);
        }
        
        // Binary search for filtering by category (type)
        public static List<Product> FilterByCategory(List<Product> products, string category)
        {
            if (string.IsNullOrEmpty(category) || products == null || products.Count == 0)
                return products;

            // First sort the products by category to enable binary search
            var sortedProducts = QuickSort.Sort(products, p => p.Category);
            
            // Find the range of products with the matching category
            int startIndex = FindFirstOccurrence(sortedProducts, category, p => p.Category);
            
            if (startIndex == -1)
                return new List<Product>(); // Category not found
                
            int endIndex = FindLastOccurrence(sortedProducts, category, p => p.Category);
            
            // Extract the range of products with matching category
            return sortedProducts.GetRange(startIndex, endIndex - startIndex + 1);
        }
        
        // Helper method to find the first occurrence of a value using binary search
        private static int FindFirstOccurrence<T>(List<Product> sortedList, T value, Func<Product, T> keySelect) where T : IComparable
        {
            int left = 0;
            int right = sortedList.Count - 1;
            int result = -1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = keySelect(sortedList[mid]).CompareTo(value);
                
                if (comparison == 0)
                {
                    // Found a match, but continue searching to the left for the first occurrence
                    result = mid;
                    right = mid - 1;
                }
                else if (comparison < 0)
                {
                    // Value is in the right half
                    left = mid + 1;
                }
                else
                {
                    // Value is in the left half
                    right = mid - 1;
                }
            }
            
            return result;
        }
        
        // Helper method to find the last occurrence of a value using binary search
        private static int FindLastOccurrence<T>(List<Product> sortedList, T value, Func<Product, T> keySelect) where T : IComparable
        {
            int left = 0;
            int right = sortedList.Count - 1;
            int result = -1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = keySelect(sortedList[mid]).CompareTo(value);
                
                if (comparison == 0)
                {
                    // Found a match, but continue searching to the right for the last occurrence
                    result = mid;
                    left = mid + 1;
                }
                else if (comparison < 0)
                {
                    // Value is in the right half
                    left = mid + 1;
                }
                else
                {
                    // Value is in the left half
                    right = mid - 1;
                }
            }
            
            return result;
        }
    }
}

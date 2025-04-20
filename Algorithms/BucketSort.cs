using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Algorithms
{
    public static class BucketSort
    {
        public static List<Product> SortByPrice(List<Product> products, int bucketCount = 10)
        {
            if (products == null || products.Count <= 1)
                return products;

            // Find min and max values
            decimal minValue = products.Min(p => p.Price);
            decimal maxValue = products.Max(p => p.Price);
            
            // Create buckets
            List<Product>[] buckets = new List<Product>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<Product>();
            
            // Distribute elements into buckets
            decimal range = (maxValue - minValue) / bucketCount;
            foreach (var product in products)
            {
                int bucketIndex = range == 0 ? 0 : (int)Math.Min(bucketCount - 1, Math.Floor((product.Price - minValue) / range));
                buckets[bucketIndex].Add(product);
            }
            
            // Sort individual buckets and concatenate
            List<Product> result = new List<Product>();
            foreach (var bucket in buckets)
            {
                // Sort each bucket using insertion sort
                var sortedBucket = InsertionSort(bucket, p => p.Price);
                result.AddRange(sortedBucket);
            }
            
            return result;
        }
        
        public static List<Product> SortByRating(List<Product> products, int bucketCount = 10)
        {
            if (products == null || products.Count <= 1)
                return products;

            // Find min and max values
            double minValue = products.Min(p => p.Rating);
            double maxValue = products.Max(p => p.Rating);
            
            // Create buckets
            List<Product>[] buckets = new List<Product>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<Product>();
            
            // Distribute elements into buckets
            double range = (maxValue - minValue) / bucketCount;
            foreach (var product in products)
            {
                int bucketIndex = range == 0 ? 0 : (int)Math.Min(bucketCount - 1, Math.Floor((product.Rating - minValue) / range));
                buckets[bucketIndex].Add(product);
            }
            
            // Sort individual buckets and concatenate
            List<Product> result = new List<Product>();
            foreach (var bucket in buckets)
            {
                // Sort each bucket using insertion sort
                var sortedBucket = InsertionSort(bucket, p => p.Rating);
                result.AddRange(sortedBucket);
            }
            
            return result;
        }
        
        // For string-based properties (Category, Brand, Name)
        public static List<Product> SortByString(List<Product> products, Func<Product, string> keySelect)
        {
            if (products == null || products.Count <= 1)
                return products;

            // Create 26 buckets for letters A-Z, plus one for non-alphabetic characters
            List<Product>[] buckets = new List<Product>[27];
            for (int i = 0; i < 27; i++)
                buckets[i] = new List<Product>();
            
            // Distribute elements into buckets based on first letter
            foreach (var product in products)
            {
                string key = keySelect(product) ?? "";
                int bucketIndex;
                
                if (key.Length > 0)
                {
                    char firstChar = char.ToUpper(key[0]);
                    if (firstChar >= 'A' && firstChar <= 'Z')
                        bucketIndex = firstChar - 'A';
                    else
                        bucketIndex = 26; // Non-alphabetic
                }
                else
                {
                    bucketIndex = 26; // Empty string
                }
                
                buckets[bucketIndex].Add(product);
            }
            
            // Sort individual buckets and concatenate
            List<Product> result = new List<Product>();
            foreach (var bucket in buckets)
            {
                // Sort each bucket using insertion sort
                var sortedBucket = InsertionSort(bucket, keySelect);
                result.AddRange(sortedBucket);
            }
            
            return result;
        }
        
        // Helper method: Insertion sort for buckets
        private static List<Product> InsertionSort<T>(List<Product> list, Func<Product, T> keySelect) where T : IComparable
        {
            if (list.Count <= 1)
                return list;
                
            var array = list.ToArray();
            
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                int j = i - 1;
                
                while (j >= 0 && keySelect(array[j]).CompareTo(keySelect(key)) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                
                array[j + 1] = key;
            }
            
            return new List<Product>(array);
        }
    }
}

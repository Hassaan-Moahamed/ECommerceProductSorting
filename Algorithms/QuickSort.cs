using System;
using System.Collections.Generic;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Algorithms
{
    public static class QuickSort
    {
    
        public static List<Product> Sort(List<Product> products, Func<Product, IComparable> keySelect)
        {
            
            var array = products.ToArray();
            QuickSortRecursive(array, 0, array.Length - 1, keySelect);
            return new List<Product>(array);
        }

    
        private static void QuickSortRecursive(Product[] arr, int low, int high, Func<Product, IComparable> keySelect)
        {
            if (low < high)
            {
              
                int pivotIndex = Partition(arr, low, high, keySelect);
               
                QuickSortRecursive(arr, low, pivotIndex - 1, keySelect);
                QuickSortRecursive(arr, pivotIndex + 1, high, keySelect);
            }
        }

     
        private static int Partition(Product[] arr, int low, int high, Func<Product, IComparable> keySelect)
        {
         
            var pivot = keySelect(arr[high]);
            int storedInd = low;

            for (int i = low; i < high; i++)
            {           
                if (keySelect(arr[i]).CompareTo(pivot) <= 0)
                {
                    Swap(arr, i, storedInd);
                    storedInd++;
                }
            }
        
            Swap(arr, storedInd, high);
            return storedInd;
        }

     
        private static void Swap(Product[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}


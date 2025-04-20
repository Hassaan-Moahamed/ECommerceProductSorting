using System;
using System.Collections.Generic;
using ECommerceProductSorting.Models;

namespace ECommerceProductSorting.Algorithms
{
    public static class MergeSort
    {
        public static List<Product> Sort(List<Product> products, Func<Product, IComparable> keySelect)
        {
            var array = products.ToArray();
            MergeSortRecursive(array, 0, array.Length - 1, keySelect);
            return new List<Product>(array);
        }

        private static void MergeSortRecursive(Product[] arr, int left, int right, Func<Product, IComparable> keySelect)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSortRecursive(arr, left, mid, keySelect);
                MergeSortRecursive(arr, mid + 1, right, keySelect);
                Merge(arr, left, mid, right, keySelect);
            }
        }

        private static void Merge(Product[] arr, int left, int mid, int right, Func<Product, IComparable> keySelect)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            Product[] leftArray = new Product[n1];
            Product[] rightArray = new Product[n2];

            for (int i = 0; i < n1; ++i)
                leftArray[i] = arr[left + i];
            for (int j = 0; j < n2; ++j)
                rightArray[j] = arr[mid + 1 + j];

            int iIdx = 0, jIdx = 0;
            int k = left;

            while (iIdx < n1 && jIdx < n2)
            {
                // Use Comparer to handle null values correctly
                if (Comparer<IComparable>.Default.Compare(keySelect(leftArray[iIdx]), keySelect(rightArray[jIdx])) <= 0)
                {
                    arr[k] = leftArray[iIdx];
                    iIdx++;
                }
                else
                {
                    arr[k] = rightArray[jIdx];
                    jIdx++;
                }
                k++;
            }

            while (iIdx < n1)
            {
                arr[k] = leftArray[iIdx];
                iIdx++;
                k++;
            }

            while (jIdx < n2)
            {
                arr[k] = rightArray[jIdx];
                jIdx++;
                k++;
            }
        }
    }
}
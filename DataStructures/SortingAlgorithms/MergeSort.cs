using System;

namespace DataStructures.SortingAlgorithms
{
    public class MergeSort
    {

        public static void Sort<T>(T[] arr)
            where T : IComparable
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] Array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                Sort(Array, left, middle);
                Sort(Array, middle + 1, right);
                Merge(Array, left, middle, right);
            }
        }

        private static void Merge<T>(T[] Array, int left, int middle, int right)
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            throw new Exception("Burayı üşneip yazmamışsın");
        }

    }
}

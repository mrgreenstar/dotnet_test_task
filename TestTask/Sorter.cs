using System;
using System.Collections.Generic;

namespace TestTask
{
    public abstract class Sorter
    {
        public static void SortByInsertion<T>(List<T> input) where T : IComparable<T>
        {
            T tmp;
            int j;
            
            for (int i = 1; i < input.Count; i++)
            {
                tmp = input[i];
                j = i;
                while (j > 0 && input[j - 1].CompareTo(tmp) > 0)
                {
                    input[j] = input[j - 1];
                    j--;
                }
                input[j] = tmp;
            }
        }
    }
}
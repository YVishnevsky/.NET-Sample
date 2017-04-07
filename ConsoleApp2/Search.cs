using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Search
    {
        public static int? BinarySearch(this int[] array, int element)
        {
            if ((array.Length == 0) || (element < array[0]) || (element > array[array.Length - 1]))
            {
                return null;
            }

            int firstIndex = 0;
            int length = array.Length;

            while (firstIndex < length)
            {
                int i = firstIndex + (length - firstIndex) / 2;

                if (element <= array[i])
                {
                    length = i;
                }
                else
                {
                    firstIndex = i + 1;
                }
            }

            if (array[length] == element)
            {
                return length;
            }
            else
            {
                return null;
            }
        }
    }
}

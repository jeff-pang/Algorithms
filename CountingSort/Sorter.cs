using System;

namespace CountingSort
{
    public class Sorter
    {
        public void Sort(int[] source,int bucketSize)
        {
            int[] bucket = new int[bucketSize];
            for (int i = 0; i < source.Length; i++)
            {
                int value = source[i];
                bucket[value]++;
            }

            int idx = 0;
            for (int i = 0; i < bucketSize; i++)
            {
                while (bucket[i] > 0)
                {
                    source[idx++] = i;
                    bucket[i]--;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace HeapSort
{
    public class Sorter
    {
        public void Sort(int[] source)
        {
            BuildHeap(source);
            for (int i = source.Length - 1; i >= 1; i--)
            {
                (source[0], source[i]) = (source[i], source[0]);
                Heapify(source, 0, i);
            }
        }
        
        public void BuildHeap(int[] source)
        {
            int mid = source.Length / 2 - 1;

            for (int i = mid; i >= 0; i--)
            {
                Heapify(source, i,source.Length);
            }
        }

        private void Heapify(int[] source, int i, int max)
        {
            (int left, int right, int parent) Children(int parent)
            {
                return (2 * parent + 1, 2 * parent + 2, parent);
            }

            var stack = new Stack<(int left, int right, int parent)>();
            stack.Push(Children(i));
            //heapify
            while (stack.Count > 0)
            {
                var (left, right,parent) = stack.Pop();

                //find max of parent, left and right and make the larges the parent by swapping
                int largest = parent;
                if (left < max && source[left] > source[parent])
                {
                    largest = left;
                }

                if (right < max && source[right] > source[largest])
                {
                    largest = right;
                }

                //if largest is not parent, swap and visit next
                if (largest != parent)
                {
                    (source[parent], source[largest]) = (source[largest], source[parent]);
                    stack.Push(Children(largest));
                }
            }
        }
    }
}
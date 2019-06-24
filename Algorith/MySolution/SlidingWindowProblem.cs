using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
    public class SlidingWindowProblem
    {
        public void Run()
        {
            int[] nums = { 11, 12, 13, 12, 14, 11, 10, 9 };//            { 1, 2, 3, 2, 4, 1, 5, 6, 1 };
            int k = 2;

            SlidingWindow(nums, k);
        }
        private void SlidingWindow(int[] nums, int k)
        {
            //  Queue<int> queue = new Queue<int>();

            LinkedList<int> queue = new LinkedList<int>();

            for (int i = 0; i < k; i++)
            {
                while (queue.Count > 0 && nums[queue.Last.Value] <= nums[i])
                    queue.RemoveLast();


                queue.AddLast(i);


            }

            for (int i = k; i < nums.Length; i++)
            {
                Console.WriteLine(nums[queue.First.Value]);

                while (queue.Count > 0 && queue.First.Value <= (i - k))
                    queue.RemoveFirst();



                while (queue.Count > 0 && nums[queue.Last.Value] < nums[i])
                    queue.RemoveLast();



                queue.AddLast(i);
            }

            Console.WriteLine(nums[queue.First.Value]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
    class EggDropRecursion
    {
        public void Run()
        {
            int eggs = 2;
            int floors = 100;

        //    Console.WriteLine("(Recursion) Minimum number of drops required in worst case with eggs: " + eggs + " and floors:" + floors + " is: " + GetDrops(eggs, floors));

            Console.WriteLine("(DP) Minimum number of drops required in worst case with eggs: " + eggs + " and floors:" + floors + " is: " + GetDropsDP(eggs, floors));
        }

        public int GetDrops(int eggs, int floors)
        {

            if (floors == 0 || floors == 1) return floors;

            if (eggs == 1) return floors;

            int minimumDrops = int.MaxValue, tempResult;

            for (int i = 1; i <= floors; i++)
            {
                tempResult = Math.Max(GetDrops(eggs - 1, i - 1), GetDrops(eggs, floors - i));
                minimumDrops = Math.Min(tempResult, minimumDrops);
            }

            return minimumDrops + 1;
        }

        public int GetDropsDP(int eggs, int floors)
        {
            var eggDrops = new int [eggs + 1,floors + 1];

            for (int i = 1; i < eggs; i++)
            {
                eggDrops[i, 0] = 0;
                eggDrops[i, 1] = 1;
            }

            for (int i = 1  ; i <= floors; i++)
            {
                eggDrops[1, i] = i;
            }


            for (int i = 2  ; i <=eggs; i++)
            {
                for (int j = 2; j <= floors; j++)
                {
                    eggDrops[i, j] = int.MaxValue;

                    int tempResult;
                    for (int k = 1; k <=j; k++)
                    {
                        tempResult = 1 + Math.Max(eggDrops[i - 1, k - 1], eggDrops[i, j - k]);
                        eggDrops[i, j] = Math.Min(tempResult, eggDrops[i, j]);

                    }

                }
            }
            return eggDrops[eggs,floors];


        }
    }
}

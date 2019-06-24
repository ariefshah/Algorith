using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
    class solution
    {
        public void Run()
        {

            var maxTravelDist = 8000;
            List<List<int>>
                forwardRouteList = new List<List<int>>() {
                                            new List<int> { 1, 2000 },new List<int> { 2, 3000 },new List<int> { 3, 6000 },new List<int> { 4, 1000 } };
            //  forwardRouteList =[ [1, 2000],[2,3000] ];


            List<List<int>> returnRouteList = new List<List<int>>(){
                                            new List<int> { 1, 5000 },new List<int> { 2, 2000 },new List<int> { 3,3000 },new List<int> { 4, 7000 } };

            var li = optimalUt(maxTravelDist, forwardRouteList, returnRouteList);

            foreach (var item in li)
            {
                Console.WriteLine(item);
            }

        }

        public List<List<int>> optimalUt(int maxTravelDist, List<List<int>> forwardRouteList, List<List<int>> returnRouteList)
        {
            List<List<int>> ar = new List<List<int>>();

            var tmp = 0;


            foreach (var forwardRoute in forwardRouteList)
            {
                foreach (var returnRoute in returnRouteList)
                {
                    tmp += forwardRoute[1] + returnRoute[1];
                    if (tmp > maxTravelDist) break;


                    ar.Add(forwardRoute);
                    ar.Add(returnRoute);


                }
            }
            ar.Sort();

            return ar;
        }
    }
}

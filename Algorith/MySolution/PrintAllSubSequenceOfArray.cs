using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.MySolution
{
    class PrintAllSubSequenceOfArray
    {
        public void Run()
        {
            int[] arrInput = { 1, 2, 3 };
            PrintAll(arrInput);
        }
        public void PrintAll(int[] arrInput)
        {
            int[] temp = new int[arrInput.Length];
            int index = 0;
            solve(arrInput, index, temp);

        }

        private void solve(int[] arrInput, int index, int[] temp)
        {
            if (index == arrInput.Length)
            {
                Print(arrInput, temp);
                return;
            }

            temp[index] = 1;
            solve(arrInput, index + 1, temp);


            temp[index] = 0;
            solve(arrInput, index + 1, temp);

        }

        private void Print(int[] arrInput, int[] temp)
        {
            string result = "";

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                    result += arrInput[i] + " ";

            }

            if (result == "")
                result = "{Empty Set}";

            Console.WriteLine(result);
        }
    }
}

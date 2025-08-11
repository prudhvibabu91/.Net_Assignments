using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_Q1
{
    internal class SolutionQ1
    {
        public int solution(int[] A)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in A)
            {
                if (num > 0)
                    set.Add(num);
            }

            for (int i = 1; i <= 100001; i++)
            {
                if (!set.Contains(i))
                    return i * i;
            }

            return 0;
        }
    }
}
// Algorithm for Assignment8_Q1:

// 1. Initialize a HashSet to store positive integers from the array.
// 2. Iterate through the array:
//    - If element > 0, add it to the HashSet.
// 3. Start checking from i = 1 upwards:
//    - The first number not found in the HashSet is the smallest missing positive integer.
// 4. Return the square of that integer.
// 5. If no positive integers exist, return 0.
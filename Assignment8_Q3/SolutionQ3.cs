using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_Q3
{
    internal class SolutionQ3
    {
        public int solution(int[] A)
        {

            int sum = 0;

            foreach (int number in A)
            {
                if (number == 0)
                    break;

                if (number > 0)
                    sum += number;
            }

            return sum;
        }
    }
}
// Algorithm for Assignment8_Q3:

// 1. Initialize sum = 0.
// 2. Loop through each element in the array:
//    - If element == 0, stop processing (break).
//    - If element > 0, add it to the sum.
//    - Skip negative numbers.
// 3. Return the final sum.
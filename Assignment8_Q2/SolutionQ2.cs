using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8_Q2
{
    internal class SolutionQ2
    {
        public string solution(int N1, int N2, int Start, int End)
        {

            if (N1 <= 0 || N2 <= 0 || Start <= 0 || End <= 0 || N1 > N2 || Start > End)
            {
                return "0";
            }


            string result = "";
            for (int i = N1; i <= N2; i++)
            {
                for (int j = Start; j <= End; j++)
                {
                    result += $"{i} * {j} = {i * j}\n";
                }
            }

            return result;
        }
    }
}
// Algorithm for Assignment8_Q2:

// 1. Check if any parameter (N1, N2, Start, End) is <= 0.
//    - If so, return "0" as invalid input.
// 2. Initialize a result string.
// 3. Use two nested loops:
//    - Outer loop from N1 to N2.
//    - Inner loop from Start to End.
// 4. For each combination, compute and append "i * j = result" to the string.
// 5. Return the final string containing the full table.
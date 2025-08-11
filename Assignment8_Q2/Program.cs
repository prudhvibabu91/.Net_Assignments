using System;
using System.Collections.Generic;
using Assignment8_Q2;

class Program
{
    static void Main(string[] args)
    {

        int N1 = 2, N2 = 4, Start = 2, End = 6;

        SolutionQ2 sol = new SolutionQ2();
        string result = sol.solution(N1, N2, Start, End);

        Console.WriteLine(result);
    }
}
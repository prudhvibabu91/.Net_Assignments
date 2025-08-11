using System;
using System.Collections.Generic;
using Assignment8_Q1;

class Program
{
    static void Main(string[] args)
    {
        int[] A1 = { 5, 3, -6, -4, 10, 2 };
        int[] A2 = { 1, 2, 3 };
        int[] A3 = { -1, -3 };

        // Creating object of SolutionQ1 class
        SolutionQ1 sol = new SolutionQ1();

        Console.WriteLine("Output 1: " + sol.solution(A1));
        Console.WriteLine("Output 2: " + sol.solution(A2));
        Console.WriteLine("Output 3: " + sol.solution(A3));
    }
}
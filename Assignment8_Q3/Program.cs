using System;
using System.Collections.Generic;
using Assignment8_Q3;
class Program
{
    static void Main(string[] args)
    {

        int[] A = { 5, 3, -6, -4, 10, 2 };


        SolutionQ3 sol = new SolutionQ3();
        int result = sol.solution(A);


        Console.WriteLine("Sum = " + result);
    }
}
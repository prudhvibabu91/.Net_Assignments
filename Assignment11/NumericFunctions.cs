using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    public class NumericFunctions
    {
        public int Add(params int[] numbers) => numbers.Sum();

        public int Subtract(int a, int b) => a - b;

        public int Multiply(params int[] numbers) => numbers.Aggregate(1, (a, b) => a * b);

        public float Divide(float a, float b) => b != 0 ? a / b : throw new DivideByZeroException();

        public int Max(params int[] numbers) => numbers.Max();

        public int Min(params int[] numbers) => numbers.Min();

        public bool IsEven(int number) => number % 2 == 0;

        public bool IsOdd(int number) => number % 2 != 0;

        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        public List<int> EvenInRange(int start, int end) =>
            Enumerable.Range(start, end - start + 1).Where(IsEven).ToList();

        public List<int> OddInRange(int start, int end) =>
            Enumerable.Range(start, end - start + 1).Where(IsOdd).ToList();

        public List<int> PrimesInRange(int start, int end) =>
            Enumerable.Range(start, end - start + 1).Where(IsPrime).ToList();

        public List<string> DisplayTable(int number) =>
            Enumerable.Range(1, 10).Select(i => $"{number} x {i} = {number * i}").ToList();

        public Dictionary<int, List<string>> DisplayTables1To10InRange(int start, int end)
        {
            var result = new Dictionary<int, List<string>>();
            for (int n = start; n <= end; n++)
                result[n] = DisplayTable(n);
            return result;
        }

        public Dictionary<int, List<string>> DisplayTablesInRange(int tableStart, int tableEnd, int numberStart, int numberEnd)
        {
            var result = new Dictionary<int, List<string>>();
            for (int n = numberStart; n <= numberEnd; n++)
            {
                var lines = new List<string>();
                for (int i = tableStart; i <= tableEnd; i++)
                    lines.Add($"{n} x {i} = {n * i}");
                result[n] = lines;
            }
            return result;
        }

        public int Reverse(int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;
            }
            return reversed;
        }
    }
}

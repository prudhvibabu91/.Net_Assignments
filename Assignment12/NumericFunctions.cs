namespace Assignment12
{
    public class NumericFunctions
    {
        public int Add(params int[] numbers) => numbers.Sum();

        public int Subtract(int a, int b) => a - b;

        public int Multiply(params int[] numbers)
        {
            int result = 1;
            foreach (int num in numbers)
                result *= num;
            return result;
        }

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
            Enumerable.Range(start, end - start + 1).Where(x => x % 2 == 0).ToList();

        public List<int> OddInRange(int start, int end) =>
            Enumerable.Range(start, end - start + 1).Where(x => x % 2 != 0).ToList();

        public List<int> PrimesInRange(int start, int end) =>
            Enumerable.Range(start, end - start + 1).Where(IsPrime).ToList();

        public List<string> DisplayTable(int number) =>
            Enumerable.Range(1, 10).Select(i => $"{number} x {i} = {number * i}").ToList();

        public int Reverse(int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reversed = reversed * 10 + digit;
                number /= 10;
            }
            return reversed;
        }
    }
}


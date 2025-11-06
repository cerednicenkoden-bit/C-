namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] randomArray = GenerateRandomArray(10, 1, 100);
            Console.WriteLine("Generated Array: " + string.Join(", ", randomArray));
            Console.WriteLine("Sum: " + GetSum(randomArray));
            Console.WriteLine("Average: " + GetAverage(randomArray));
            Console.WriteLine("Min: " + GetMin(randomArray));
            Console.WriteLine("Max: " + GetMax(randomArray));
        }

        public static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
            return array;
        }

        public static int GetSum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }

        public static double GetAverage(int[] array)
        {
            if (array.Length == 0) return 0;
            return (double)GetSum(array) / array.Length;
        }

        public static int GetMin(int[] array)
        {
            if (array.Length == 0) throw new ArgumentException("Array cannot be empty");
            int min = array[0];
            foreach (int num in array)
            {
                if (num < min) min = num;
            }
            return min;
        }

        public static int GetMax(int[] array)
        {
            if (array.Length == 0) throw new ArgumentException("Array cannot be empty");
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max) max = num;
            }
            return max;
        }
    }
}

namespace Task1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            int? number = int.TryParse(Console.ReadLine(), out int result) ? result : null;
            Console.WriteLine(number.HasValue ? GetMessage(number.Value) : "Invalid input. Please enter a valid integer.");
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static string GetMessage(int number)
        {
            return IsEven(number) ? "Двері відкриваються!" : "Двері зачинені...";
        }
    }
}

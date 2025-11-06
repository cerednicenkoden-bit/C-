
namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] studentGroups = new int[][]
            {
                new int[] { 85, 90, 78, 92 },
                new int[] { 88, 76, 95, 89 },
                new int[] { 90, 91, 85, 87 }
            };
            for (int i = 0; i < studentGroups.Length; i++)
            {
                int[] marks = studentGroups[i];
                double average = GetAverage(marks);
                int min = GetMin(marks);
                int max = GetMax(marks);

                Console.WriteLine($"Group {i + 1}: Average = {average:F2}, Min = {min}, Max = {max}");
            }
        }

        public static double GetAverage(int[] marks)
        {
            double sum = 0;
            foreach (int mark in marks)
            {
                sum += mark;
            }
            return sum / marks.Length;
        }

        public static int GetMin(int[] marks)
        {
            int min = marks[0];
            foreach (int mark in marks)
            {
                if (mark < min)
                    min = mark;
            }
            return min;
        }

        public static int GetMax(int[] marks)
        {
            int max = marks[0];
            foreach (int mark in marks)
            {
                if (mark > max)
                    max = mark;
            }
            return max;
        }
    }
}

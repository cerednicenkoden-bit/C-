
namespace Task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the lengths of the three sides of the triangle:");
            double a = double.TryParse(Console.ReadLine(), out var sideA) ? sideA : -1;
            double b = double.TryParse(Console.ReadLine(), out var sideB) ? sideB : -1;
            double c = double.TryParse(Console.ReadLine(), out var sideC) ? sideC : -1;

            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("The lengths do not form a valid triangle.");
                return;
            }

            double perimeter = GetPerimeter(a, b, c);
            double area = GetArea(a, b, c);
            string triangleType = GetTriangleType(a, b, c);

            Console.WriteLine($"Perimeter: {perimeter}");
            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Triangle Type: {triangleType}");
        }

        public static bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("Invalid triangle sides");
            }
            return a + b + c;
        }

        public static double GetArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("Invalid triangle sides");
            }
            double s = GetPerimeter(a, b, c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                throw new ArgumentException("Invalid triangle sides");
            }
            if (a == b && b == c)
            {
                return "рівносторонній";
            }
            else if (Math.Abs(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) < 0.0001)
            {
                return "прямокутний";
            }
            else if (a == b || a == c || b == c)
            {
                return "рівнобедрений";
            }
            else
            {
                return "довільний";
            }
        }
    }
}

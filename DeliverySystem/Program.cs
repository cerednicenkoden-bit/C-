namespace DeliverySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Vehicle scooter = new Scooter("Xiaomi", 2023, 1200, 30);
            Vehicle car = new Car("Toyota", 2021, 34000, 4);
            Vehicle van = new Van("Ford", 2020, 56000, 5, 1000);

            Console.WriteLine(scooter.GetInfo());
            Console.WriteLine($"Max speed: {scooter.GetMaxSpeed()} km/h");
            scooter.Move(20);
            ((Scooter)scooter).Charge();

            Console.WriteLine(car.GetInfo());
            Console.WriteLine($"Max speed: {car.GetMaxSpeed()} km/h");
            car.Move(50);

            Console.WriteLine(van.GetInfo());
            Console.WriteLine($"Max speed: {van.GetMaxSpeed()} km/h");
            ((Van)van).LoadCargo(800);
            Console.WriteLine(van.GetInfo());
            ((Van)van).LoadCargo(300);
            ((Van)van).UnloadCargo();
        }
    }
}

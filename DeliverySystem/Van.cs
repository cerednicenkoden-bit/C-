using System;

namespace DeliverySystem;

public class Van : Car
{
    private double loadCapacity;
    private double currentLoad;

    public Van(string brand, int year, double mileage, int doors, double loadCapacity)
        : base(brand, year, mileage, doors, maxSpeed: 140.0)
    {
        this.loadCapacity = loadCapacity;
        currentLoad = 0;
        fuelLevel = 50; 
    }

    public override string GetInfo()
    {
        return $"Van: {brand} ({year}), Doors: {doors}, Load: {currentLoad}/{loadCapacity}kg, Fuel: {fuelLevel}L";
    }

    public void LoadCargo(double weight)
    {
        if (currentLoad + weight <= loadCapacity)
        {
            currentLoad += weight;
            Console.WriteLine($"{weight} kg loaded into the van.");
        }
        else
        {
            Console.WriteLine("Too heavy! Cannot load more cargo.");
        }
    }

    public void UnloadCargo()
    {
        currentLoad = 0;
        Console.WriteLine("Van unloaded.");
    }
}

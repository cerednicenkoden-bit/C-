using System;

namespace DeliverySystem;

public class Car : Vehicle
{
    protected int doors;
    protected double fuelLevel;

    public Car(string brand, int year, double mileage, int doors) : base(brand, year, mileage, maxSpeed: 180.0)
    {
        this.doors = doors;
        this.fuelLevel = 50;  
    }

    public Car(string brand, int year, double mileage, int doors, double maxSpeed) : base(brand, year, mileage, maxSpeed)
    {
        this.doors = doors;
        this.fuelLevel = 50;  
    }

    public override string GetInfo()
    {
        return $"Car: {brand} ({year}), Doors: {doors}, Fuel: {fuelLevel}L";
    }

    public override void Move(double distance)
    {
        base.Move(distance);
        fuelLevel -= distance * 0.1;
        if (fuelLevel < 0) fuelLevel = 0;
    }

    public void Refuel(double liters)
    {
        fuelLevel += liters;
        if (fuelLevel > 50) fuelLevel = 50;
    }
}

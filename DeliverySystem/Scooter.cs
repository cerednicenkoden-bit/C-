using System;

namespace DeliverySystem;

public class Scooter : Vehicle
{
    private int batteryCapacity;  
    private double batteryLevel;  


    public Scooter(string brand, int year, double mileage, int batteryCapacity)
        : base(brand, year, mileage, maxSpeed: 45.0)
    {
        this.batteryCapacity = batteryCapacity;
        this.batteryLevel = 100;  
    }

    public override string GetInfo()
    {
        return $"Scooter: {brand} ({year}), Battery: {batteryLevel}% of {batteryCapacity}Ah";
    }

    public override void Move(double distance)
    {
        base.Move(distance);
        batteryLevel -= distance * 0.5;
        if (batteryLevel < 0) batteryLevel = 0;
    }

    public void Charge()
    {
        batteryLevel = 100;
        Console.WriteLine($"{brand} has been fully charged.");
    }
}

using System;

namespace DeliverySystem;

public class Vehicle
{
    protected string brand;
    protected int year;
    protected double mileage;
    protected double maxSpeed;

    public Vehicle(string brand, int year, double mileage, double maxSpeed)
    {
        this.brand = brand;
        this.year = year;
        this.mileage = mileage;
        this.maxSpeed = maxSpeed;
    }

    public virtual string GetInfo()
    {
        return $"{brand} ({year}), Mileage: {mileage} km";
    }

    public virtual double GetMaxSpeed()
    {
        return maxSpeed;
    }

    public virtual void Move(double distance)
    {
        mileage += distance;
        Console.WriteLine($"{brand} drove {distance} km.");
    }
}

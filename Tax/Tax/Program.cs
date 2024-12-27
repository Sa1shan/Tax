namespace Tax;

public abstract class Property
{
    public Double Worth;

    public Property(Double worth)
    {
        Worth = worth;
    }

    public abstract string ToString();
    public abstract double CalculateTax();
}

public abstract class Immovable : Property
{
    public double Area;
    protected Immovable(double worth, double area) : base(worth)
    {
        Area = area;
    }
    
    public override double CalculateTax()
    {
        if (Area < 100)
        {
            return Worth / 500;
        }
        else if (Area >= 100 && Area < 300)
        {
            return Worth / 350;
        }
        return Worth / 250;
    }

    public double ReturnCost()
    {
        return Worth / Area;
    }
}

class Apartament : Immovable
{
    public Apartament(double worth, double area) : base(worth, area)
    {
        
    }

    public override string ToString()
    {
        return $"Квартира: Стоимость - {Worth}, налог - {CalculateTax()}, площадь - {Area} кв.м";
    }
}

class Vilage : Immovable
{
    public Vilage(double worth, double area) : base(worth, area)
    {
    }

    public override string ToString()
    {
        return $"Дача: Стоимость - {Worth}, налог - {CalculateTax()}, площадь - {Area} кв.м";
    }
}

public abstract class Vehicle : Property
{
    public double EngineValue;
    
    public Vehicle(double worth, double engineValue) : base(worth)
    {
        EngineValue = engineValue;
    }

    public override double CalculateTax()
    {
        return Worth * EngineValue / 3000;
    }
}

class Car : Vehicle
{
    public Car(double worth, double engineValue) : base(worth, engineValue)
    {
    }

    public override string ToString()
    {
        return $"Машина: Стоимость - {Worth}, налог - {CalculateTax()}, объем двигателя - {EngineValue} см.куб";
    }
}

class Boat : Vehicle
{
    public Boat(double worth, double engineValue) : base(worth, engineValue)
    {
    }

    public override string ToString()
    {
        return $"Лодка: Стоимость - {Worth}, налог - {CalculateTax()}, объем двигателя - {EngineValue} см.куб";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Property[] properties = new Property[10]
        {
            new Apartament(5000000, 90),
            new Apartament(7000000, 120),
            new Apartament(9000000, 350),
            new Car(2000000, 2000),
            new Car(1500000, 1500),
            new Car(2500000, 3000),
            new Boat(400000, 2666),
            new Boat(1200000, 3500),
            new Vilage(10000000, 350),
            new Vilage(8000000, 200)
        };

        foreach (var property in properties)
        {
            Console.WriteLine(property.ToString());
        }
    }
}
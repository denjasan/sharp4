using System.Security.Cryptography;

var car1 = new Car("Zigul", 2001, 250);
var car2 = new Car("Panamera", 2010, 200);
var car3 = new Car("Porche Cayene", 2020, 300);
var list = new List<Car> {car1, car2, car3 };

list.Sort(new CarComparer("Name"));
Console.WriteLine("Name sort:");
for (var i = 0; i < 3; i++)
{
    list[i].Print();
}

list.Sort(new CarComparer("ProductionYear"));
Console.WriteLine("\nProductionYear sort:");
for (var i = 0; i < 3; i++)
{
    list[i].Print();
}

list.Sort(new CarComparer("MaxSpeed"));
Console.WriteLine("\nMaxSpeed sort:");
for (var i = 0; i < 3; i++)
{
    list[i].Print();
}



internal class Car
{
    public string Name { set; get;}
    public int ProductionYear { set; get;}
    public double MaxSpeed { set; get;}

    public Car(string name, int productionYear, double maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

    public void Print()
    {
        Console.WriteLine($"{Name}: {ProductionYear}; {MaxSpeed}");
    }
}

internal class CarComparer : IComparer<Car>
{
    private readonly string _type;
    
    public CarComparer(string type)
    {
        _type = type;
    }
    
    public int Compare(Car? car1, Car? car2)
    {
        if (ReferenceEquals(car1, car2)) return 0;
        if (ReferenceEquals(null, car2)) return 1;
        if (ReferenceEquals(null, car1)) return -1;
        return _type switch
        {
            "Name" => string.Compare(car1.Name, car2.Name, StringComparison.Ordinal),
            "ProductionYear" => car1.ProductionYear.CompareTo(car2.ProductionYear),
            "MaxSpeed" => car1.MaxSpeed.CompareTo(car2.MaxSpeed),
            _ => string.Compare(car1.Name, car2.Name, StringComparison.Ordinal)
        };
    }
}




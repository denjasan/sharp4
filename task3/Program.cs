var car1 = new Car("Zigul", 2001, 250);
var car2 = new Car("Panamera", 2010, 200);
var car3 = new Car("Porche Cayene", 2020, 300);
CarsCatalog cars = new(car1, car2, car3);

Console.WriteLine("Normal:");
foreach(var car in cars)
{
    car.Print();
}

Console.WriteLine("\nReverse:");
foreach(var car in cars.Reverse())
{
    car.Print();
}

Console.WriteLine("\nProductionYear:");
foreach(var car in cars.ProductionYear())
{
    car.Print();
}

Console.WriteLine("\nMaxSpeed:");
foreach(var car in cars.MaxSpeed())
{
    car.Print();
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


internal class CarsCatalog
{
    private readonly List<Car> _cars = new();

    public CarsCatalog(params Car[] cars)
    {
        foreach (var t in cars)
        {
            _cars.Add(t);
        }
    }
    
    public IEnumerator<Car> GetEnumerator()
    {
        return ((IEnumerable<Car>)_cars).GetEnumerator();
    }

    public IEnumerable<Car> Reverse()
    {
        for (var i = _cars.Count - 1; i >= 0; --i)
        {
            yield return _cars[i];
        }
    }

    public IEnumerable<Car> ProductionYear()
    {
        _cars.Sort(new CarComparer("ProductionYear"));
        foreach (var t in _cars)
        {
            yield return t;
        }
    }

    public IEnumerable<Car> MaxSpeed()
    {
        _cars.Sort(new CarComparer("MaxSpeed"));
        foreach (var t in _cars)
        {
            yield return t;
        }
    }
}

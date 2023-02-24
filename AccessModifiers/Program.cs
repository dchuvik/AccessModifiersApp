internal class Program
{
    private static void Main(string[] args)
    {
        Car toyota = new Car { Make = "Toyota", Model = "Camry", CountryOfOrigin = "Japan", NumberOfWheels = 4, Year = 2010 };
        Car honda = new Car { Make = "Honda", Model = "Civic", CountryOfOrigin = "Japan", NumberOfWheels = 4, Year = 2004 };
        Car subaru = new Car { Make = "Subaru", Model = "Legacy", CountryOfOrigin = "Japan", Year = 2020, NumberOfWheels = 4 };
        Motorcycle yamaha = new Motorcycle { Make = "Yamaha", Model = "R6", NumberOfWheels = 2, CountryOfOrigin = "Japan", Year = 2000 };
        Motorcycle harley = new Motorcycle { Make = "Harley", Model = "Davidson", CountryOfOrigin = "USA", Year = 2012, NumberOfWheels = 2 };

        List<IRent> rentables = new List<IRent>();
        List<IPurchase> purchasables = new List<IPurchase>();

        purchasables.Add(toyota);
        purchasables.Add(honda);
        purchasables.Add(subaru);
        rentables.Add(harley);
        rentables.Add(yamaha);

        Console.Write("Hello! would you like to rent or buy? (rent/buy): ");
        string userAnswer = Console.ReadLine().ToLower();
        bool isDone = false;

        do
        {
            if (userAnswer == "rent")
            {
                int count = 0;
                Console.WriteLine($"Here's the rentals we have in stock: \n");
                foreach (var rentable in rentables)
                {
                    Console.WriteLine($"{count}:  {rentable.Year} {rentable.Make} {rentable.Model}");
                    count++;
                }
                Console.Write($"Which would you like, enter the number: ");
                int numberVehicle = int.Parse(Console.ReadLine());

                var UserSelectedVehicle = rentables.ToArray()[numberVehicle];
                UserSelectedVehicle.Rent();
                Console.WriteLine();
                isDone= true;
            }
            else if (userAnswer == "buy")
            {
                int count = 0;
                Console.WriteLine($"Here's the rentals we have in stock: \n");
                foreach (var puchasable in purchasables)
                {
                    Console.WriteLine($"{count}:  {puchasable.Year} {puchasable.Make} {puchasable.Model}");
                    count++;
                }
                Console.Write($"Which would you like, enter the number: ");
                int numberVehicle = int.Parse(Console.ReadLine());

                var UserSelectedVehicle = purchasables.ToArray()[numberVehicle];
                UserSelectedVehicle.Buy();
                Console.WriteLine();
                isDone= true;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                break;
            }
        } while (!isDone);





    }
}

public interface IVehicleInfo
{
    int Year { get; set; }
    string Make { get; set; }
    string Model { get; set; }
}

public abstract class Vehicle : IVehicleInfo
{
    public string CountryOfOrigin { get; set; }
    public int NumberOfWheels { get; set; }
    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
}


public interface IPurchase : IVehicleInfo
{
    public void Buy();
}

public interface IRent : IVehicleInfo
{
    public void Rent();

    public void Return();
}


public class Car : Vehicle, IPurchase, IRent
{
    public string Make { get; set; }
    public string Model { get; set; }

    public void Buy()
    {
        Console.WriteLine("Buying a Car");
    }

    public void Rent()
    {
        Console.WriteLine("renting a Car");
    }

    public void Return()
    {
        Console.WriteLine("returning a Car");
    }
}

public class Motorcycle : Vehicle, IPurchase, IRent
{
    public string Make { get; set; }
    public string Model { get; set; }

    public void Buy()
    {
        Console.WriteLine("Buying a Motorcycle");
    }

    public void Rent()
    {
        Console.WriteLine("Renting a Motorcycle");
    }

    public void Return()
    {
        Console.WriteLine("Returning a Motorcycle");
    }
}



using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

public class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach(var car in carManager.GetByDailyPrice(300,350))
        {
            Console.WriteLine(car.Description);
        }
    }
}
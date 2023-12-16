using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

public class Program
{
    private static void Main(string[] args)
    {
        //
        //Ekle();
        

        //Sil();
       // CarTest();
    }

    private static void Sil()
    {
        CarManager carManager3 = new CarManager(new EfCarDal());
        carManager3.Delete(2);
    }

    private static void Ekle()
    {
        CarManager carManager2 = new CarManager(new EfCarDal());
        var result = new Car { CarId = 4, BrandId = 1, CarName = "Pegout", DailyPrice = 325, ColorId = 1, ModelYear = 2001 };
        carManager2.Add(result);
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetCarDetailDtos())
        {
            Console.WriteLine("Araba:"+ car.CarName+"Marka:"+car.BrandName+ "Renk:"+ car.ColorName + "Fiyat:" + car.DailyPrice);
        }
    }//CarName, BrandName, ColorName, DailyPrice
}
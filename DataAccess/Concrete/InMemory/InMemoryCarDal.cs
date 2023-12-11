using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal() 
        {
            _cars = new List<Car>
            { 
                new Car {Id=1,BrandId=1,ColorId=1,ModelYear=2000,DailyPrice=20,Description="MAZDA"},
                new Car {Id=2,BrandId=2,ColorId=1,ModelYear=2015,DailyPrice=25,Description="AUDİ"},
                new Car {Id=3,BrandId=3,ColorId=2,ModelYear=2018,DailyPrice=30,Description="MERCEDES"},
                new Car {Id=4,BrandId=4,ColorId=2,ModelYear=2020,DailyPrice=40,Description="TOGG"},
                new Car {Id=5,BrandId=2,ColorId=3,ModelYear=2019,DailyPrice=25,Description="AUDİSLX"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=>c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate=_cars.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.Description=car.Description;
            
        }
    }
}

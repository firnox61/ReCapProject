using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal) 
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(true, "Araba başarılı bir şekilde eklendi");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrand(int id)
        {
           return _carDal.GetAll(c=>c.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        }

        public Car GetById(int CarId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetails();
        }


    }
}

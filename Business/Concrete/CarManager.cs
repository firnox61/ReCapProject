using Business.Abstract;
using Business.BusinessAspect.Aspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //busines kodu ayrı validasyon(doğrulama) ayrı yazılır
        [SecuredOperation("car.add,admin")]//düzgün çalışıyo
        [ValidationAspect(typeof(CarValidator))]//düzgün çalışıyo
        [CacheRemoveAspect("ICarService.Get")]//oradaki tüm getleri siler
        public IResult Add(Car car)
        {

            
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheRemoveAspect("ICarService.Get")]//oradaki tüm getleri siler
        public IResult Update(Car car)
        {
            if (car.CarName == null)
            {
                return new ErrorResult();
            }
            _carDal.Update(car);
            return new SuccessResult();
        }
        public IResult Delete(string CarName)
        {
            var result = _carDal.Get(c => c.CarName == CarName);
            if (result == null)
            {
                return new ErrorResult();
            }
            _carDal.Delete(result);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrand(int id)
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == id),Messages.CarFindBrand);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max));
        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId), Messages.CarAdded);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {

            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNameInvalid);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }


    }
}

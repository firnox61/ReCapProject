using Business.Abstract;
using Business.BusinessAspect.Aspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
using System.Drawing;
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
        // [CacheRemoveAspect("ICarService.Get")]//oradaki tüm getleri siler
        //busines kodu ayrı validasyon(doğrulama) ayrı yazılır
        // [SecuredOperation("car.add,admin")]//düzgün çalışıyo
       // [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]//düzgün çalışıyo
        public IResult Add(Car car)
        {

            
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheRemoveAspect("ICarService.Get")]//oradaki tüm getleri siler
       // [SecuredOperation("admin")]
        public IResult Update(Car car)
        {
            if (car.CarName == null)
            {
                return new ErrorResult();
            }
            _carDal.Update(car);
            return new SuccessResult();
        }
       // [SecuredOperation("admin")]
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
        [CacheAspect]//başarılı
        //[SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
       // [SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId == id),Messages.CarFindBrand);
        }
       // [SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarFindColor);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max));
        }
        [CacheAspect]
        [PerformanceAspect(5)]//çalışma süresi 5 saniyeden fazlaysa haber eder
       // [SecuredOperation("admin,user")]
        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId), Messages.CarByIdShow);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {

            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNameInvalid);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailShow);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<CarDetailDto> GetCarDetailId(int id)
        {

            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<CarDetailDto>(Messages.CarNameInvalid);
            }
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailId(id), Messages.CarDetailIdShow);
        }
        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarByBrandAndColor(brandName, colorName), Messages.CarDetailListedBrandAndColor);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception(Messages.CarPriceInvalid);
            }
            Add(car);
            return null;
        }

      

        //public IDataResult<CarDetailDto> GetByDetailId(int id)
        //{
        //    return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(id));
        //}


    }
}

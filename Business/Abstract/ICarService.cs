using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);

        IDataResult<CarDetailDto> GetCarDetailId(int id);


        IDataResult<List<Car>> GetByDailyPrice(decimal min,  decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<Car> GetById(int CarId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(string CarName);
        IResult AddTransactionalTest(Car car);
      //  IDataResult<CarDetailDto> GetByDetailId(int id);
      //  IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId);

    }
}

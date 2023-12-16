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
        IDataResult<List<Car>> GetAllByBrand(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min,  decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<Car> GetById(int CarId);
        IResult Add(Car car);
        
    }
}

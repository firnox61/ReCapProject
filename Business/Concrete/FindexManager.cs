using Business.Abstract;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindexManager:IFindexService
    {
        ICustomerService _customerService;
        ICarService _carService;

        public FindexManager(ICustomerService customerService, ICarService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public IDataResult<int> GetCarMinFindexScore(int carId)
        {
           var carResult=_carService.GetById(carId);
            if (carResult.Success) 
            {
                return new SuccessDataResult<int>(carResult.Data.MinFindexPoint);
            }
            return new ErrorDataResult<int>(-1,carResult.Message);
        }

        public IDataResult<int> GetCustomerFindexScore(int customerId)
        {
            var customerResult=IsCustomerIdExist(customerId);
            if(customerResult.Success)
            {
                Random random = new Random();
                int randomFindexScore=Convert.ToInt16(random.Next(0, 1900));
                return new SuccessDataResult<int>(randomFindexScore);
            }
            return new ErrorDataResult<int>(-1,customerResult.Message);
        }

        private IResult IsCustomerIdExist(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

    }
}

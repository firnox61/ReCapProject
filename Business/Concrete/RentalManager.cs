using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int RentalId)
        {
            var result = _rentalDal.Get(r => r.Id == RentalId);
            if (result == null)
            {
                return new ErrorResult();
            }
            _rentalDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == RentalId), Messages.CarAdded);
        }

        public IResult Update(Rental rental)
        {
     
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}

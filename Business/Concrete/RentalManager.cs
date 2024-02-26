using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections;
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
            if (!_rentalDal.IsCarAvailableForRental(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new ErrorResult(Messages.TarihHata);
            }

            else
            {   
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarAdded);


            }
            //    var result=_rentalDal.GetAll(r=>r.CarId == rental.CarId
            //    && r.RentDate < rental.ReturnDate && r.ReturnDate > rental.RentDate).Any();


            //    if (result ==true)
            //    {
            //        return new ErrorResult(Messages.TarihHata);
            //    }
            //    else
            //    {

            //        _rentalDal.Add(rental);
            //        return new SuccessResult(Messages.CarAdded);
            //    }



        }
        public IResult RentalDateControl(int carId, DateTime start, DateTime end)
        {




            if(!_rentalDal.IsCarAvailableForRental( carId,  start,  end))
            {
                return new ErrorResult(Messages.TarihHata);
            }

            else
            {
                return new SuccessResult(Messages.TarihUygun);
               

            }

         
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

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.CarListed);
        }

       

        public IResult Update(Rental rental)
        {
     
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }

}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;
        IFindexService _findexService;
        public RentalManager(IRentalDal rentalDal, IFindexService findexService)
        {
            _rentalDal = rentalDal;
            _findexService = findexService;

        }
       
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {


            IResult result = BusinessRules.Run(CheckRentalFindex(rental));
            if (result != null)//kurala uymayan bir durum oluşmuşsa
            {
                return result;
            }

             if (!_rentalDal.IsCarAvailableForRental(rental.CarId, rental.RentDate, rental.ReturnDate))
             {
                 return new ErrorResult(Messages.TarihHata);
             }

             else
             {   
                 _rentalDal.Add(rental);
                 return new SuccessResult(Messages.CarAdded);
             }
            


        }
        public IDataResult<Rental> RentalDateControl(int carId, DateTime start, DateTime end)
        {




            if(!_rentalDal.IsCarAvailableForRental( carId,  start,  end))
            {
                return new ErrorDataResult<Rental>(Messages.TarihHata);
            }

            else
            {
                return new SuccessDataResult<Rental>(Messages.TarihUygun);
               

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


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
     
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        private IResult CheckRentalFindex(Rental rental)
        {
          var result1=_findexService.GetCarMinFindexScore(rental.CarId);
          var result2=_findexService.GetCustomerFindexScore(rental.CustomerId);

            if(result1.Data<=result2.Data)
            {
                return new SuccessResult(Messages.FindexAccepted);
            }
            return new ErrorResult(Messages.FindexRejected);
        }
      //private IResult CheckCustomerFindex
    }

}

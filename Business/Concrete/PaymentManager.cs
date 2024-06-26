﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal payment) 
        {
            _paymentDal = payment;
        }
        [ValidationAspect(typeof(PaymentValidator))]
       // [CacheRemoveAspect("IPaymentService.GetAll()")]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.BuyAccepted);
        }
        [CacheRemoveAspect("IPaymentService.GetAll()")]
        public IResult Delete(Payment payment)
        {
            var result = _paymentDal.Get(p => p.Id == payment.Id);
            if(result != null)
            {
                _paymentDal.Delete(result);
                return new SuccessResult(Messages.PaymentDelete);
            }
            else
            {
                return new ErrorResult();
            }

        }

        public IDataResult<Payment> Get(int id)
        {
            
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id));
        }
        [CacheAspect(60)]
        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<List<Payment>> GetCustomerByPayment(int customerId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p => p.CustomerId == customerId));
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }
    }
}

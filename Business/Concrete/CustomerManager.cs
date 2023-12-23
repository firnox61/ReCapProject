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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int CustomerId)
        {
             var result = _customerDal.Get(s => s.UserId == CustomerId);
             if (result == null)
             {
                 return new ErrorResult();
             }
            _customerDal.Delete(result);
             return new SuccessResult();
           
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Customer> GetById(int CustomerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(s => s.UserId == CustomerId), Messages.CarAdded);
        }

        public IResult Update(Customer customer)
        {
          
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}

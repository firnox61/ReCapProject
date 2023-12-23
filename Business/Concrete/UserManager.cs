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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {

            if (DateTime.Now.Hour == 20)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(string UserName)
        {
            var result = _userDal.Get(u => u.FirstName == UserName);
            if (result == null)
            {
                return new ErrorResult();
            }
            _userDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<User> GetById(int UserId)
        {
           var result = _userDal.Get(u => u.Id == UserId);
            if(result == null)
            {
                return new ErrorDataResult<User>(Messages.CarNameInvalid);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == UserId), Messages.CarAdded);
        }

        public IResult Update(User user)
        {
            if (user.FirstName == null)
            {
                return new ErrorResult();
            }
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}

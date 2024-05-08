using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
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
        public IDataResult<UserDetailDto> GetUserByDetail(int id)
        {
            var result=_userDal.Get(u=>u.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<UserDetailDto>(Messages.UserNotFound);
            }
            var results=_userDal.GetUserByDetails(id);
            return new SuccessDataResult<UserDetailDto>(results,Messages.UserInfo);
        }
        public IDataResult<User> GetByEmailUser(string email)
        {
            var result=_userDal.Get(u=>u.Email == email);

            return new SuccessDataResult<User>(result);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetailDtos()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == userId));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
           _userDal.Delete(user);
            return new SuccessResult();
        }

        public IResult EditProfil(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var Updateuser = new User
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = user.Status,

            };
            _userDal.Update(Updateuser);    
            return new SuccessResult(Messages.UserUpdate);
        }

      
    }
}

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
    public interface IUserServcie
    {
        IDataResult<List<User>> GetAll();
     
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}

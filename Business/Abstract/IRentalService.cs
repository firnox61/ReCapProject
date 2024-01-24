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
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int RentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(int RentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailDtos();
    }
}

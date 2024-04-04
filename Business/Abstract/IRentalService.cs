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
        IDataResult<Rental> RentalDateControl(int carId, DateTime start, DateTime end);

    }
}//https://localhost:7015/api/rentals/rentaldatecontrol?carId=5&rentDate=2024-02-16T00:00:00&returnDate=2024-02-19T00:00:00

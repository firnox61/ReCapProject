using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        //List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailDto> GetRentalDetails();
        public bool IsCarAvailableForRental(int carId, DateTime startDate, DateTime? endDate);
    }
}

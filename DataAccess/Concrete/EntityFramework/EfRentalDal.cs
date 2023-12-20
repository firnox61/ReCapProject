using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DataContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DataContext context = new DataContext())
            {
                var result = from r in context.Rentals
                             join g in context.Customers
                             on r.CustomerId equals g.UserId
                             join c in context.Car
                             on r.CarId equals c.CarId
                             select new RentalDetailDto { Id = r.Id, CarId = c.CarId, CustomerId = g.UserId
                             , RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}

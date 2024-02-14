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
                             join u in context.Users
                             on r.CustomerId equals u.Id        
                             join c in context.Car
                             on r.CarId equals c.CarId
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto { Id = r.Id,BrandName=b.BrandName, FirstName=u.FirstName,LastName=u.LastName,CarId = c.CarId, CustomerId = u.Id
                             , RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}

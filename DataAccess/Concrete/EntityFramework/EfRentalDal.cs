using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
        public bool IsCarAvailableForRental(int carId, DateTime startDate, DateTime? endDate)
        {
            using (DataContext context = new DataContext())
            {
                // Belirtilen tarih aralığında başka bir kiralama işlemi var mı kontrol et
                var existingRental = context.Rentals
                .FirstOrDefault(r => r.CarId == carId &&
                                     ((startDate >= r.RentDate && startDate <= r.ReturnDate) ||
                                      (endDate >= r.RentDate && endDate <= r.ReturnDate) || (startDate <= r.ReturnDate && endDate >= r.ReturnDate) ||  (startDate>=endDate)));//|| (startDate<=r.ReturnDate && endDate>=r.ReturnDate)  (startDate<r.RentDate && endDate>=r.ReturnDate)  ||

                return existingRental == null;
            }
        }
    }
}
//2024-02-15T00:00:00
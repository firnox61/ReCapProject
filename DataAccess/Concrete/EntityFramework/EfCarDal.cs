using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DataContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DataContext context=new DataContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join g in context.Color
                             on c.ColorId equals g.ColorId                           
                             join i in context.CarImages
                             on c.CarId equals i.CarId into images
                             from img in images.DefaultIfEmpty()
                             select new CarDetailDto
                             { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = g.ColorName,ModelYear=c.ModelYear, DailyPrice=c.DailyPrice, ImagePath = (img !=null) ? img.ImagePath:null};
                return result.ToList();

                //CarName, BrandName, ColorName, DailyPrice

            }
        }
    public CarDetailDto GetCarDetailId(int id)
    {
            using (DataContext context=new DataContext())
            {
                var result = (from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join g in context.Color
                             on c.ColorId equals g.ColorId
                             where c.CarId==id
                             select new CarDetailDto
                             { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = g.ColorName,ModelYear=c.ModelYear, DailyPrice=c.DailyPrice}).FirstOrDefault();
                return result;

                //CarName, BrandName, ColorName, DailyPrice

            }
        }
    }
}
/*join i in context.CarImages
                             on c.ImageId equals i.Id
    ImagePath=i.ImagePath*/

//public List<CarDetailDto> GetCarDetails()
//{
//    using (DataContext context = new DataContext())
//    {
//        var result = from c in context.Car
//                     join b in context.Brand
//                     on c.BrandId equals b.BrandId
//                     join g in context.Color
//                     on c.ColorId equals g.ColorId
//                     join i in context.CarImages
//                     on c.CarId equals i.CarId into images
//                     from img in images.DefaultIfEmpty()
//                     select new CarDetailDto
//                     { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = g.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, ImagePath = (img != null) ? img.ImagePath : null };
//        return result.ToList();

//        //CarName, BrandName, ColorName, DailyPrice

//    }
//}
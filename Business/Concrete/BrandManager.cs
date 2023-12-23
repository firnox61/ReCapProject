using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(string BrandName)
        {
            var result = _brandDal.Get(b => b.BrandName == BrandName);
            if (result == null)
            {
                return new ErrorResult();
            }
            _brandDal.Delete(result);
            return new SuccessResult();
        }
            
        

        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());

        }

        public IDataResult<Brand> GetById(int BrandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == BrandId));

        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName == null)
            {
                return new ErrorResult();
            }
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}

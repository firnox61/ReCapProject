using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(string ColorName)
        {
            var result = _colorDal.Get(g => g.ColorName == ColorName);
            if (result == null)
            {
                return new ErrorResult();
            }
            _colorDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Color> GetById(int ColorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(g => g.ColorId == ColorId), Messages.CarAdded);
        }

        public IResult Update(Color color)
        {

            if (color.ColorName == null)
            {
                return new ErrorResult();
            }
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}

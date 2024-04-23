using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

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
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int ColorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(g => g.ColorId == ColorId), Messages.ColorByListed);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {

            if (color.ColorName == null)
            {
                return new ErrorResult();
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdate);
        }
    }
}

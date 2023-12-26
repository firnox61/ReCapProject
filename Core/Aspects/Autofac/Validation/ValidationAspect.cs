using Castle.DynamicProxy;
using Core.CrossCuttingCorcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//validatorType bir IValidator değilse kız
            {
                throw new Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {//
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ilkini bulvalidatrtypeın generiğinini
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// methodunparetmetrelerini bul entityTypea denk gelenbjul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//validation tool kullanarak validatate et
            }
        }
    }
}

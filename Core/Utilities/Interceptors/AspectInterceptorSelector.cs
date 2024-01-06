using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//clasın attributlarına bak
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)//metotların atributlarına bak
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
         //   classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); sisteme loglama ekleseydik kullanacağımız şey  ototmatik olarak tüm metotları loga dahil et demek
         //buraya yine bu şekilde performance işini ekleyebilirdik ve bu tüm sistemi performanc eder
            return classAttributes.OrderBy(x => x.Priority).ToArray();//önceliklerine bak
        }
    }
}

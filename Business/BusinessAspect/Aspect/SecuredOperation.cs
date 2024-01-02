using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect.Aspect
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//her istek için hhtp oluşur interface olarak ekledik

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//productmanagerdeki şeki 2 ye bölüp arrayliyo
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//bizim injection altyapımızı okumamızı sağlayacak

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)//bu kullanıcın rollerini gez ve ilgili rol varsa claimi varsa devam et yoksa da yetkinyok hatası ver
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}

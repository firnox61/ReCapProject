using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator() 
        {
            RuleFor(p=>p.CardNumber).Length(16);
            RuleFor(p => p.CVV).Length(3);
            RuleFor(p => p.ExpiryYear).NotEmpty();
            RuleFor(p => p.ExpiryMonth).NotEmpty();
            RuleFor(p => p.FullName).MinimumLength(3);

        }
    }
}

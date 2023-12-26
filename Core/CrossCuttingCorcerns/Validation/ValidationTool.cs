﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingCorcerns.Validation
{
    public static class ValidationTool
    {//refactor ederek evrensel kullanılabilir hale getircez
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<Object>(entity);
            
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

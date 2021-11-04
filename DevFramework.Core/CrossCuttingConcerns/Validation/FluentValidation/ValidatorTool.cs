using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator(); Gerek yok artık
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            //var result = validator.Validate((IValidationContext)entity); //Sadece entity kabul etmiyor

            //if (result.Errors.Count > 0)
            //{
            //    throw new ValidationException(result.Errors);
            //}
        }
    }
}

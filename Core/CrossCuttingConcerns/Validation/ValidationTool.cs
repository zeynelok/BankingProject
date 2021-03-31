using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static List<string> Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);         
            var result = validator.Validate(context);
            
            if (!result.IsValid)
            {
                
               
                return result.Errors.Select(x => x.ErrorMessage).ToList();
              
            }
            return null;
        }
    }
}

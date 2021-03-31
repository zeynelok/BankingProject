using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
   public class ErrorResult : ReferancedResult 
    { 
        
        public List<string> Errors { get; set; }

        public ErrorResult(int referanceNumber,List<string> errors) : base(true,referanceNumber)
        {
            
            Errors = errors;
        }
       


    }
}

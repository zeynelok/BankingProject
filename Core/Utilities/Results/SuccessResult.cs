using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:ReferancedResult
    {       
        public SuccessResult(int referanceNumber):base(false, referanceNumber)
        {
          
        }
       
    }
}

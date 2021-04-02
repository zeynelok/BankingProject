using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T> where T:class
    {
        public SuccessDataResult(int referanceNumber,T data):base(referanceNumber,false, data)
        {
                
        }
       
    }
}

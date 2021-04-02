using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IReferancedResult, IDataResult<T> where T:class
    {
        public int ReferanceNumber { get; }
        public T Data { get; }
        public DataResult(int referanceNumber, bool isError,T data=null):base(isError)
        {
            Data = data;
            ReferanceNumber = referanceNumber;
        }
       
       
       
    }
}

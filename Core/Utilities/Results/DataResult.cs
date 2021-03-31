using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> where T:class
    {
        public T Data { get; }
        public DataResult(bool isError,T data=null):base(isError)
        {
            Data = data;
        }
       
       
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T> where T : class
    {

        public string Error { get; set; }

        public ErrorDataResult(string error, T data = null) : base(true, data)
        {
            Error = error;

        }
    }
}

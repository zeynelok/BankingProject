using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool IsError { get; }

    

        public Result(bool isError )
        {
            IsError = isError;

        }
       
    }
}

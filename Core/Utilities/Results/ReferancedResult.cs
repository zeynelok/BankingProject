using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ReferancedResult : Result,IReferancedResult
    {
        public int ReferanceNumber { get; }
        public ReferancedResult(bool isError, int referanceNumber) : base( isError)
        {
            ReferanceNumber = referanceNumber;
        }
    }
}

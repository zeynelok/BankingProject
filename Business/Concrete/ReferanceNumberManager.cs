using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReferanceNumberManager : IReferanceNumber
    {
        private int referanceNumber = 1;
        public int CreateReferanceNumber()
        {
           
            lock (this)
            {
                return referanceNumber++;
            }
           
        }
    }
}

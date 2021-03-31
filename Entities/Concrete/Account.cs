using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Account:IEntity
    {
        public int AccountNumber { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}

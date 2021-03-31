using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Accounting:IEntity
    {
        public int SenderAccountNumber { get; set; }
        public int ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}

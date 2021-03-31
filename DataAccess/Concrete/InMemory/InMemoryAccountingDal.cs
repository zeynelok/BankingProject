using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
  public  class InMemoryAccountingDal : IAccountingDal
    {
        List<Accounting> _accountings;
        public InMemoryAccountingDal()
        {
            _accountings = new List<Accounting> { };
        }
        public void Add(Accounting entity)
        {
            _accountings.Add(entity); 
        }      

        public List<Accounting> GetAll()
        {
            return _accountings;
        }

       
    }
}

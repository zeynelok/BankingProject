using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryAccountDal : IAccountDal
    {
        List<Account> _accounts;
        public InMemoryAccountDal()
        {
            _accounts = new List<Account> {  };
        }
        public void Add(Account entity)
        {
            _accounts.Add(entity);
        }

        public Account Get(int accountNumber)
        {
            return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public List<Account> GetAll()
        {
            return _accounts;
        }  

      

        
    }
}

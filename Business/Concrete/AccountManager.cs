using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        IAccountDal _accountDal;
        IReferanceNumber _referanceNumber;

        public AccountManager(IAccountDal accountDal, IReferanceNumber referanceNumber)
        {
            _accountDal = accountDal;
            _referanceNumber = referanceNumber;


        }
        public IResult Add(Account account)
        {
            var errorList = new List<string>();
            var errors = ValidationTool.Validate(new AccountValidator(), account);
            if (errors==null)
            {
                var isAccountExists = IsAccountExists(account.AccountNumber);
                if (isAccountExists)
                {
                    errorList.Add("Bu kullanıcı zaten mevcut");
                    
                }
                else
                {                 
                        _accountDal.Add(account);
                        return new SuccessResult(_referanceNumber.CreateReferanceNumber());   
                }

            }
            else
            {
                errorList.AddRange(errors);
            }
            return new ErrorResult(_referanceNumber.CreateReferanceNumber(), errorList);
                     

        }
        public IDataResult<List<Account>> GetAll()
        {

            //**** Eğer hesap listesi boşken hata verilmesi istenilirse yorum satırları kaldırılmalıdır

            //if (_accountDal.GetAll().Count==0)
            //{
            //    return new ErrorDataResult<List<Account>>(_referanceNumber.CreateReferanceNumber(), "Hesap Bulunamadı");
            //}

            return new SuccessDataResult<List<Account>>(_referanceNumber.CreateReferanceNumber(),_accountDal.GetAll());
          
        }

        private bool IsAccountExists(int accountNumber)
        {
            var isAccount = _accountDal.Get(accountNumber);
            if (isAccount == null)
            {
                return false;
            }
            return true;
        }



    }
}

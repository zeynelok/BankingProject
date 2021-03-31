using Business.Abstract;
using Business.Contants;
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
            //****Liste boşken hata dönmek istenirse yorum satırları kaldırılabilir
            //if (!IsAnyAccountExists())
            //{

            //    return new ErrorDataResult<List<Account>>(_referanceNumber.CreateReferanceNumber(), "Hiç hesap bulunamadı");
            //}

            return new SuccessDataResult<List<Account>>(_accountDal.GetAll());
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

        //private bool IsAnyAccountExists()
        //{
        //    var isAnyAccountExists = _accountDal.GetAll();
        //    if (isAnyAccountExists.Count != 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


    }
}

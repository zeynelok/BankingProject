using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountingManager : IAccountingService
    {
        IAccountingDal _accountingDal;
        IAccountDal _accountDal;
        IReferanceNumber _referanceNumber;
        public AccountingManager(IAccountingDal accountingDal,IReferanceNumber referanceNumber,IAccountDal accountDal)
        {
            _accountingDal = accountingDal;
            _accountDal = accountDal;
            _referanceNumber = referanceNumber;

        }
        public IResult Add(Accounting accounting)
        {
            var errorList = new List<string>();
            var errors = ValidationTool.Validate(new AccountingValidator(), accounting);
            if (errors==null)
            {
                var sender = _accountDal.Get(accounting.SenderAccountNumber);
                var receiver = _accountDal.Get(accounting.ReceiverAccountNumber);
                if (sender != null && receiver != null )
                {
                    if (sender.Balance >= accounting.Amount)
                    {
                        if (sender.CurrencyCode==receiver.CurrencyCode)
                        {
                            sender.Balance = sender.Balance - accounting.Amount;
                            receiver.Balance = receiver.Balance + accounting.Amount;
                            _accountingDal.Add(accounting);
                            return new SuccessResult(_referanceNumber.CreateReferanceNumber());
                        }
                        errorList.Add("Gönderici ve Alıcı para birimi kodu aynı olmalıdır");
                    }
                    else
                    {
                        errorList.Add("Bakiye Yetersiz");
                    }
                    
                }
                else
                {
                    errorList.Add("Gönderici ya da Alıcı mevcut değil");
                }

            }
            else
            {
                errorList.AddRange(errors);
            } 

            return new ErrorResult(_referanceNumber.CreateReferanceNumber(),errorList);
        }

        public IDataResult<List<Accounting>> GetAll()
        {
            //Eğer transfer listesi boşken hata verilmesi istenirse yorum satırları kaldırılmalıdır

            //if (_accountingDal.GetAll().Count==0)
            //{
            //    return new ErrorDataResult<List<Accounting>>(_referanceNumber.CreateReferanceNumber(), "Para transferi bulunamadı");
            //}


            return new SuccessDataResult<List<Accounting>>(_referanceNumber.CreateReferanceNumber(),_accountingDal.GetAll());
        }
    }
}

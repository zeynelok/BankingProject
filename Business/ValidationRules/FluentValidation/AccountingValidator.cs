using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class AccountingValidator:AbstractValidator<Accounting>
    {
        private readonly CultureInfo _cultureInfo;
        public AccountingValidator()
        {
            _cultureInfo = new CultureInfo("en-US");

            RuleFor(x => x.SenderAccountNumber).GreaterThan(0);
            RuleFor(x => x.ReceiverAccountNumber).GreaterThan(0);

            RuleFor(x => x.ReceiverAccountNumber).NotEqual(x => x.SenderAccountNumber).WithMessage("'Sender Account Number' ile 'Receiver Account Number' aynı olmaz");

            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Amount).Must(IsAmountPrecisionLimitedTwo).WithMessage("Küsürat Sadece 2 Haneli Bir Değer Olabilir");
            
        }

        private bool IsAmountPrecisionLimitedTwo(decimal arg)
        {
            var startOfPoint = arg.ToString(_cultureInfo).IndexOf(".") + 1;
            if (startOfPoint == 0)
            {
                return true;
            }
            var precision = arg.ToString().Length - startOfPoint;
            if (precision <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

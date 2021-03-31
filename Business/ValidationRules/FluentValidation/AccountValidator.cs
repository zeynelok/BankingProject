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
    public class AccountValidator : AbstractValidator<Account>
    {
        private readonly CultureInfo _cultureInfo;
        public AccountValidator()
        {
            _cultureInfo = new CultureInfo("en-US");

            RuleFor(x => x.AccountNumber).GreaterThan(0);
            RuleFor(x => x.CurrencyCode).NotEmpty();
            RuleFor(x => x.CurrencyCode).Length(3);
            RuleFor(x => x.CurrencyCode).Must(IsMyCodes).WithMessage("'Currency Code' Yalnızca 'TRY', 'USD', 'EUR'  Birimlerinden Biri Olabilir");
            RuleFor(x => x.Balance).Must(IsBalancePrecisionLimitedTwo).WithMessage("Küsürat Sadece 2 Haneli Bir Değer Olabilir");
        }

        private bool IsBalancePrecisionLimitedTwo(decimal arg)
        {
            
            var startOfPoint = arg.ToString(_cultureInfo).IndexOf(".") + 1;
            if (startOfPoint == 0)
            {
                return true;
            }
            var precision = arg.ToString().Length - startOfPoint;
            if ( precision <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsMyCodes(string arg)
        {

            if (arg.Contains("TRY") || arg.Contains("USD") || arg.Contains("EUR"))
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

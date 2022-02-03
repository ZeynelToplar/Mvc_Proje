using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Bu alanı boş bırakamazsın.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alanı boş bırakamazsın");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alanı boş bırakamazsın");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız.");
        }
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 3 karakter girin.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
        }
    }
}

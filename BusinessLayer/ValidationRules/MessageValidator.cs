using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Bu alanı boş geçemezsin.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Bu alanı boş geçemezsin.");
            //RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alanı boş bırakamazsın");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girişi yapınız.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Bu alanı boş bırakamazsın");
        }
    }
}

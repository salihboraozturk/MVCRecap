using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Adını Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen en az 3 karakterli soyad girişi yapınız.");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakterli soyad girişi yapınız.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan Boş Geçemezsiniz.");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakterli unvan girişi yapınız.");
        }
    }
}

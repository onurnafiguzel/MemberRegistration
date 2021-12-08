using FluentValidation;
using MemberRegistration.Entities.Concrete;
using System;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Soy isim boş geçilemez");
            RuleFor(m => m.DateOfBirth).NotEmpty().WithMessage("Doğum tarihi boş geçilemez");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(m => m.TcNo).NotEmpty().WithMessage("Tc kimlik boş geçilemez");
            RuleFor(m => m.TcNo).Length(11).WithMessage("Tc kimlik numarası 11 karakterden oluşmalıdır");
            RuleFor(m => m.DateOfBirth).LessThan(DateTime.Now).WithMessage("Şu andan eski bir tarih seçilmelidir");
        }
    }
}

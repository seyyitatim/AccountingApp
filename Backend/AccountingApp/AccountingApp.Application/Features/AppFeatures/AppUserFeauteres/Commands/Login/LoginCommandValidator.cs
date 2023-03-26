using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.AppUserFeauteres.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.EmailOrUserName).NotNull().NotEmpty().WithMessage("Mail ya da kullanıcı adı yazmalısınız!");
            RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
        }
    }
}

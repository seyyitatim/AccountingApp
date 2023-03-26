using AccountingApp.Application.Abstractions;
using AccountingApp.Application.Messaging;
using AccountingApp.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.AppUserFeauteres.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider jwtProvider;
        private readonly UserManager<AppUser> userManager;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            this.jwtProvider = jwtProvider;
            this.userManager = userManager;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await userManager.Users.Where(u => u.UserName == request.EmailOrUserName || u.Email == request.EmailOrUserName).FirstOrDefaultAsync();

            if (user == null) throw new Exception("Kullanıcı adı ya da şifre hatalı");

            var checkUser = await userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Kullanıcı adı ya da şifre hatalı");

            List<string> roles = new();

            LoginCommandResponse response = new(await jwtProvider.CreateTokenAsync(user, roles),
                user.Email,
                user.Id,
                user.FullName);

            return response;
        }
    }
}

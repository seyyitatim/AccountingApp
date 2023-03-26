using AccountingApp.Application.Abstractions;
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
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider jwtProvider;
        private readonly UserManager<AppUser> userManager;

        public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            this.jwtProvider = jwtProvider;
            this.userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await userManager.Users.Where(u => u.UserName == request.EmailOrUserName || u.Email == request.EmailOrUserName).FirstOrDefaultAsync();

            if (user == null) throw new Exception("Kullanıcı adı ya da şifre hatalı");

            var checkUser = await userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Kullanıcı adı ya da şifre hatalı");

            List<string> roles = new();

            LoginResponse response = new()
            {
                Email = user.Email,
                FullName = user.FullName,
                UserId = user.Id,
                Token = await jwtProvider.CreateTokenAsync(user, roles)
            };

            return response;
        }
    }
}

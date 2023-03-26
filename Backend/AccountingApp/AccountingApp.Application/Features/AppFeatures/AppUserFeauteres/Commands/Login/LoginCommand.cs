using AccountingApp.Application.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Features.AppFeatures.AppUserFeauteres.Login
{
    public record LoginCommand(string EmailOrUserName, string Password) : ICommand<LoginCommandResponse>;
}

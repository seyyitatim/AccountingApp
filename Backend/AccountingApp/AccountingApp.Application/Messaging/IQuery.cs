﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}

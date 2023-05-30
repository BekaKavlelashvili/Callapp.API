using Callapp.Application.Dtos;
using Callapp.Domain.Aggregates;
using Callapp.Shared.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Application.Commands
{
    public record AuthenticateUserCommand(LoginUserDto LoginUser) : IRequest<Result>;
}

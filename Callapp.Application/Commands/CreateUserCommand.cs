using Callapp.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Callapp.Application.Dtos;

namespace Callapp.Application.Commands
{
    public record CreateUserCommand(CreateUserDto user) : IRequest<User>;
}

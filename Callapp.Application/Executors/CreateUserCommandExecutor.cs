using Callapp.Application.Commands;
using Callapp.Application.Dtos;
using Callapp.Domain.Aggregates;
using Callapp.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Application.Executors
{
    public class CreateUserCommandExecutor : IRequestHandler<CreateUserCommand, User>
    {
        private CallappDbContext _dbContext;

        public CreateUserCommandExecutor(CallappDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Aggregates.User();

            user.CreateUser(
                request.user.UserName,
                request.user.Password,
                request.user.Email
                );

            _dbContext.Attach(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}

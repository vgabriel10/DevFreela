﻿using DevFreela.Core.Entities;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;


namespace DevFreela.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IAuthService _authService;
        public CreateUserHandler(DevFreelaDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}


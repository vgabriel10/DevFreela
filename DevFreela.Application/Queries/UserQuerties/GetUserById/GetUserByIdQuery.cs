﻿

using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.UserQuerties.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id) 
        { 
            Id = id;
        }

        public int Id { get; set; }
    }
}

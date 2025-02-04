
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.InsertUserSkill
{
    public class InsertUserSkillCommand : IRequest<ResultViewModel>
    {
        public InsertUserSkillCommand(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; set; }
        public int IdSkill { get; set; }

        public UserSkill ToEntity()
            => new(IdUser, IdSkill);
    }
}


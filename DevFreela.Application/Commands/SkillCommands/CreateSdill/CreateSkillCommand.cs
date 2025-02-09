using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.CreateSdill
{
    public class CreateSkillCommand : IRequest
    {
        public string Description { get; set; }
    }
}

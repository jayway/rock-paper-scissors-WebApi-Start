using System.Threading.Tasks;
using System.Windows.Input;

namespace ES.Lab.Api.Infrastructure
{
    public class CommandBus : ICommandBus
    {
        //private readonly IApplicationService _applicationService;

        //public CommandBus(IApplicationService applicationService)
        //{
        //    _applicationService = applicationService;
        //}

        public void Send(ICommand command)
        {
            //TODO Remove ICommand.cs and replace impl with your ES ICommand
            throw new System.NotImplementedException();
            //Task.Run(() => _applicationService.Handle(command));
        }

    }
}
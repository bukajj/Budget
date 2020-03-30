using System.Threading.Tasks;

namespace Budget.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        Task HandleAsync(T command);
    }
}
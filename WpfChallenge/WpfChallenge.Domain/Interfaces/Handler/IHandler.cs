using System.Threading.Tasks;
using WpfChallenge.Domain.Interfaces.Command;

namespace WpfChallenge.Domain.Interfaces.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}

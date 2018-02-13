using System.Threading.Tasks;

namespace CategoryProblem.Console.Commands.Execution
{
    interface ICommandExecutor
    {
        Task<string> Execute(string command);
    }
}
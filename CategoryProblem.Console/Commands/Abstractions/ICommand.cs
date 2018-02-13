using System.Threading.Tasks;

namespace CategoryProblem.Console.Commands.Abstractions
{
    interface ICommand
    {
        string CommandName { get; }
        Task<string> Execute(string command);
    }
}
using CategoryProblem.Console.Commands.Abstractions;

namespace CategoryProblem.Console.Commands.Registry
{
    interface ICommandsRegistry
    {
        ICommand Get(string commandName);
    }
}
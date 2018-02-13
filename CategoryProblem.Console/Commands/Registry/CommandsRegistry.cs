using System.Collections.Generic;
using CategoryProblem.Console.Commands.Abstractions;
using CategoryProblem.Domain.Repositories;

namespace CategoryProblem.Console.Commands.Registry
{
    class CommandsRegistry : ICommandsRegistry
    {
        private readonly IDictionary<string, ICommand> _knownCommands;

        public CommandsRegistry(ICategoriesRepository categoriesRepository)
        {
            // TODO: Change to load types from assembly that are assignable to ICommand

            var idCommand = new IdCommand(categoriesRepository);
            var levelCommand = new LevelCommand(categoriesRepository);

            this._knownCommands = new Dictionary<string, ICommand>
            {
                {idCommand.CommandName, idCommand},
                {levelCommand.CommandName, levelCommand}
            };
        }

        public ICommand Get(string commandName)
        {
            if (this._knownCommands.TryGetValue(commandName, out ICommand command))
            {
                return command;
            }

            return null;
        }
    }
}
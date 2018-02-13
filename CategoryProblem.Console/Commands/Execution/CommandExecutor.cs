using System;
using System.Threading.Tasks;
using CategoryProblem.Console.Commands.Exceptions;
using CategoryProblem.Console.Commands.Registry;

namespace CategoryProblem.Console.Commands.Execution
{
    class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandsRegistry _commandsRegistry;


        public CommandExecutor(ICommandsRegistry commandsRegistry)
        {
            _commandsRegistry = commandsRegistry;
        }


        public async Task<string> Execute(string commandText)
        {
            try
            {
                if (string.IsNullOrEmpty(commandText))
                {
                    throw new Exception("Empty command is not supported");
                }

                var commandParts = commandText.Split(' ');
                var commandName = commandParts[0];
                var command = this._commandsRegistry.Get(commandName);

                if (command == null)
                {
                    throw new CommandExecutionException($"Command with name {commandName} is not supported");
                }

                var result = await command.Execute(commandText);
                return result;
            }
            catch (CommandExecutionException ex)
            {
                return ex.Message;
            }
        }
    }
}
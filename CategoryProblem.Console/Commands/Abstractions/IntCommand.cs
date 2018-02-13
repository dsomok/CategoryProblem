using System;

namespace CategoryProblem.Console.Commands.Abstractions
{
    abstract class IntCommand : Command<int>
    {
        protected override int ParseArgs(string command)
        {
            var commandParts = command.Split(' ');
            if (commandParts.Length != 2)
            {
                throw new Exception($"Invalid number of arguments was provided for command \"{this.CommandName}\"");
            }

            if (!int.TryParse(commandParts[1], out int id))
            {
                throw new Exception($"Invalid argument was provided for command \"{this.CommandName}\"");
            }

            return id;
        }
    }
}
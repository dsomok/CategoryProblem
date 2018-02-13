using System;

namespace CategoryProblem.Console.Commands.Exceptions
{
    class CommandExecutionException : Exception
    {
        public CommandExecutionException(string message)
            : base(message)
        {
        }
    }
}
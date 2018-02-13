using System;
using System.Threading.Tasks;
using CategoryProblem.Console.Commands.Exceptions;

namespace CategoryProblem.Console.Commands.Abstractions
{
    abstract class Command<TArgs> : ICommand
    {
        public abstract string CommandName { get; }

        public async Task<string> Execute(string command)
        {
            try
            {
                var args = this.ParseArgs(command);
                var result = await this.ExecuteInternal(args);

                return result;
            }
            catch (Exception ex)
            {
                throw new CommandExecutionException(ex.Message);
            }
        }

        protected abstract TArgs ParseArgs(string command);
        protected abstract Task<string> ExecuteInternal(TArgs args);
    }
}
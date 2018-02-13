using System.Text;
using System.Threading.Tasks;
using CategoryProblem.Console.Commands.Execution;
using CategoryProblem.Console.Commands.Registry;
using CategoryProblem.DataAccess.MSSQL;
using CategoryProblem.Domain.Repositories;

namespace CategoryProblem.Console
{
    class Program
    {
        private const string ExitCommand = "exit";

        static void Main(string[] args)
        {
            // ICategoriesRepository categoriesRepository = new InMemoryCategoriesRepository();
            var connectionString = "Server=localhost;Database=CategoryProblem;User Id=sa; Password = Q!w2E#r4;";
            ICategoriesRepository categoriesRepository = new CategoriesRepository(connectionString);
            ICommandsRegistry commandsRegistry = new CommandsRegistry(categoriesRepository);
            ICommandExecutor commandExecutor = new CommandExecutor(commandsRegistry);

            Run(commandExecutor).Wait();
        }

        private static async Task Run(ICommandExecutor commandExecutor)
        {
            var helpMessage = ComposeHelpMessage();
            System.Console.WriteLine(helpMessage);

            while (true)
            {
                var command = System.Console.ReadLine();
                if (command == ExitCommand)
                {
                    break;
                }

                var result = await commandExecutor.Execute(command);

                System.Console.WriteLine(result);
                System.Console.WriteLine();
            }
        }

        private static string ComposeHelpMessage()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Enter command in one of the following formats:");
            builder.AppendLine("id {category ID} - get category info by ID");
            builder.AppendLine("level {category level} - get all categories of specified level");
            builder.AppendLine($"{ExitCommand} - to exit from application");

            return builder.ToString();
        }
    }
}

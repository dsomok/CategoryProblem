using System.Linq;
using System.Threading.Tasks;
using CategoryProblem.Console.Commands.Abstractions;
using CategoryProblem.Domain.Repositories;

namespace CategoryProblem.Console.Commands
{
    class LevelCommand : IntCommand
    {
        private readonly ICategoriesRepository _categoriesRepository;


        public LevelCommand(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        

        public override string CommandName => "level";

        protected override async Task<string> ExecuteInternal(int level)
        {
            var categories = await this._categoriesRepository.GetByLevel(level);
            if (!categories.Any())
            {
                return $"There are no commands with level {level}";
            }

            return categories.Skip(1).Aggregate(
                categories[0].Id.ToString(),
                (response, categoryId) => $"{response}, {categoryId.Id}"
            );
        }
    }
}
using System;
using System.Threading.Tasks;
using CategoryProblem.Console.Commands.Abstractions;
using CategoryProblem.Domain.Repositories;

namespace CategoryProblem.Console.Commands
{
    class IdCommand : IntCommand
    {
        private readonly ICategoriesRepository _categoriesRepository;
        

        public IdCommand(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        

        public override string CommandName => "id";

        protected override async Task<string> ExecuteInternal(int id)
        {
            var category = await this._categoriesRepository.Get(id);
            if (category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            return $"ParentCategoryID = {category.ParentCategoryId}, Name = {category.Name}, Keywords = {category.Keywords}";
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryProblem.Domain.Entities;
using CategoryProblem.Domain.Repositories;

namespace CategoryProblem.DataAccess.InMemory
{
    public class InMemoryCategoriesRepository : ICategoriesRepository
    {
        private readonly IList<CategoryDTO> _categories = new List<CategoryDTO>
        {
            new CategoryDTO(100, -1, "Business", "Money"),
            new CategoryDTO(200, -1, "Tutoring", "Teaching"),
            new CategoryDTO(101, 100, "Accounting", "Taxes"),
            new CategoryDTO(102, 100, "Taxation", string.Empty),
            new CategoryDTO(201, 200, "Computer", string.Empty),
            new CategoryDTO(103, 101, "Corporate Tax", string.Empty),
            new CategoryDTO(202, 201, "Operating System", string.Empty),
            new CategoryDTO(109, 101, "Small business Tax", string.Empty),
        };

        public async Task<Category> Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var categoryDTO = this._categories.SingleOrDefault(c => c.CategoryId == id);
            var category = await this.ToCategory(categoryDTO);

            return category;
        }

        public async Task<IList<Category>> GetByLevel(int level)
        {
            var categories = new List<Category>();
            foreach (var categoryDTO in this._categories)
            {
                var category = await this.ToCategory(categoryDTO);
                if (category.Level == level)
                {
                     categories.Add(category);
                }
            }

            return categories;
        }


        private async Task<Category> ToCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return null;
            }

            var parentCategory = await this.Get(categoryDTO.ParentCategoryId);
            return new Category(categoryDTO.CategoryId, parentCategory, categoryDTO.Name, categoryDTO.Keywords);
        }
    }
}
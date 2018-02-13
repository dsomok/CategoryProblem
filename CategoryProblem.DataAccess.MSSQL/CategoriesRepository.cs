using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CategoryProblem.DataAccess.MSSQL.ScriptsRegistry;
using CategoryProblem.Domain.Entities;
using CategoryProblem.Domain.Repositories;
using Dapper;

namespace CategoryProblem.DataAccess.MSSQL
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IScriptsRegistry _scriptsRegistry = new ScriptsRegistry.EmbeddedResourceScriptsRegistry();
        private readonly string _connectionString;

        public CategoriesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Category> Get(int id)
        {

            var script = await this._scriptsRegistry.GenerateGetCategoryScript(id);
            using (var connection = new SqlConnection(this._connectionString))
            {
                var categoryDTOs = (await connection.QueryAsync<CategoryDTO>(script)).ToList();
                var categoryDTO = categoryDTOs.SingleOrDefault(c => c.CategoryId == id);
                return this.ToCategory(categoryDTO, categoryDTOs);
            }
        }

        public async Task<IList<Category>> GetByLevel(int level)
        {
            var script = await this._scriptsRegistry.GenerateGetCategoryIdsByLevelScript(level);
            using (var connection = new SqlConnection(this._connectionString))
            {
                var categoryDTOs = (await connection.QueryAsync<CategoryDTO>(script)).ToList();
                var categories = (
                    from categoryDTO in categoryDTOs
                    where categoryDTO.Level == level
                    select this.ToCategory(categoryDTO, categoryDTOs)
                ).ToList();

                return categories;
            }
        }


        private Category ToCategory(CategoryDTO categoryDTO, IList<CategoryDTO> relatedCategoryDTOs)
        {
            if (categoryDTO == null)
            {
                return null;
            }

            Category parentCategory = null;
            if (categoryDTO.ParentCategoryId != -1)
            {
                var parentCategoryDTO = relatedCategoryDTOs.SingleOrDefault(c => c.CategoryId == categoryDTO.ParentCategoryId);
                parentCategory = ToCategory(parentCategoryDTO, relatedCategoryDTOs);
            }

            return new Category(categoryDTO.CategoryId, parentCategory, categoryDTO.Name, categoryDTO.Keywords);
        }
    }
}

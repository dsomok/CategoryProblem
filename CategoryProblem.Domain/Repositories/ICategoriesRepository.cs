using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryProblem.Domain.Entities;

namespace CategoryProblem.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        Task<Category> Get(int id);
        Task<IList<Category>> GetByLevel(int level);
    }
}

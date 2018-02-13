using System.Threading.Tasks;

namespace CategoryProblem.DataAccess.MSSQL.ScriptsRegistry
{
    interface IScriptsRegistry
    {
        Task<string> GenerateGetCategoryScript(int categoryId);
        Task<string> GenerateGetCategoryIdsByLevelScript(int level);
    }
}

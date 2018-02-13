using System;
using System.IO;
using System.Threading.Tasks;

namespace CategoryProblem.DataAccess.MSSQL.ScriptsRegistry
{
    class EmbeddedResourceScriptsRegistry : IScriptsRegistry
    {
        private const string GetCategoryScript = "category.sql";
        private const string GetCategoryIdsByLevelScript = "categoriesByLevel.sql";


        public async Task<string> GenerateGetCategoryScript(int categoryId)
        {
            var scriptTemplate = await this.ReadFromResource(GetCategoryScript);
            if (string.IsNullOrEmpty(scriptTemplate))
            {
                throw new Exception("Failed to extract GetCategory script");
            }

            return string.Format(scriptTemplate, categoryId);
        }

        public async Task<string> GenerateGetCategoryIdsByLevelScript(int level)
        {
            var scriptTemplate = await this.ReadFromResource(GetCategoryIdsByLevelScript);
            if (string.IsNullOrEmpty(scriptTemplate))
            {
                throw new Exception("Failed to extract GetCategoryIdsByLevel script");
            }

            return string.Format(scriptTemplate, level);
        }


        private Task<string> ReadFromResource(string scriptName)
        {
            var resourceName = $"CategoryProblem.DataAccess.MSSQL.Scripts.{scriptName}";
            var assembly = this.GetType().Assembly;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEndAsync();
            }
        }
    }
}
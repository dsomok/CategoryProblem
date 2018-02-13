namespace CategoryProblem.DataAccess.MSSQL
{
    class CategoryDTO
    {
        public CategoryDTO(int categoryId, int parentCategoryId, string name, string keywords)
            : this(categoryId, parentCategoryId, name, keywords, null)
        {
        }

        public CategoryDTO(int categoryId, int parentCategoryId, string name, string keywords, int? level)
        {
            CategoryId = categoryId;
            ParentCategoryId = parentCategoryId;
            Name = name;
            Keywords = keywords;
            Level = level;
        }

        public int CategoryId { get; }

        public int ParentCategoryId { get; }

        public string Name { get; }

        public string Keywords { get; }

        public int? Level { get; }
    }
}
namespace CategoryProblem.DataAccess.InMemory
{
    class CategoryDTO
    {
        public CategoryDTO(int categoryId, int parentCategoryId, string name, string keywords)
        {
            CategoryId = categoryId;
            ParentCategoryId = parentCategoryId;
            Name = name;
            Keywords = keywords;
        }

        public int CategoryId { get; }

        public int ParentCategoryId { get; }

        public string Name { get; }

        public string Keywords { get; }
    }
}
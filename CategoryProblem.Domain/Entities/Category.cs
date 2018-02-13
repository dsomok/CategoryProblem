namespace CategoryProblem.Domain.Entities
{
    public class Category
    {
        private readonly string _categoryKeywords;

        public Category(int id, Category parentCategory, string name, string keywords)
        {
            Id = id;
            ParentCategory = parentCategory;
            Name = name;
            _categoryKeywords = keywords;
        }

        public int Id { get; }

        public Category ParentCategory { get; }

        public string Name { get; }

        public int ParentCategoryId => this.ParentCategory?.Id ?? -1;

        public string Keywords
        {
            get
            {
                if (!string.IsNullOrEmpty(this._categoryKeywords))
                {
                    return this._categoryKeywords;
                }

                return this.ParentCategory?.Keywords;
            }
        }

        public int Level
        {
            get
            {
                var level = 1;
                var category = this;

                while (category.ParentCategory != null)
                {
                    level++;
                    category = category.ParentCategory;
                }

                return level;
            }
        }
    }
}

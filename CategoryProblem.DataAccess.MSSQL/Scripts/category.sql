DECLARE @CategoryID int = {0};

WITH SubCategories(CategoryId, ParentCategoryId, "Name", Keywords) AS
(
	SELECT CategoryId, ParentCategoryId, "Name", Keywords
	FROM dbo.Categories
	WHERE CategoryId = @CategoryId
	UNION ALL
		SELECT c.CategoryId, c.ParentCategoryId, c."Name", c.Keywords 
		FROM dbo.Categories AS c 
		INNER JOIN SubCategories AS sc 
		ON c.CategoryId = sc.ParentCategoryId 
)

SELECT CategoryId, ParentCategoryId, "Name", Keywords   
FROM SubCategories
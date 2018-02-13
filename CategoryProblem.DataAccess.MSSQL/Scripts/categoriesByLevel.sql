DECLARE @Level int = {0};

WITH SubCategories(CategoryId, ParentCategoryId, "Name", Keywords, "Level") AS
(
	SELECT CategoryId, ParentCategoryId, "Name", Keywords, 1 AS "Level"
	FROM dbo.Categories
	WHERE ParentCategoryId = -1
	UNION ALL
		SELECT c.CategoryId, c.ParentCategoryId, c."Name", c.Keywords, "Level" + 1  
		FROM dbo.Categories AS c
        INNER JOIN SubCategories AS sc 
        ON c.ParentCategoryId = sc.CategoryId
)

SELECT sc.CategoryId, sc.ParentCategoryId, sc."Name", sc.Keywords, sc."Level"
FROM SubCategories sc
WHERE sc."Level" <= @Level
ORDER BY sc.CategoryId
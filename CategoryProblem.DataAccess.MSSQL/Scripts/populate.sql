USE CategoryProblem;

DROP TABLE Categories;

CREATE TABLE Categories
(
	CategoryId int PRIMARY KEY,
	ParentCategoryId int NOT NULL,
	"Name" nvarchar(100) NOT NULL,
	Keywords nvarchar(100)
)

INSERT INTO dbo.Categories VALUES
(100, -1, 'Business', 'Money'),
(200, -1, 'Tutoring', 'Teaching'),
(101, 100, 'Accounting', 'Taxes'),
(102, 100, 'Taxation', NULL),
(201, 200, 'Computer', NULL),
(103, 101, 'Corporate Tax', NULL),
(202, 201, 'Operating System', NULL),
(109, 101, 'Small business Tax', NULL)
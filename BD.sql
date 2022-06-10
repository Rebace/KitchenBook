use KitchenBook
IF NOT EXISTS( SELECT TOP 1 1 FROM sys.tables WHERE [name] = 'Recipe' )
BEGIN
	CREATE TABLE [Recipe] (
		[Id] INT IDENTITY(1,1) CONSTRAINT PK_Recipe PRIMARY KEY,
		[Title] NVARCHAR(255) NOT NULL,
		[Description] NVARCHAR(MAX) NOT NULL,
		[CookingTime] INT,
		[Portions] INT,
		[Stars] INT,
		[Likes] INT
	)
END

IF NOT EXISTS( SELECT TOP 1 1 FROM sys.tables WHERE [name] = 'User' )
BEGIN
	CREATE TABLE [User] (
		[Id] INT IDENTITY(1,1) CONSTRAINT PK_User PRIMARY KEY,
		[Name] NVARCHAR(255) NOT NULL,
		[Login] NVARCHAR(MAX) NOT NULL,
		[Password] NVARCHAR(MAX) NOT NULL,
		[Token] NVARCHAR(MAX),
		[Description] NVARCHAR(MAX)
	)
END
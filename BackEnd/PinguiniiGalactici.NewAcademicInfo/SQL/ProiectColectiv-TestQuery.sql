CREATE DATABASE PinguiniiGalactici;
USE PinguiniiGalactici;
GO

CREATE TABLE [Users](
	[Username] varchar(50),
	[Password] varchar(50),
	[Email] varchar(50)
	
	CONSTRAINT [PK_Users] PRIMARY KEY([Username])
);

GO

CREATE PROCEDURE [Users_Insert]
(
	@Username varchar(50),
	@Password varchar(50),
	@Email varchar(50)
)
AS
BEGIN
	INSERT INTO Users([Username] ,[Password] ,[Email] )
	VALUES (@Username,@Password,@Email)
END
GO

CREATE PROCEDURE [Users_ReadAll]
AS
BEGIN
	SELECT * FROM [Users]
END

GO

CREATE PROCEDURE [Users_ReadByID]
	@Username varchar(50)
AS
BEGIN
	SELECT *
	FROM [Users]
	WHERE [Username] = @Username
END

GO

CREATE PROCEDURE [Users_Delete]
	@Username varchar(50)
AS
BEGIN
	DELETE FROM [Users]
	WHERE [Username] = @Username
END

GO

CREATE PROCEDURE [Users_Update]
	@Username varchar(50),
	@Password varchar(50),
	@Email varchar(50)
AS
BEGIN
	UPDATE [Users]
	SET [Password] = @Password, [Email]=@Email
	WHERE [Username] = @Username
END

GO


exec [Users_Insert] 'robert','pass','asdasd@yahoo.com'
select * from users
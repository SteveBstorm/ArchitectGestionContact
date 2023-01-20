CREATE PROCEDURE [dbo].[InsertContact]
	@fn VARCHAR(50),
	@ln VARCHAR(50),
	@email VARCHAR(50),
	@phone VARCHAR(25)
AS
	INSERT INTO Contact (Firstname, Lastname, Email, Phone)
	VALUES (@fn, @ln, @email, @phone)
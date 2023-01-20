CREATE TRIGGER [OnContactDelete]
	ON [dbo].[Contact]
	INSTEAD OF delete
	AS
	BEGIN
		UPDATE Contact SET IsActive = 0
		WHERE Id = (SELECT Id FROM deleted)
	END

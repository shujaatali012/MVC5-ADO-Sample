USE [CustomerDb]
GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertUpdateDelete_Customer]    Script Date: 4/13/2019 8:07:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Sp_InsertUpdateDelete_Customer]
	@Id INT = 0
	,@Name NVARCHAR(100) = NULL
	,@Address NVARCHAR(200) = 0
	,@Mobile NVARCHAR(15) = NULL
	,@BirthDate DATETIME = NULL
	,@Email NVARCHAR(20) = NULL
	,@Query INT
AS

BEGIN
	IF (@Query = 1)
		BEGIN
			INSERT INTO Customer(Name, Address, Mobile, BirthDate, Email)
			VALUES (@Name, @Address, @Mobile, @BirthDate, @Email)

			IF (@@ROWCOUNT > 0)
				BEGIN
				SELECT 'Insert'
			END
		END

	IF (@Query = 2)
		BEGIN
			UPDATE Customer SET Name = @Name, Address = @Address, Mobile = @Mobile, BirthDate = @BirthDate, Email = @Email WHERE Customer.Id = @Id
			SELECT 'Update'
		END
		
	IF (@Query = 3)
		BEGIN
			DELETE FROM Customer WHERE Customer.Id = @Id
			SELECT 'Deleted'
		END
		
	IF (@Query = 4)
		BEGIN
			SELECT * FROM Customer 
		END

	IF (@Query = 5)
		BEGIN
			SELECT * FROM Customer WHERE Customer.Id = @Id
		END
END

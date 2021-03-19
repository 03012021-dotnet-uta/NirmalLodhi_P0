ALTER PROCEDURE dbo.uspAddLogin
    @pLogin NVARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pFirstName NVARCHAR(40) = NULL, 
    @pLastName NVARCHAR(40) = NULL,
	@pPhone BIGINT = NULL,
	@pEmail NVARCHAR(100) = NULL,
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO dbo.[Customer] (LoginName, PasswordHash, FirstName, LastName,Phone, eMail )
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword), @pFirstName, @pLastName,@pPhone,@pEmail)

        SET @responseMessage='Registration Completed'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
	END CATCH
	SELECT @responseMessage responseMessage
END


DECLARE @responseMessage NVARCHAR(250)

EXEC dbo.uspAddLogin
          @pLogin = N'Rudra',
          @pPassword = N'Rudra',
          @pFirstName = N'Rudra',
          @pLastName = N'Rudra',
		  @pPhone='8602994044',
		  @pEmail='asdfs@ac.in',
          @responseMessage=@responseMessage OUTPUT
go
insert into Customer values('Rudra','Rudra','Rudra','Rudra','8602994044','asdf@abc.com')
SELECT *
FROM [dbo].Customer


ALTER PROCEDURE dbo.uspLogin
    @pLoginName NVARCHAR(254),
    @pPassword NVARCHAR(50),
    @responseMessage NVARCHAR(50)='' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @CustomerID INT

    IF EXISTS (SELECT TOP 1 CustomerID FROM [dbo].[Customer] WHERE LoginName=@pLoginName)
    BEGIN
        SET @CustomerID=(SELECT CustomerID FROM [dbo].[Customer] WHERE LoginName=@pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword))

       IF(@CustomerID IS NULL)
           SELECT @responseMessage='Incorrect password'
       ELSE 
           SELECT @responseMessage='Connected...'
    END
    ELSE
	BEGIN
       SELECT @responseMessage='Invalid login'
	END
	SELECT @responseMessage responseMessage
END





CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
begin
	set nocount on ;

	SELECT Id, Firstname, LastName, Email, CreatedDate
	from [dbo].[User]
	where Id = @Id;
end

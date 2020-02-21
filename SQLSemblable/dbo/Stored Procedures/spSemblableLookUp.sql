CREATE PROCEDURE [dbo].[spSemblableLookUp]
	@Id int 
AS
begin
	set nocount on;

	SELECT *
	FROM dbo.Semblable
	WHERE Id=@Id;
end


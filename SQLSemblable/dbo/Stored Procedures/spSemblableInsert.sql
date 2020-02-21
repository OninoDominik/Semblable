CREATE PROCEDURE [dbo].[spSemblableInsert]

	 @Nom nvarchar(50), 
	 @Age int, 
	 @Physique int, 
	 @Armement int, 
	 @Puissance int, 
	 @Celerite int, 
	 @Endurance int
AS
	Insert into dbo.Semblable Values (@Nom , @Age ,@Physique,@Armement,@Puissance ,@Celerite  ,@Endurance )
RETURN 0

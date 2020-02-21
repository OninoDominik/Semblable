CREATE TABLE [dbo].[Semblable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Physique] INT NOT NULL DEFAULT 3, 
    [Arme] INT NOT NULL, 
    [Puissance] INT NOT NULL DEFAULT 0, 
    [Celerite] INT NOT NULL DEFAULT 0, 
    [Endurance] INT NOT NULL DEFAULT 0, 
    [DateDeCreation] DATETIME NULL DEFAULT getutcDate(),
    
)

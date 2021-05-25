CREATE TABLE [dbo].[EpidemicDeath]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] INT NULL, 

    CONSTRAINT PK_ED_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_ED_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

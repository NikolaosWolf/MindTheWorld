CREATE TABLE [dbo].[HappinessScore]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] FLOAT NULL, 

    CONSTRAINT PK_HS_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_HS_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

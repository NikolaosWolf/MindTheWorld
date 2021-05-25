CREATE TABLE [dbo].[HappinessScore]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(10, 6) NULL, 

    CONSTRAINT PK_HS_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_HS_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

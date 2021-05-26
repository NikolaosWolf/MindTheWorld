CREATE TABLE [dbo].[Population]
(
	[CountryId] INT NOT NULL, 
    [Year] INT NOT NULL, 
    [Value] INT NULL, 

    CONSTRAINT PK_PPL_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_PPL_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

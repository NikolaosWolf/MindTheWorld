CREATE TABLE [dbo].[WaterSourceAccess]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] FLOAT NULL, 

    CONSTRAINT PK_WSA_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_WSA_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

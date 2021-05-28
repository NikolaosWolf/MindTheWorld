CREATE TABLE [dbo].[InfantMortality]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] FLOAT NULL, 

    CONSTRAINT PK_IM_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_IM_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

CREATE TABLE [dbo].[ResidentialElectricityUse]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(18, 6) NULL, 

    CONSTRAINT PK_REU_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_REU_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

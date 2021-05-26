CREATE TABLE [dbo].[HumanDevelopmentIndex]
(
	[CountryId] INT NOT NULL, 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(10, 6) NULL, 

    CONSTRAINT PK_HDI_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_HDI_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

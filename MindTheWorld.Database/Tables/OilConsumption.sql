CREATE TABLE [dbo].[OilConsumption]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] FLOAT NULL, 

    CONSTRAINT PK_OC_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_OC_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

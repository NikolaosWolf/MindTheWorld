CREATE TABLE [dbo].[CoalConsumption]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(18, 6) NULL, 

    CONSTRAINT PK_CC_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_CC_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

CREATE TABLE [dbo].[CoalConsumption]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] BIGINT NULL, 

    CONSTRAINT PK_CC_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_CC_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

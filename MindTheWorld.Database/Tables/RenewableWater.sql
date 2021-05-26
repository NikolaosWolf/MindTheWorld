CREATE TABLE [dbo].[RenewableWater]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(18, 6) NULL, 

    CONSTRAINT PK_RW_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_RW_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

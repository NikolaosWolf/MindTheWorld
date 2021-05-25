CREATE TABLE [dbo].[MaterialFootprintPerCapita]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(10, 6) NULL, 

    CONSTRAINT PK_MFPC_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_MFPC_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

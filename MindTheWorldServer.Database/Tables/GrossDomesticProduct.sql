CREATE TABLE [dbo].GrossDomesticProduct
(
	[CountryId] INT NOT NULL, 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(10, 6) NULL, 

    CONSTRAINT PK_GDP_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_GDP_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

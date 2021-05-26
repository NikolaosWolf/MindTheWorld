CREATE TABLE [dbo].[Co2EmissionsPerPerson]
(
	[CountryId] INT NOT NULL, 
    [Year] INT NOT NULL, 
    [Value] DECIMAL(10, 6) NULL, 

    CONSTRAINT PK_CO2EPP_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_CO2EPP_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

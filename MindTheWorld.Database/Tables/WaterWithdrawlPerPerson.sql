CREATE TABLE [dbo].[WaterWithdrawlPerPerson]
(
	[CountryId] INT NOT NULL , 
    [Year] INT NOT NULL, 
    [Value] FLOAT NULL, 

    CONSTRAINT PK_WWPP_ID PRIMARY KEY ([CountryId], [Year]),
    CONSTRAINT FK_WWPP_CountryId FOREIGN KEY (CountryId) REFERENCES Country(Id)
)

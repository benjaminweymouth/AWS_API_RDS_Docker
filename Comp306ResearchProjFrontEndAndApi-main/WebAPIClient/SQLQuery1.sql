--Delete the comp306FinancialDB (Financial Data System) database if it exists. 
IF EXISTS(SELECT * from sys.databases WHERE name='comp306FinancialDB') 
BEGIN 
    DROP DATABASE comp306FinancialDB; 
END 

CREATE DATABASE comp306FinancialDB;
GO


USE comp306FinancialDB;
GO

CREATE TABLE dbo.DBdataforStockVolatility(

	StockIdTicker varchar(10)  PRIMARY KEY,
	Name varchar(30) NOT NULL,
	Sector varchar(30) NOT NULL,
	StockVolatility varchar(30) NOT NULL,
	
);
GO

--BULK INSERT DBdataforStockVolatility
--FROM 'C:\Users\benja\DBdataforStockVolatility.csv'
--WITH
--(
--    FORMAT = 'CSV', 
--    FIELDQUOTE = '"',
--    FIRSTROW = 2,
--    FIELDTERMINATOR = ',',  --CSV field delimiter
--    ROWTERMINATOR = '\n',   --Use to shift the control to next row
--    TABLOCK
--)

CREATE TABLE dbo.SurveyInfoTable(

	SurveyId varchar(10)  PRIMARY KEY,
	SurveyPersonName varchar(30) NOT NULL,
	SurveyAmount varchar(30) NOT NULL,
	SurveyIndustry varchar(30) NOT NULL,
	SurveyRiskTolerance varchar(30) NOT NULL,
	SurveyCryptoVSStocks varchar(30) NOT NULL,
	StockIdTicker nvarchar(50) NOT NULL,
	--SurveyInfoTableSurveyId varchar(10)NOT NULL,
	CONSTRAINT FK_SurveyInfoTable_StockIdTicker FOREIGN KEY ([StockIdTicker]) REFERENCES dbo.DBdataforStockVolatility (StockIdTicker) ON DELETE CASCADE
);
GO
 
insert into SurveyInfoTable values('1','Ben Weymouth', '10000', 'Information Technology', 'High', 'I prefer Cryptocurrency', 'IBM','1');
insert into SurveyInfoTable values('2','Michael Asemota', '20000', 'Information Technology', 'Medium', 'I prefer Cryptocurrency', 'AAPL','2');
insert into SurveyInfoTable values('3','Billy Microsoft', '5000', 'Information Technology', 'High', 'I prefer stocks', 'MSFT','3');
insert into SurveyInfoTable values('4','Jeffrey Bezosian', '1000000', 'Information Technology', 'Medium', 'I prefer stocks', 'AMZN','4');
insert into SurveyInfoTable values('5','Michael Form', '10000', 'Communication Services', 'Low', 'I prefer stocks', 'FOXA','5');
insert into SurveyInfoTable values('6','Ben Weymouth', '10000', 'Information Technology', 'High', 'I prefer Cryptocurrency', 'AAPL','6');
insert into SurveyInfoTable values('7','Ralph Lauren', '10000', 'Consumer Discretionary', 'High', 'I prefer Cryptocurrency', 'RL','7');
 
DROP TABLE SurveyInfoTable
DROP TABLE dbo.DBdataforStockVolatility
--///////////////////////////////////////////////////////
--AUTOR:
-- Cristian Gonzalez
--FECHA: 
-- 22/03/2025
--FUNCION:
-- Gestion de Apuestas
--///////////////////////////////////////////////////////
PRINT 'BETS'
GO

IF OBJECT_ID('HEYGIA.TRANSACTIONS') IS NOT NULL
BEGIN
	DROP TABLE HEYGIA.BETS

	IF OBJECT_ID('HEYGIA.BETS') IS NOT NULL
		PRINT '<<< FAILED DROPPING TABLE HEYGIA.BETS >>>'
	ELSE
		PRINT '<<< DROPPED TABLE HEYGIA.BETS >>>'
END
GO
CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    RouletteId INT NULL, -- Puede ser NULL si no está relacionada con una ruleta
    Amount DECIMAL(10,2) NOT NULL, -- Positivo si es ingreso, negativo si es retiro
    TransactionType VARCHAR(10) NOT NULL, -- 'Bet', 'Payout' o 'Deposit'
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

GO

IF OBJECT_ID('HEYGIA.BETS') IS NOT NULL
	PRINT '<<< CREATED TABLE HEYGIA.BETS  >>>'
ELSE
	PRINT '<<< FAILED CREATING TABLE HEYGIA.BETS >>>'
GO

IF @@ERROR != 0
	SELECT '*** ERROR en Script ***'
ELSE
	SELECT 'Finalizo OK ' + RTRIM(CAST(GETDATE() AS NVARCHAR(30)))
GO

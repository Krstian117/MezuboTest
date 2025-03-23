--///////////////////////////////////////////////////////
--AUTOR:
-- Cristian Gonzalez
--FECHA: 
-- 22/03/2025
--COMPANIA: 
-- Heygia
--FUNCION:
-- CREA ESQUEMA HEYGIA PARA PRUEBA TECNICA
--///////////////////////////////////////////////////////
IF EXISTS (SELECT * FROM sys.schemas WHERE name = 'HEYGIA')
BEGIN
    PRINT '<<< ALREADY EXISTING SCHEMA HEYGIA >>>'
END
ELSE
BEGIN
	EXEC('CREATE SCHEMA HEYGIA AUTHORIZATION dbo');
    PRINT '<<< CREATED SCHEMA HEYGIA  >>>'
END

IF @@ERROR != 0
	SELECT '*** ERROR en Script ***'
ELSE
	SELECT 'Finalizo OK ' + RTRIM(CAST(GETDATE() AS NVARCHAR(30)))
GO
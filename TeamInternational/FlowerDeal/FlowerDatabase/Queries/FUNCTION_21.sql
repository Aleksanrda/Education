GO
CREATE FUNCTION IsCreateSupplyNew (@FlowerId int, @PlantationId int, @Amount int)
RETURNS bit
AS
BEGIN
	DECLARE @result bit;
	IF (SELECT PF.[Amount] FROM PlantationFlowers PF WHERE (PF.[FlowerId] = @FlowerId AND PF.[PLantationId] = @PlantationId)) > @Amount
			SET @result=1
		ELSE
			SET @result=0
	RETURN @result;
END;
GO
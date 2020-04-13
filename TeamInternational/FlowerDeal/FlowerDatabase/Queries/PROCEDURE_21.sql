CREATE PROCEDURE CloseSupply @SupplyId int, @Amount int
AS
UPDATE Supplies
SET Status = 'Closed', ClosedData = GETDATE() WHERE Id = @SupplyId

UPDATE WarehouseFlowers
SET Amount = Amount + @Amount WHERE WarehouseId IN (
        SELECT WF.[Id] FROM WarehouseFlowers WF, Warehouses W, Supplies S
		WHERE S.[Id] = @SupplyId AND WF.[WarehouseId] = W.[Id] AND W.[Id] = S.[WarehouseId]
        GROUP BY WF.[Id]);

UPDATE PlantationFlowers
SET Amount = Amount - @Amount WHERE PlantationId IN (
        SELECT PF.[Id] FROM PlantationFlowers PF, Plantations P, Supplies S
		WHERE S.[Id] = @SupplyId AND PF.[PlantationId] = P.[Id] AND P.[Id] = S.[PlantationId]
        GROUP BY PF.[Id]);
GO

CREATE TABLE [dbo].[Supplies]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [PlantationId] INT NOT NULL, 
    [WarehouseId] INT NOT NULL, 
    [SheduledData] DATE NOT NULL, 
    [ClosedData] DATE NULL, 
    [Status] NCHAR(10) NOT NULL,

    CONSTRAINT [FK_Supplies_ToWarehouses] FOREIGN KEY (WarehouseId) REFERENCES [Warehouses]([Id]),
    CONSTRAINT [FK_Supplies_ToPlantations] FOREIGN KEY (PlantationId) REFERENCES [Plantations]([Id])
)

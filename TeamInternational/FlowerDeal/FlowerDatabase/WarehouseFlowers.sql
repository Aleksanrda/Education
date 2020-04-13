CREATE TABLE [dbo].[WarehouseFlowers]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [WarehouseId] INT NOT NULL, 
    [FlowerId] INT NOT NULL, 
    [Amount] INT NOT NULL,

    CONSTRAINT [FK_WarehouseFlowers_ToFlowers] FOREIGN KEY ([FlowerId]) REFERENCES [Flowers]([Id]),
    CONSTRAINT [FK_WarehouseFlowers_ToWarehouses] FOREIGN KEY (WarehouseId) REFERENCES [Warehouses]([Id])
)

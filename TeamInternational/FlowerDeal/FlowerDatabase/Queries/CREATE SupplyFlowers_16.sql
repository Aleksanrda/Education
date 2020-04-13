CREATE TABLE SupplyFlowers
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [SupplyId] INT NOT NULL, 
    [FlowerId] INT NOT NULL, 
    [Amount] INT NOT NULL,

    CONSTRAINT [FK_SupplyFlowers_ToFlowers] FOREIGN KEY ([FlowerId]) REFERENCES [Flowers]([Id]),
    CONSTRAINT [FK_SupplyFlowers_ToSupplies] FOREIGN KEY ([SupplyId]) REFERENCES [Supplies]([Id])
)
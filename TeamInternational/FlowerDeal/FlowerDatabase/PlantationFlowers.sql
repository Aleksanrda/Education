CREATE TABLE [dbo].[PlantationFlowers]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [PlantationId] INT NOT NULL, 
    [FlowerId] INT NOT NULL, 
    [Amount] INT NOT NULL,

    CONSTRAINT [FK_PlantationsFlowers_ToFlowers] FOREIGN KEY ([FlowerId]) REFERENCES [Flowers]([Id]),
    CONSTRAINT [FK_PlantationsFlowers_ToPlantations] FOREIGN KEY ([PlantationId]) REFERENCES [Plantations]([Id])
)

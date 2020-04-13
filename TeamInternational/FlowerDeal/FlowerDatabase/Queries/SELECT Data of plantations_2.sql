SELECT P.[Id], P.[Name], P.[Address], F.[Name], PF.[Amount]
FROM Plantations P, PlantationFlowers PF, Flowers F WHERE P.[Id] = PF.[PlantationId]  AND F.[Id] = PF.[FlowerId]
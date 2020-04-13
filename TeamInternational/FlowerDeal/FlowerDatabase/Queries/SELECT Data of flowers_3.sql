SELECT F.[Id], F.[Name], (SELECT COUNT(PF.[PlantationId]) FROM [PlantationFlowers] PF WHERE PF.[FlowerId] = F.[Id]) AS [Plantations number]
FROM [Flowers] F;
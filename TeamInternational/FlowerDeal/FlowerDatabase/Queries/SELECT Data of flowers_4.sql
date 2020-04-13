SELECT  F.[Id], F.[Name], COUNT(PF.[PlantationId]) AS [Plantations number]
FROM Flowers F LEFT OUTER JOIN PlantationFlowers PF ON F.[Id] = PF.[FlowerId]
WHERE PF.[Amount] > 1000
GROUP BY F.[Id], F.[Name]
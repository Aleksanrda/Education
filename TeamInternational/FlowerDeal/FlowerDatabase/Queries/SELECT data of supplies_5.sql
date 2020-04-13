SELECT F.[Id], F.[Name], SUM(SF.[Amount]) AS [Common Amount Supply Flowers of one type from one Plantation]
FROM SupplyFlowers SF 
JOIN Flowers F ON SF.[FlowerId]=F.[Id] 
JOIN Supplies S ON SF.[SupplyId]=S.[Id]
WHERE S.[PlantationId] = 1
GROUP BY S.[PlantationId], F.[Id], F.[Name]
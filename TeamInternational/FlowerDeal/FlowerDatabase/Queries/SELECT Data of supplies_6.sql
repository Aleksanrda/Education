SELECT S.[Id], P.[Name], W.[Name], S.[ClosedData]
FROM Supplies S 
JOIN Plantations P ON S.[PlantationId]=P.[Id] 
JOIN Warehouses W ON W.[Id]=S.[WarehouseId]
WHERE S.[ClosedData] BETWEEN DATEADD(mm,-1,GETDATE()) AND GETDATE()
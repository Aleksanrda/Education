USE FlowerDatabase
GO

INSERT INTO [dbo].[WarehouseFlowers]
			([Id],
			[WarehouseId],
			[FlowerId],
			[Amount])
	VALUES
			(1, 2, 1, 1000),
			(2, 4, 2, 5000 ),
			(3, 2, 3, 100),
			(4, 3, 4, 10),
			(5, 5, 5, 200)
GO
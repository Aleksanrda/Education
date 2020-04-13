USE FlowerDatabase
GO

INSERT INTO [dbo].[SupplyFlowers]
			([Id],
			[SupplyId],
			[FlowerId],
			[Amount])
	VALUES
			(1, 2, 1, 100),
			(2, 4, 2, 500 ),
			(3, 2, 3, 1000),
			(4, 3, 4, 10000),
			(5, 5, 5, 2000)
GO
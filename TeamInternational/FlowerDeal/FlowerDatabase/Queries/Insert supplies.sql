USE FlowerDatabase
GO

INSERT INTO [dbo].[Supplies]
			([Id],
			[PlantationId],
			[WarehouseId],
			[SheduledData],
			[ClosedData],
			[Status])
	VALUES
			(6, 1, 1,'2020-01-24', '2020-02-25', 'OK'),
			(2, 1, 2, '2020-01-23', '', 'NOT'),
			(3, 2, 1, '2020-01-22', '2020-02-25', 'OK'),
			(4, 3, 4, '2020-01-22', '2020-02-25', 'OK'),
			(5, 5, 5, '2020-01-29', '', 'NOT')
GO
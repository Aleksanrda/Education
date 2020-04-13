USE FlowerDatabase;

BEGIN TRANSACTION 
    UPDATE Supplies
	SET Status = 'Closed', ClosedData = GETDATE() WHERE  Id = 1

    IF (@@error <> 0)
        ROLLBACK
COMMIT
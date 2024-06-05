-- This file is for testing purposes only. It will measure the time it takes to execute a query with and without indexes.


IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_ticket_requester_id' AND object_id = OBJECT_ID('BUD.ticket'))
    DROP INDEX IX_ticket_requester_id ON BUD.ticket;

IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_ticket_priority_id' AND object_id = OBJECT_ID('BUD.ticket'))
    DROP INDEX IX_ticket_priority_id ON BUD.ticket;

IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_ticket_status_id' AND object_id = OBJECT_ID('BUD.ticket'))
    DROP INDEX IX_ticket_status_id ON BUD.ticket;


DECLARE @start DATETIME, @end DATETIME;

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE requester_id = 1;
SELECT @end = GETDATE();
PRINT 'Time without index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE priority_id = 1;
SELECT @end = GETDATE();
PRINT 'Time without index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE status_id = 1;
SELECT @end = GETDATE();
PRINT 'Time without index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

-- Create indexes
CREATE INDEX IX_ticket_requester_id ON BUD.ticket(requester_id);
CREATE INDEX IX_ticket_priority_id ON BUD.ticket(priority_id);
CREATE INDEX IX_ticket_status_id ON BUD.ticket(status_id);

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE requester_id = 1;
SELECT @end = GETDATE();
PRINT 'Time with index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE priority_id = 1;
SELECT @end = GETDATE();
PRINT 'Time with index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

SELECT @start = GETDATE();
SELECT * FROM BUD.ticket WHERE status_id = 1;
SELECT @end = GETDATE();
PRINT 'Time with index: ' + CAST(DATEDIFF(MILLISECOND, @start, @end) AS VARCHAR) + 'ms';

-- Drop indexes
DROP INDEX BUD.ticket.IX_ticket_requester_id;
DROP INDEX BUD.ticket.IX_ticket_priority_id;
DROP INDEX BUD.ticket.IX_ticket_status_id;


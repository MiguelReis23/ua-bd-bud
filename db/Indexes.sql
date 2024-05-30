-- This file is responsible for creating all indexes needed.

USE BUD
GO

IF OBJECT_ID('BUD.IX_ticket_requester_id', 'U') IS NOT NULL DROP INDEX BUD.IX_ticket_requester_id;
IF OBJECT_ID('BUD.IX_ticket_priority_id', 'U') IS NOT NULL DROP INDEX BUD.IX_ticket_priority_id;
IF OBJECT_ID('BUD.IX_ticket_status_id', 'U') IS NOT NULL DROP INDEX BUD.IX_ticket_status_id;
GO


CREATE INDEX IX_ticket_requester_id ON BUD.ticket(requester_id);

CREATE INDEX IX_ticket_priority_id ON BUD.ticket(priority_id);

CREATE INDEX IX_ticket_status_id ON BUD.ticket(status_id);


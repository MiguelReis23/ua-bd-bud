-- File for creating Triggers in the database.
-- these are automatic triggers that maintain the integrity of the database.


IF OBJECT_ID('BUD.TicketReopened', 'TR') IS NOT NULL DROP TRIGGER BUD.TicketReopened;
IF OBJECT_ID('BUD.DeleteMessagesAndAttachments', 'TR') IS NOT NULL DROP TRIGGER BUD.DeleteMessagesAndAttachments;
IF OBJECT_ID('BUD.DeleteUserDepartmentofUser', 'TR') IS NOT NULL DROP TRIGGER BUD.DeleteUserDepartmentofUser;
IF OBJECT_ID('BUD.DeleteUserDepartmentofDepartment', 'TR') IS NOT NULL DROP TRIGGER BUD.DeleteUserDepartmentofDepartment;
GO

-- When Ticket is reopened clear the closed date and rating
CREATE TRIGGER BUD.TicketReopened
ON BUD.ticket
INSTEAD OF UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.id = d.id WHERE (i.status_id = 1 OR i.status_id = 2) AND d.status_id = 3)
    BEGIN
        UPDATE t
        SET status_id = i.status_id,
            priority_id = i.priority_id,
            requester_id = i.requester_id,
            responsible_id = i.responsible_id,
            submit_date = i.submit_date,
            closed_date = NULL,
            category_id = i.category_id,
            rating = NULL
        FROM BUD.ticket t
        INNER JOIN inserted i ON t.id = i.id;
    END
    ELSE
    BEGIN
        UPDATE t
        SET status_id = i.status_id,
            priority_id = i.priority_id,
            requester_id = i.requester_id,
            responsible_id = i.responsible_id,
            submit_date = i.submit_date,
            closed_date = i.closed_date,
            category_id = i.category_id,
            rating = i.rating
        FROM BUD.ticket t
        INNER JOIN inserted i ON t.id = i.id;
    END
END
GO

-- Delete all messages and attachments when a ticket is deleted
CREATE TRIGGER BUD.DeleteMessagesAndAttachments
ON BUD.ticket
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM BUD.attachment WHERE ticket IN (SELECT id FROM deleted);
    DELETE FROM BUD.message WHERE ticket_id IN (SELECT id FROM deleted);
    DELETE FROM BUD.ticket WHERE id IN (SELECT id FROM deleted);
END
GO

-- Delete all userdepartments when a user is deleted
CREATE TRIGGER BUD.DeleteUserDepartmentofUser
ON BUD.[user]
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM BUD.userdepartment WHERE user_id IN (SELECT id FROM deleted);
    DELETE FROM BUD.[user] WHERE id IN (SELECT id FROM deleted);
END
GO

-- Delete all userdepartments when a department is deleted
CREATE TRIGGER BUD.DeleteUserDepartmentofDepartment
ON BUD.department
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM BUD.userdepartment WHERE department IN (SELECT code FROM deleted);
    DELETE FROM BUD.department WHERE code IN (SELECT code FROM deleted);
END
GO
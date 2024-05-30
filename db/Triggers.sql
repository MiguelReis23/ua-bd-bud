-- File for creating Triggers in the database.
-- these are automatic triggers that maintain the integrity of the database.
USE BUD
GO

IF OBJECT_ID('BUD.PreventUpdateClosedTicket', 'TR') IS NOT NULL DROP TRIGGER BUD.PreventUpdateClosedTicket;
IF OBJECT_ID('BUD.DeleteMessagesAndAttachments', 'TR') IS NOT NULL DROP TRIGGER BUD.DeleteMessagesAndAttachments;
GO


-- Prevent update of a closed ticket
CREATE TRIGGER BUD.PreventUpdateClosedTicket
ON BUD.ticket
AFTER UPDATE 
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE status_id = 3)
    BEGIN
        RAISERROR ('Cannot update a closed ticket.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

-- Delete all messages and attachments when a ticket is deleted
CREATE TRIGGER BUD.DeleteMessagesAndAttachments
ON BUD.ticket
AFTER DELETE
AS
BEGIN
    DELETE FROM BUD.message WHERE id IN (SELECT id FROM deleted);
    DELETE FROM BUD.attachment WHERE id IN (SELECT id FROM deleted);
END
GO

-- Delete all userdepartments when a user or department is deleted
CREATE TRIGGER BUD.DeleteUserDepartmentofUser
ON BUD.[user]
AFTER DELETE
AS
BEGIN
    DELETE FROM BUD.userdepartment WHERE user_id IN (SELECT id FROM deleted);
END
GO

CREATE TRIGGER BUD.DeleteUserDepartmentofDepartment
ON BUD.department
AFTER DELETE
AS
BEGIN
    DELETE FROM BUD.userdepartment WHERE department IN (SELECT code FROM deleted);
END
GO

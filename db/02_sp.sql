-- File for creating stored procedures in the database.

USE BUD

IF OBJECT_ID('CreateUser', 'P') IS NOT NULL
    DROP PROC CreateUser
GO
IF OBJECT_ID('AssociateUserToRole', 'P') IS NOT NULL
    DROP PROC AssociateUserToRole
GO
IF OBJECT_ID('AddUserToDepartment', 'P') IS NOT NULL
    DROP PROC AddUserToDepartment
GO
IF OBJECT_ID('AuthenticateUser', 'P') IS NOT NULL
    DROP PROC AuthenticateUser
GO
IF OBJECT_ID('CreateTicket', 'P') IS NOT NULL
    DROP PROC CreateTicket
GO
IF TYPE_ID('ticket_fieldtype') IS NOT NULL
    DROP TYPE ticket_fieldtype
GO
IF OBJECT_ID('SendMessage', 'P') IS NOT NULL
    DROP PROC SendMessage
GO
IF OBJECT_ID('SendAttachmentMessage', 'P') IS NOT NULL
    DROP PROC SendAttachmentMessage
GO
IF OBJECT_ID('SendAttachment', 'P') IS NOT NULL
    DROP PROC SendAttachment
GO
IF OBJECT_ID('SeeUserTickets', 'P') IS NOT NULL
    DROP PROC SeeUserTickets
GO
IF OBJECT_ID('UpdateTicket', 'P') IS NOT NULL
    DROP PROC UpdateTicket
GO  
IF OBJECT_ID('GetMessagesByTicket', 'P') IS NOT NULL
    DROP PROC GetMessagesByTicket
GO
IF OBJECT_ID('SetTicketRating', 'P') IS NOT NULL
    DROP PROC SetTicketRating
GO
IF OBJECT_ID('DeleteTicket', 'P') IS NOT NULL
    DROP PROC DeleteTicket
GO
-- CREATE USER
CREATE PROC CreateUser
    @name VARCHAR(255),
    @email VARCHAR(128),
    @picture VARBINARY(MAX) = NULL,
    @password VARCHAR(255),
    @department INT = NULL
AS
BEGIN
    DECLARE @user_id INT
    SET @user_id = (SELECT ISNULL(MAX(id), 0) + 1 FROM BUD.[user])

    DECLARE @picture_id INT
    SET @picture_id = (SELECT ISNULL(MAX(id), 0) + 1 FROM BUD.picture)

    DECLARE @salt UNIQUEIDENTIFIER
    DECLARE @salted_password VARBINARY(32)

    SET @salt = NEWID()
    SET @salted_password = HASHBYTES('SHA2_256', @password + CONVERT(VARCHAR(36), @salt))

    IF NOT EXISTS (SELECT * FROM BUD.[user] WHERE email = @email)
    BEGIN
        BEGIN TRANSACTION T1
        BEGIN TRY
            IF @picture IS NOT NULL
            BEGIN
                INSERT INTO BUD.picture (id, [data])
                VALUES (@picture_id, @picture)
            END

            INSERT INTO BUD.[user] (id, full_name, email, picture, password_hash, salt)
            VALUES (@user_id, @name, @email, CASE WHEN @picture IS NOT NULL THEN @picture_id ELSE NULL END, @salted_password, @salt)
            
            IF @department IS NOT NULL
            BEGIN
                INSERT INTO BUD.userdepartment (user_id, department, startdate)
                VALUES (@user_id, @department, GETDATE())
            END

            COMMIT TRANSACTION T1
            PRINT 'SUCCESS: User created'
            RETURN 1
        END TRY
        BEGIN CATCH
            PRINT ERROR_MESSAGE()
            ROLLBACK TRANSACTION T1
            RETURN 0
        END CATCH
    END
    ELSE
    BEGIN
        PRINT 'ERROR: User already exists'
        RETURN 0
    END
END
GO


-- ASSOCIATE USERS TO ROLE
CREATE PROC AssociateUserToRole
    @user_id INT = NULL,
    @email VARCHAR(128) = NULL,
    @begin_date DATE = NULL,
    @end_date DATE = NULL,
    @nmec INT,
    @role VARCHAR(50)
AS
BEGIN
    DECLARE @role_id INT

    -- Ensure @role variable is properly declared
    IF @role IS NULL
    BEGIN
        PRINT 'ERROR: Role must be provided'
        RETURN 0
    END

    SET @role_id = (SELECT id FROM BUD.roles WHERE [name] = @role)

    IF @role_id IS NULL
    BEGIN
        PRINT 'ERROR: Role not found'
        RETURN 0
    END

    -- Define proper date
    IF @begin_date IS NULL
        SET @begin_date = GETDATE()

    IF @user_id IS NULL
    BEGIN
        IF @email IS NULL
        BEGIN
            PRINT 'ERROR: User id or email must be provided'
            RETURN 0
        END
        ELSE
        BEGIN
            SET @user_id = (SELECT id FROM BUD.[user] WHERE email = @email)
        END
    END

    IF NOT EXISTS (SELECT * FROM BUD.UserRoles WHERE [user_id] = @user_id AND role_id = @role_id)
    BEGIN
        BEGIN TRANSACTION T2
        BEGIN TRY
            INSERT INTO BUD.UserRoles
                ([user_id], role_id, begin_date, end_date, nmec)
            VALUES
                (@user_id, @role_id, @begin_date, @end_date, @nmec)
            COMMIT TRANSACTION T2
            PRINT 'SUCCESS: User associated to ' + @role + ' role'
            RETURN 1
        END TRY
        BEGIN CATCH
            PRINT ERROR_MESSAGE()
            ROLLBACK TRANSACTION T2
            RETURN 0
        END CATCH;
    END
    ELSE
    BEGIN
        PRINT 'ERROR: User already has the role'
        RETURN 0
    END
END
GO

-- ASSOCIATE USERS TO DEPARTMENT
CREATE PROCEDURE AddUserToDepartment
    @user_id INT,
    @department_id INT,
    @start_date DATE,
    @end_date DATE = NULL
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Check if the user exists
        IF NOT EXISTS (SELECT 1 FROM BUD.[user] WHERE id = @user_id)
        BEGIN
            PRINT 'ERROR: User does not exist'
            ROLLBACK TRANSACTION
            RETURN 0
        END

        -- Check if the department exists
        IF NOT EXISTS (SELECT 1 FROM BUD.department WHERE code = @department_id)
        BEGIN
            PRINT 'ERROR: Department does not exist'
            ROLLBACK TRANSACTION
            RETURN 0
        END

        -- Check if the association already exists
        IF EXISTS (SELECT 1 FROM BUD.userdepartment WHERE user_id = @user_id AND department = @department_id)
        BEGIN
            PRINT 'ERROR: User is already associated with this department'
            ROLLBACK TRANSACTION
            RETURN 0
        END

        -- Insert the association
        INSERT INTO BUD.userdepartment (user_id, department, startdate, enddate)
        VALUES (@user_id, @department_id, @start_date, @end_date)

        COMMIT TRANSACTION
        PRINT 'SUCCESS: User associated with department'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION
        RETURN 0
    END CATCH
END
GO

-- AUTHENTICATE USER
CREATE PROC AuthenticateUser
    @Email VARCHAR(128),
    @Password VARCHAR(255),
	@Result INT OUTPUT
AS
BEGIN
    DECLARE @StoredPasswordHash VARCHAR(255)
    DECLARE @StoredSalt UNIQUEIDENTIFIER
    DECLARE @ProvidedPasswordHash VARCHAR(255)
    DECLARE @UserId INT

    SELECT 
        @StoredPasswordHash = password_hash,
        @StoredSalt = salt,
        @UserId = id
    FROM 
        BUD.[user]
    WHERE 
        email = @Email

    IF @StoredPasswordHash IS NULL OR @StoredSalt IS NULL
    BEGIN
        PRINT 'ERROR: Invalid email or password'
		SET @Result = 0
        RETURN
    END

    SET @ProvidedPasswordHash = HASHBYTES('SHA2_256', @Password + CONVERT(VARCHAR(36), @StoredSalt))

    IF @ProvidedPasswordHash = @StoredPasswordHash
    BEGIN
		PRINT 'SUCCESS: Authentication successful'
        SET @Result = @UserId
    END
    ELSE
    BEGIN
		PRINT 'ERROR: Invalid email or password'
        SET @Result = 0
    END
END
GO

-- CREATE the TVP for ticket fields
CREATE TYPE ticket_fieldtype AS TABLE
(
    field_id INT,
    [value] VARCHAR(255)
)
GO

-- CREATE TICKET
CREATE PROCEDURE CreateTicket
    @requester_id INT,
    @priority_id INT,
    @category_id INT,
    @fields ticket_fieldtype READONLY
AS
BEGIN
    DECLARE @ticket_id INT
    DECLARE @status_id INT
    SET @status_id = 1; -- Open

    DECLARE @submit_date DATE
    SET @submit_date = GETDATE()

    BEGIN
        BEGIN TRANSACTION T3
        BEGIN TRY
                INSERT INTO BUD.ticket (requester_id, submit_date, priority_id, status_id, category_id)
                VALUES (@requester_id, @submit_date, @priority_id, @status_id, @category_id)

                SET @ticket_id = (SELECT SCOPE_IDENTITY())

                INSERT INTO BUD.ticket_field (ticket_id, field_id, [value])
                SELECT @ticket_id, field_id, [value]
                FROM @fields;
            COMMIT TRANSACTION T3
            PRINT 'SUCCESS: Ticket created'
            RETURN 1
        END TRY
        BEGIN CATCH
            PRINT ERROR_MESSAGE()
            ROLLBACK TRANSACTION T3
            RETURN 0
        END CATCH
    END
END
GO

-- SEND MESSAGE
CREATE PROC SendMessage
    @sender_id INT,
    @ticket_id INT,
    @content VARCHAR(max)
AS
BEGIN
        DECLARE @message_id INT

        DECLARE @time_stamp DATETIME
        SET @time_stamp = GETDATE()

        IF @content IS NULL
        BEGIN
            PRINT 'ERROR: Message content cannot be null'
            RETURN 0
        END
    BEGIN TRANSACTION T4
    BEGIN TRY
        INSERT INTO BUD.message (sender_id, ticket_id, content, time_stamp)
        VALUES (@sender_id, @ticket_id, @content, @time_stamp)

        SET @message_id = (SELECT SCOPE_IDENTITY())

        COMMIT TRANSACTION T4
        PRINT 'SUCCESS: Message sent'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION T4
        RETURN 0
    END CATCH
END
GO

-- SEND ATTACHMENT MESSAGE
CREATE PROC SendAttachmentMessage
    @sender_id INT,
    @ticket_id INT,
    @content VARCHAR(max),
    @file_name VARCHAR(50),
    @data VARBINARY(MAX)
AS
BEGIN
    DECLARE @message_id INT
    DECLARE @attachment_id INT

    DECLARE @time_stamp DATETIME
    SET @time_stamp = GETDATE()

    BEGIN TRANSACTION T5
    BEGIN TRY
        INSERT INTO BUD.message (sender_id, ticket_id, content, time_stamp)
        VALUES (@sender_id, @ticket_id, @content, @time_stamp)
    
        SET @message_id = (SELECT SCOPE_IDENTITY())

        INSERT INTO BUD.attachment ( file_name, [data], ticket, sender, time_stamp, message_id)
        VALUES (@file_name, @data, @ticket_id, @sender_id, @time_stamp, @message_id)
    
        COMMIT TRANSACTION T5
        PRINT 'SUCCESS: Attachment sent'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION T5
        RETURN 0
    END CATCH
END
GO

-- SEND ATTACHMENT ONLY
CREATE PROC SendAttachment
    @sender_id INT,
    @ticket_id INT,
    @file_name VARCHAR(50),
    @data VARBINARY(MAX)
AS
BEGIN
    DECLARE @attachment_id INT
    DECLARE @time_stamp DATETIME
    SET @time_stamp = GETDATE()

    BEGIN TRANSACTION T6
    BEGIN TRY
        INSERT INTO BUD.attachment (file_name, [data], ticket, sender, time_stamp)
        VALUES (@file_name, @data, @ticket_id, @sender_id, @time_stamp)
        
        COMMIT TRANSACTION T6
        PRINT 'SUCCESS: Attachment sent'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION T6
        RETURN 0
    END CATCH
END
GO

-- SEE USER TICKETS
CREATE PROC SeeUserTickets
    @user_id INT = NULL,
    @service_id INT = NULL,
    @category_id INT = NULL,
    @status_id INT = NULL,
    @priority_id INT = NULL
AS
BEGIN
    SELECT
        t.id AS ticket_id,
        t.submit_date,
        t.closed_date,
        t.rating,
        s.[name] AS status,
        p.[name] AS priority,
        c.[name] AS category,
        [service].[name] AS service
    FROM
        BUD.ticket t
        JOIN BUD.status s ON t.status_id = s.id
        JOIN BUD.priority p ON t.priority_id = p.id
        JOIN BUD.category c ON t.category_id = c.id
        JOIN BUD.service [service] ON c.service_id = [service].id
    WHERE
        (@user_id IS NULL OR t.requester_id = @user_id)
        AND (@service_id IS NULL OR c.service_id = @service_id)
        AND (@category_id IS NULL OR t.category_id = @category_id)
        AND (@status_id IS NULL OR t.status_id = @status_id)
        AND (@priority_id IS NULL OR t.priority_id = @priority_id)
END
GO

-- UPDATE TICKET 
CREATE PROCEDURE UpdateTicket
    @ticket_id INT,
    @status_id INT = NULL,
    @priority_id INT = NULL,
    @responsible_id INT = NULL
AS
BEGIN
    DECLARE @closed_date DATETIME
    BEGIN TRANSACTION T7
    BEGIN TRY
        IF @priority_id IS NOT NULL
        BEGIN
            UPDATE BUD.ticket
            SET priority_id = @priority_id
            WHERE id = @ticket_id
        END

        IF @responsible_id IS NOT NULL
        BEGIN
            UPDATE BUD.ticket
            SET responsible_id = @responsible_id
            WHERE id = @ticket_id
        END

        IF @status_id IS NOT NULL
        BEGIN
            UPDATE BUD.ticket
            SET status_id = @status_id,
                closed_date = CASE WHEN @status_id = 3 THEN GETDATE() ELSE closed_date END
            WHERE id = @ticket_id
        END

        COMMIT TRANSACTION T7
        PRINT 'SUCCESS: Ticket updated'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION T7
        RETURN 0
    END CATCH
END
GO

-- GET MESSAGES BY TICKET
CREATE PROCEDURE GetMessagesByTicket
    @ticket_id INT
AS
BEGIN
    SELECT
        m.id AS message_id,
        m.sender_id,
        m.content,
        m.time_stamp,
        a.file_name,
        a.[data]
    FROM
        BUD.message m
        LEFT JOIN BUD.attachment a ON m.id = a.message_id
    WHERE
        m.ticket_id = @ticket_id
END
GO

-- SET TICKET RATING
CREATE PROCEDURE SetTicketRating
    @ticket_id INT,
    @rating INT
AS
BEGIN
    IF @rating < 0 OR @rating > 5
    BEGIN
        PRINT 'ERROR: Rating must be between 0 and 5'
        RETURN 0
    END

    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE BUD.ticket
        SET rating = @rating
        WHERE id = @ticket_id

        IF @@ROWCOUNT = 0
        BEGIN
            PRINT 'ERROR: Ticket ID not found'
            ROLLBACK TRANSACTION
            RETURN 0
        END

        COMMIT TRANSACTION
        PRINT 'SUCCESS: Rating updated'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION
        RETURN 0
    END CATCH
END
GO

-- DELETE TICKET
CREATE PROCEDURE DeleteTicket
    @ticket_id INT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM BUD.ticket
        WHERE id = @ticket_id

        IF @@ROWCOUNT = 0
        BEGIN
            PRINT 'ERROR: Ticket ID not found'
            ROLLBACK TRANSACTION
            RETURN 0
        END

        COMMIT TRANSACTION
        PRINT 'SUCCESS: Ticket deleted'
        RETURN 1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION
        RETURN 0
    END CATCH
END
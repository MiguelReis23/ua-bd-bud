-- This file is for inserting sample datas in th


-- CREATE USERS
EXECUTE CreateUser 'João Almeida Santos', 'jas@ua.pt', NULL, 'jas123', 4
EXECUTE CreateUser 'Maria João Silva', 'mjs@ua.pt', NULL, 'mjs123', 8
EXECUTE CreateUser 'José Manuel', 'jm@ua.pt', NULL, 'jm123', 21
EXECUTE CreateUser 'Carlos Guilherme Penedo', 'cgp@ua.pt', NULL, 'cgp123', 22
GO

-- ASSOCIATE USERS TO ROLE
EXECUTE AssociateUserToRole @email = 'jas@ua.pt', @role = 'Student', @nmec = 12345
EXECUTE AssociateUserToRole @user_id = 2, @role = 'Teacher', @nmec = 54321
EXECUTE AssociateUserToRole @email = 'jm@ua.pt', @role = 'Administator', @nmec = 67890
EXECUTE AssociateUserToRole @user_id = 4, @role = 'Staff', @nmec = 98765, @begin_date = '2021-01-01'
EXECUTE AssociateUserToRole @user_id = 1, @role = 'Teacher', @nmec = 10345, @begin_date = '2024-02-03'
GO

-- ASSOCIATE USERS TO DEPARTMENT
EXEC AddUserToDepartment @user_id = 1, @department_id = 4, @start_date = '2024-05-29';
EXEC AddUserToDepartment @user_id = 2, @department_id = 4, @start_date = '2024-05-29';
GO

DECLARE @i INT = 1;
DECLARE @requester_id INT, @priority_id INT;
DECLARE @fields ticket_fieldtype;

WHILE @i <= 5000
BEGIN
    -- Generate random requester_id and priority_id between 1, 2 and 3
    SELECT @requester_id = CAST(RAND() * (3-1+1) as INT) + 1;
    SELECT @priority_id = CAST(RAND() * (3-1+1) as INT) + 1;

    INSERT INTO @fields (field_id, [value])
    VALUES
        (1, 'DETI'),
        (2, 'GLUA@ua.pt'),
        (3, 'GLUA'),
        (4, 'Miguel Vila');

    EXECUTE CreateTicket @requester_id = @requester_id, @priority_id = @priority_id, @category_id = 1, @fields = @fields;

    -- Clear the table variable for the next iteration
    DELETE FROM @fields;

    SET @i = @i + 1;
END
GO

DECLARE @i INT = 1;
DECLARE @requester_id INT, @priority_id INT;
DECLARE @fields ticket_fieldtype;

SET @i = 1;

WHILE @i <= 5000
BEGIN
    -- Generate random requester_id and priority_id between 1, 2 and 3
    SELECT @requester_id = CAST(RAND() * (3-1+1) as INT) + 1;
    SELECT @priority_id = CAST(RAND() * (3-1+1) as INT) + 1;

    INSERT INTO @fields (field_id, [value])
    VALUES
        (1, 'DETI'),
        (5, 'Teste@ua.pt'),
        (6, 'mreis@ua.pt');

    EXECUTE CreateTicket @requester_id = @requester_id, @priority_id = @priority_id, @category_id = 2, @fields = @fields;

    -- Clear the table variable for the next iteration
    DELETE FROM @fields;

    SET @i = @i + 1;
END
GO

DECLARE @i INT = 1;
DECLARE @requester_id INT, @priority_id INT;
DECLARE @fields ticket_fieldtype;

SET @i = 1;

WHILE @i <= 5000
BEGIN
    -- Generate random requester_id and priority_id between 1, 2 and 3
    SELECT @requester_id = CAST(RAND() * (3-1+1) as INT) + 1;
    SELECT @priority_id = CAST(RAND() * (3-1+1) as INT) + 1;

    INSERT INTO @fields (field_id, [value])
    VALUES
        (7, 'mreis@ua.pt'),
        (16, 'lucio@ua.pt');

    EXECUTE CreateTicket @requester_id = @requester_id, @priority_id = @priority_id, @category_id = 3, @fields = @fields;

    -- Clear the table variable for the next iteration
    DELETE FROM @fields;

    SET @i = @i + 1;
END
GO

DECLARE @i INT = 1;
DECLARE @requester_id INT, @priority_id INT;
DECLARE @fields ticket_fieldtype;

SET @i = 1;

WHILE @i <= 5000
BEGIN
    -- Generate random requester_id and priority_id between 1, 2 and 3
    SELECT @requester_id = CAST(RAND() * (3-1+1) as INT) + 1;
    SELECT @priority_id = CAST(RAND() * (3-1+1) as INT) + 1;

    INSERT INTO @fields (field_id, [value])
    VALUES
        (1, 'DETI'),
        (8, 'Secretaria');

    EXECUTE CreateTicket @requester_id = @requester_id, @priority_id = @priority_id, @category_id = 4, @fields = @fields;

    -- Clear the table variable for the next iteration
    DELETE FROM @fields;

    SET @i = @i + 1;
END
GO

-- SEND MESSAGES
EXECUTE SendMessage @sender_id = 1, @ticket_id = 1, @content = 'Hello, I need an email account for GLUA'
GO

EXECUTE SendMessage @sender_id = 4, @ticket_id = 1, @content = 'Hello, I will take care of this'
GO
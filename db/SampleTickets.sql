-- This file is for inserting tickets into the database.

USE BUD
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
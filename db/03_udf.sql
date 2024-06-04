-- File for creating User Defined Functions (UDFs) in the database.
USE BUD
GO

IF OBJECT_ID('BUD.TotalTickets', 'FN') IS NOT NULL DROP FUNCTION BUD.TotalTickets;
IF OBJECT_ID('BUD.TotalTicketsWithStatus', 'FN') IS NOT NULL DROP FUNCTION BUD.TotalTicketsWithStatus;
IF OBJECT_ID('BUD.TotalTicketsWithPriority', 'FN') IS NOT NULL DROP FUNCTION BUD.TotalTicketsWithPriority;
IF OBJECT_ID('BUD.TotalTicketsWithCategory', 'FN') IS NOT NULL DROP FUNCTION BUD.TotalTicketsWithCategory;
IF OBJECT_ID('BUD.TotalTicketsWithService', 'FN') IS NOT NULL DROP FUNCTION BUD.TotalTicketsWithService;
GO

-- Function to get the total number of tickets in the system or the total number of tickets from a specific user.
CREATE FUNCTION BUD.TotalTickets(@user_id int = NULL)
RETURNS int
AS
BEGIN
    DECLARE @total int;

    IF @user_id IS NULL
        SELECT @total = COUNT(*) FROM BUD.ticket;
    ELSE
        SELECT @total = COUNT(*) FROM BUD.ticket WHERE requester_id = @user_id;

    RETURN @total;
END
GO

-- Function to get the total number of tickets with a specific status.
CREATE FUNCTION BUD.TotalTicketsWithStatus(@status_id int)
RETURNS int
AS
BEGIN
    DECLARE @total int;

    SELECT @total = COUNT(*) FROM BUD.ticket WHERE status_id = @status_id;

    RETURN @total;
END
GO

-- Function to get the total number of tickets with a specific priority.
CREATE FUNCTION BUD.TotalTicketsWithPriority(@priority_id int)
RETURNS int
AS
BEGIN
    DECLARE @total int;

    SELECT @total = COUNT(*) FROM BUD.ticket WHERE priority_id = @priority_id;

    RETURN @total;
END
GO

-- Function to get the total number of tickets with a specific category.
CREATE FUNCTION BUD.TotalTicketsWithCategory(@category_id int)
RETURNS int
AS
BEGIN
    DECLARE @total int;

    SELECT @total = COUNT(*) FROM BUD.ticket WHERE category_id = @category_id;

    RETURN @total;
END
GO

-- Function to get the total number of tickets with a specific service.
CREATE FUNCTION BUD.TotalTicketsWithService(@service_id int)
RETURNS int
AS
BEGIN
    DECLARE @total int;

    SELECT @total = COUNT(*) FROM BUD.ticket t
    JOIN BUD.category c ON t.category_id = c.id
    WHERE c.service_id = @service_id;

    RETURN @total;
END
GO

-- -- Query to get total tickets
-- SELECT BUD.TotalTickets(NULL) AS TotalTickets;

-- -- Queries to get total tickets by priority
-- SELECT BUD.TotalTicketsWithPriority(1) AS LowPriorityTickets;
-- SELECT BUD.TotalTicketsWithPriority(2) AS MediumPriorityTickets;
-- SELECT BUD.TotalTicketsWithPriority(3) AS HighPriorityTickets;

-- -- Queries to get total tickets by status
-- SELECT BUD.TotalTicketsWithStatus(1) AS OpenTickets;
-- SELECT BUD.TotalTicketsWithStatus(2) AS ClosedTickets;
-- SELECT BUD.TotalTicketsWithStatus(3) AS TicketsInProgress;


-- -- Test TotalTickets function
-- SELECT BUD.TotalTickets(NULL) AS TotalTickets;

-- SELECT BUD.TotalTickets(1) AS TotalTicketsForUser1;

-- SELECT BUD.TotalTicketsWithPriority(1) AS TotalTicketsWithPriority1; 

-- SELECT BUD.TotalTicketsWithCategory(1) AS TotalTicketsWithCategory1; 

-- SELECT BUD.TotalTicketsWithService(1) AS TotalTicketsWithService1;
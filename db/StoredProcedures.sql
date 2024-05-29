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
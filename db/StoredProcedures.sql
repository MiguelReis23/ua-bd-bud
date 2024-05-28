IF OBJECT_ID('CreateUser', 'P') IS NOT NULL
    DROP PROC CreateUser
GO
IF OBJECT_ID('AssociateUserToRole', 'P') IS NOT NULL
    DROP PROC AssociateUserToRole
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
    SET @user_id = (SELECT MAX(id) + 1 FROM BUD.[user])

    DECLARE @picture_id INT
    SET @picture_id = (SELECT MAX(id) + 1 FROM BUD.picture)

	DECLARE @salt UNIQUEIDENTIFIER
    DECLARE @salted_password VARBINARY(32)

    SET @salt = NEWID()
    SET @salted_password = HASHBYTES('SHA2_256', @password + CONVERT(VARCHAR(36), @salt))

    IF @user_id IS NULL
        SET @user_id = 1

    IF @picture_id IS NULL
        SET @picture_id = 1

    IF NOT EXISTS (SELECT * FROM BUD.[user] WHERE email = @email)
    BEGIN
        BEGIN TRAN T1
        BEGIN TRY
            INSERT INTO BUD.picture
                (id, [data])
            VALUES
                (@picture_id, @picture)
            
            INSERT INTO BUD.[user]
                (id, full_name, email, picture, password_hash, salt, department)
            VALUES
				(@user_id, @name, @email, CASE WHEN @picture IS NOT NULL THEN @picture_id ELSE NULL END, @salted_password, @salt, @department)
            COMMIT TRAN T1
            PRINT 'SUCCESS: User created'
            RETURN 1
        END TRY
        BEGIN CATCH
            PRINT @@ERROR + ' ' + ERROR_MESSAGE()
            ROLLBACK TRANSACTION T1
            RETURN 0
        END CATCH;
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



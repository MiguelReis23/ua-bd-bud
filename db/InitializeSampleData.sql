-- This file will initialize the database with some sample data useful for showcasing. It's not mandatory, but it's useful to have some data to work with.
-- If you dont execute this file, there will be no users and its associated roles, departments, tickets, etc. in the database.

USE BUD

-- CREATE USERS
EXECUTE CreateUser 'João Almeida Santos', 'jas@ua.pt', NULL, 'jas123', 4
EXECUTE CreateUser 'Maria João Silva', 'mjs@ua.pt', NULL, 'mjs123', 8
EXECUTE CreateUser 'José Manuel', 'jm@ua.pt', NULL, 'jm123', 21
EXECUTE CreateUser 'Carlos Guilherme Penedo', 'cgp@ua.pt', NULL, 'cgp123', 22

-- ASSOCIATE USERS TO ROLE
EXECUTE AssociateUserToRole @email = 'jas@ua.pt', @role = 'Student', @nmec = 12345
EXECUTE AssociateUserToRole @user_id = 2, @role = 'Teacher', @nmec = 54321
EXECUTE AssociateUserToRole @email = 'jm@ua.pt', @role = 'Administator', @nmec = 67890
EXECUTE AssociateUserToRole @user_id = 4, @role = 'Staff', @nmec = 98765, @begin_date = '2021-01-01'
EXECUTE AssociateUserToRole @user_id = 1, @role = 'Teacher', @nmec = 10345
GO

-- ASSOCIATE USERS TO DEPARTMENT
EXEC AddUserToDepartment @user_id = 1, @department_id = 4, @start_date = '2024-05-29';
EXEC AddUserToDepartment @user_id = 2, @department_id = 4, @start_date = '2024-05-29';
GO

-- CREATE TICKET AND ITS FIELDS
DECLARE @fields ticket_fieldtype;
INSERT INTO @fields (field_id, [value])
VALUES
    (1, 'DETI'),
    (2, 'GLUA@ua.pt'),
    (3, 'GLUA'),
    (4, 'Miguel Vila')

EXECUTE CreateTicket @requester_id = 1,@priority_id = 1, @category_id = 1, @fields = @fields
GO

-- SEND A MESSAGE
EXECUTE SendMessage @sender_id = 1, @ticket_id = 1, @content = 'Hello, I need an email account for GLUA'
GO

-- SEND AN ATTACHMENT MESSAGE
EXECUTE SendAttachmentMessage @sender_id = 1, @ticket_id = 1, @file_name = 'teste.jpg', @data = 0x1234567890ABCDEF
GO

-- SEND AN ATTACHMENT
EXECUTE SendAttachment @file_name = 'teste2.jpg', @data = 0x9876543210FEDCBA, @ticket_id = 1, @sender_id = 1
GO
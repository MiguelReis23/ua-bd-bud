-- This file is responsible for creating all tables needed. Must be the first file to be executed.

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BUD')
BEGIN
	CREATE DATABASE BUD;
END
GO

USE BUD

IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = 'BUD')
BEGIN
	EXEC ('CREATE SCHEMA BUD AUTHORIZATION dbo')
END
GO

-- Drop tables if they already exist
IF OBJECT_ID('BUD.attachment', 'U') IS NOT NULL DROP TABLE BUD.attachment;
IF OBJECT_ID('BUD.article', 'U') IS NOT NULL DROP TABLE BUD.article;
IF OBJECT_ID('BUD.message', 'U') IS NOT NULL DROP TABLE BUD.message;
IF OBJECT_ID('BUD.ticket_field', 'U') IS NOT NULL DROP TABLE BUD.ticket_field;
IF OBJECT_ID('BUD.ticket', 'U') IS NOT NULL DROP TABLE BUD.ticket;
IF OBJECT_ID('BUD.category_field', 'U') IS NOT NULL DROP TABLE BUD.category_field;
IF OBJECT_ID('BUD.field', 'U') IS NOT NULL DROP TABLE BUD.field;
IF OBJECT_ID('BUD.category', 'U') IS NOT NULL DROP TABLE BUD.category;
IF OBJECT_ID('BUD.service', 'U') IS NOT NULL DROP TABLE BUD.service;
IF OBJECT_ID('BUD.room', 'U') IS NOT NULL DROP TABLE BUD.room;
IF OBJECT_ID('BUD.userdepartment', 'U') IS NOT NULL DROP TABLE BUD.userdepartment;
IF OBJECT_ID('BUD.UserRoles', 'U') IS NOT NULL DROP TABLE BUD.UserRoles;
IF OBJECT_ID('BUD.priority', 'U') IS NOT NULL DROP TABLE BUD.priority;
IF OBJECT_ID('BUD.status', 'U') IS NOT NULL DROP TABLE BUD.status;
IF OBJECT_ID('BUD.roles', 'U') IS NOT NULL DROP TABLE BUD.roles;
IF OBJECT_ID('BUD.[user]', 'U') IS NOT NULL DROP TABLE BUD.[user];
IF OBJECT_ID('BUD.picture', 'U') IS NOT NULL DROP TABLE BUD.picture;
IF OBJECT_ID('BUD.department', 'U') IS NOT NULL DROP TABLE BUD.department;

-- Create tables
CREATE TABLE BUD.department (
    code int PRIMARY KEY,
    name varchar(128) NOT NULL
);

CREATE TABLE BUD.picture (
    id int PRIMARY KEY,
    [data] varbinary(max)
);

CREATE TABLE BUD.[user] (
    id int PRIMARY KEY,
    full_name varchar(255) NOT NULL,
    email varchar(128) NOT NULL UNIQUE,
    picture int REFERENCES BUD.picture(id) ON DELETE SET NULL,
    password_hash varchar(255) NOT NULL,
    salt varchar(255) NOT NULL
);

CREATE TABLE BUD.roles(
    id int PRIMARY KEY,
    [name] varchar(50) NOT NULL
)

CREATE TABLE BUD.status(
    id int PRIMARY KEY,
    [name] varchar(25) NOT NULL
)

CREATE TABLE BUD.priority(
	id int PRIMARY KEY,
	[name] varchar(25) NOT NULL
)

CREATE TABLE BUD.UserRoles(
    [user_id] int NOT NULL REFERENCES BUD.[user](id) ON DELETE CASCADE,
    role_id int NOT NULL REFERENCES BUD.roles(id) ON DELETE CASCADE,
    begin_date date NOT NULL,
    end_date date,
    nmec int NOT NULL UNIQUE,
    PRIMARY KEY(user_id, role_id)
)

CREATE TABLE BUD.userdepartment (
    [user_id] int NOT NULL REFERENCES BUD.[user](id) ON DELETE CASCADE,
    department int NOT NULL REFERENCES BUD.department(code) ON DELETE CASCADE,
    startdate date NOT NULL,
    enddate date,
    PRIMARY KEY([user_id], department)
);

CREATE TABLE BUD.room (
    department_id int NOT NULL REFERENCES BUD.department(code) ON DELETE CASCADE,
    [floor] int NOT NULL,
    [number] int NOT NULL,
    [name] varchar(50) NOT NULL,
    PRIMARY KEY(department_id,[floor], [number])
);

CREATE TABLE BUD.[service] (
    id int PRIMARY KEY,
    [name] varchar(50) NOT NULL,
    [description] varchar(200) NOT NULL
);

CREATE TABLE BUD.category (
    id int PRIMARY KEY,
    [name] varchar(100) NOT NULL,
    [description] varchar(200) NOT NULL,
    minimum_role int NOT NULL REFERENCES BUD.roles(id) ON DELETE CASCADE,
    service_id int NOT NULL REFERENCES BUD.[service](id) ON DELETE CASCADE
);

CREATE TABLE BUD.field(
    id int NOT NULL PRIMARY KEY,
    [name] varchar(50) NOT NULL,
)

CREATE TABLE BUD.category_field(
    category_id int NOT NULL REFERENCES BUD.category(id) ON DELETE CASCADE,
    field_id int NOT NULL REFERENCES BUD.field(id) ON DELETE CASCADE,
    PRIMARY KEY(category_id, field_id)
)

CREATE TABLE BUD.ticket (
    id int PRIMARY KEY IDENTITY(1,1),
    requester_id int NOT NULL REFERENCES BUD.[user](id),
	responsible_id int REFERENCES BUD.[user](id),
    submit_date date NOT NULL,
    closed_date date,
    rating int CHECK (rating >= 0 AND rating <= 5),
    status_id int REFERENCES BUD.status(id),
    priority_id int REFERENCES BUD.priority(id),
    category_id int NOT NULL REFERENCES BUD.category(id)
);

CREATE TABLE BUD.ticket_field(
    ticket_id int NOT NULL REFERENCES BUD.ticket(id) ON DELETE CASCADE,
    field_id int NOT NULL REFERENCES BUD.field(id) ON DELETE CASCADE,
    [value] varchar(255) NOT NULL,
    PRIMARY KEY(ticket_id, field_id)
)

CREATE TABLE BUD.message (
    id int PRIMARY KEY IDENTITY(1,1),
    sender_id int NOT NULL REFERENCES BUD.[user](id),
    ticket_id int NOT NULL REFERENCES BUD.ticket(id),
    content varchar(max),
    time_stamp datetime NOT NULL,
);

CREATE TABLE BUD.article (
    id int PRIMARY KEY,
    title varchar(100) NOT NULL,
    author varchar(50) NOT NULL,
    content varchar(max) NOT NULL,
    [date] date NOT NULL,
    [service_id] int NOT NULL REFERENCES BUD.[service](id) ON DELETE CASCADE
);

CREATE TABLE BUD.attachment (
    id int PRIMARY KEY IDENTITY(1,1),
    file_name varchar(50) NOT NULL,
    [data] varbinary(max) NOT NULL,
    ticket int REFERENCES BUD.ticket(id),
    sender int NOT NULL REFERENCES BUD.[user](id),
    time_stamp datetime NOT NULL,
    message_id int REFERENCES BUD.message(id)
);

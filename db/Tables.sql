-- Create SCHEMA
--CREATE SCHEMA BUD;
--GO

-- Drop tables if they already exist
IF OBJECT_ID('BUD.attachment', 'U') IS NOT NULL DROP TABLE BUD.attachment;
IF OBJECT_ID('BUD.article', 'U') IS NOT NULL DROP TABLE BUD.article;
IF OBJECT_ID('BUD.message', 'U') IS NOT NULL DROP TABLE BUD.message;
IF OBJECT_ID('BUD.ticket', 'U') IS NOT NULL DROP TABLE BUD.ticket;
IF OBJECT_ID('BUD.category', 'U') IS NOT NULL DROP TABLE BUD.category;
IF OBJECT_ID('BUD.service', 'U') IS NOT NULL DROP TABLE BUD.service;
IF OBJECT_ID('BUD.room', 'U') IS NOT NULL DROP TABLE BUD.room;
IF OBJECT_ID('BUD.userdepartment', 'U') IS NOT NULL DROP TABLE BUD.userdepartment;
IF OBJECT_ID('BUD.UserRoles', 'U') IS NOT NULL DROP TABLE BUD.UserRoles;
IF OBJECT_ID('BUD.roles', 'U') IS NOT NULL DROP TABLE BUD.roles;
IF OBJECT_ID('BUD.[user]', 'U') IS NOT NULL DROP TABLE BUD.[user];
IF OBJECT_ID('BUD.picture', 'U') IS NOT NULL DROP TABLE BUD.picture;
IF OBJECT_ID('BUD.department', 'U') IS NOT NULL DROP TABLE BUD.department;

-- Create tables

CREATE TABLE BUD.department (
    code int PRIMARY KEY,
    name varchar(50) NOT NULL
);

CREATE TABLE BUD.picture (
    id int PRIMARY KEY,
    [data] varbinary(max) NOT NULL
);

CREATE TABLE BUD.[user] (
    id int PRIMARY KEY,
    name varchar(100) NOT NULL,
    email varchar(50) NOT NULL UNIQUE,
    lang varchar(15),
    picture int REFERENCES BUD.picture(id),
    password varchar(256) NOT NULL,
);

CREATE TABLE BUD.roles(
    id int PRIMARY KEY,
    [name] varchar(50) NOT NULL
)

CREATE TABLE BUD.UserRoles(
    [user_id] int NOT NULL REFERENCES BUD.[user](id),
    role_id int NOT NULL REFERENCES BUD.roles(id),
    begin_date date NOT NULL,
    end_date date,
    nmec int NOT NULL,
    PRIMARY KEY(user_id, role_id)
)

CREATE TABLE BUD.userdepartment (
    [user_id] int NOT NULL REFERENCES BUD.[user](id),
    department int NOT NULL REFERENCES BUD.department(code),
    startdate date NOT NULL,
    enddate date,
    PRIMARY KEY(nmec, department)
);

CREATE TABLE BUD.room (
    [number] int NOT NULL,
    [floor] int NOT NULL,
    name varchar(50) NOT NULL,
    department int NOT NULL REFERENCES BUD.department(code),
    PRIMARY KEY([number], [floor])
);

CREATE TABLE BUD.[service] (
    id int PRIMARY KEY,
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL
);

CREATE TABLE BUD.category (
    id int PRIMARY KEY,
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    auth_level int NOT NULL,
    [service] int NOT NULL REFERENCES BUD.[service](id)
);

CREATE TABLE BUD.ticket (
    id int PRIMARY KEY IDENTITY(1,1),
    requester int NOT NULL REFERENCES BUD.[user](id),
    submit_date date NOT NULL,
    closed_date date,
    rating int CHECK (rating >= 0 AND rating <= 5),
    [status] varchar(12) CHECK ([status] IN ('Open', 'In Progress', 'Closed')) NOT NULL DEFAULT 'Open',
    description varchar(200) NOT NULL,
    priority varchar(10) CHECK (priority IN ('Low', 'Medium', 'High')) NOT NULL,
    category int NOT NULL REFERENCES BUD.category(id)
);

CREATE TABLE BUD.message (
    sender int NOT NULL REFERENCES BUD.[user](id),
    receiver int NOT NULL REFERENCES BUD.[user](id),
    ticket int NOT NULL REFERENCES BUD.ticket(id),
    content varchar(500) NOT NULL,
    time_stamp datetime NOT NULL,
    PRIMARY KEY(sender, receiver, time_stamp, ticket)
);

CREATE TABLE BUD.article (
    id int PRIMARY KEY,
    title varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    content varchar(max) NOT NULL,
    [date] date NOT NULL,
    [service] int NOT NULL REFERENCES BUD.[service](id)
);

CREATE TABLE BUD.attachment (
    id int PRIMARY KEY,
    file_name varchar(50) NOT NULL,
    [data] varbinary(max) NOT NULL,
    ticket int REFERENCES BUD.ticket(id),
    sender int NOT NULL REFERENCES BUD.[user](id),
    receiver int NOT NULL REFERENCES BUD.[user](id),
    time_stamp datetime NOT NULL,
    FOREIGN KEY (sender, receiver, time_stamp, ticket) REFERENCES BUD.message(sender, receiver, time_stamp, ticket)
);

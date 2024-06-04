-- File for creating views in the database.

USE BUD;
GO

IF OBJECT_ID('BUD.UserInfo', 'V') IS NOT NULL DROP VIEW BUD.UserInfo;
GO

IF OBJECT_ID('BUD.ServiceCategoriesFields', 'V') IS NOT NULL DROP VIEW BUD.ServiceCategoriesFields;
GO

CREATE VIEW BUD.UserInfo AS
SELECT 
    u.id AS user_id,
    u.full_name,
    u.email,
    u.picture,
    d.code AS department_code,
    d.name AS department_name,
    r.id AS role_id,
    r.name AS role_name,
    ur.nmec,
    ur.begin_date AS role_begin_date,
    ur.end_date AS role_end_date,
    ud.startdate AS department_startdate,
    ud.enddate AS department_enddate
FROM 
    BUD.[user] u
LEFT JOIN 
    BUD.userdepartment ud ON u.id = ud.user_id
LEFT JOIN 
    BUD.department d ON ud.department = d.code
LEFT JOIN 
    BUD.UserRoles ur ON u.id = ur.user_id
LEFT JOIN 
    BUD.roles r ON ur.role_id = r.id;
GO

CREATE VIEW BUD.ServiceCategoriesFields AS
SELECT
    s.id AS service_id,
    s.name AS service_name,
    s.description AS service_description,
    c.id AS category_id,
    c.name AS category_name,
    c.description AS category_description,
    c.minimum_role AS category_minimum_role,
    f.id AS field_id,
    f.name AS field_name
FROM
    BUD.[service] s
JOIN
    BUD.category c ON s.id = c.service_id
JOIN
    BUD.category_field cf ON c.id = cf.category_id
JOIN
    BUD.field f ON cf.field_id = f.id;
GO
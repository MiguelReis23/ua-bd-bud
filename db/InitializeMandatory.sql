-- This file is responsible for initializing the database with some mandatory data. Must be the second file to be executed.
-- Withouth this file, we cannot create users, set roles, etc. because, obviously, we don't have any data to work with.

-- CREATE USER ROLES
USE BUD

INSERT INTO BUD.roles
    (id, [name])
VALUES
    (1, 'Student'),
    (2, 'Teacher'),
    (3, 'Administator'),
    (4, 'Staff')

-- CREATE STATUS
INSERT INTO BUD.status
    (id, [name])
VALUES
    (1, 'Open'),
    (2, 'In Progress'),
    (3, 'Closed')

-- CREATE PRIORITY
INSERT INTO BUD.priority
	(id, [name])
VALUES
	(1, 'High'),
	(2, 'Medium'),
	(3, 'Low')

-- CREATE DEPARTMENTS
INSERT INTO BUD.department
    (code, [name])
VALUES
    (2, 'DLC - Departamento de Línguas e Culturas'),
    (4, 'DETI - Departamento de Eletrónica, Telecomunicações e Informática'),
    (5, 'DEP - Departamento de Educação e Psicologia; Mediateca; UACoopera'),
    (7, 'DAO - Departamento de Ambiente e Ordenamento'),
    (8, 'DBIO - Departamento de Biologia'),
    (9, 'DEMC - Departamento de Engenharia de Materiais e Cerâmica'),
    (10, 'DEGEIT - Departamento de Economia, Gestão e Engenharia Industrial e Turismo'),
    (11, 'DMAT - Departamento de Matemática'),
    (12, 'DCSPT - Departamento de Ciências Sociais, Políticas e do Território'),
    (13, 'DFIS - Departamento de Física'),
    (14, 'LAB - Laboratório Central de Análises'),
    (15, 'DQ - Departamento de Química'),
    (16, 'DGEO - Departamento de Geociências'),
    (21, 'DECA - Departamento de Comunicação e Arte'),
    (22, 'DEM - Departamento de Engenharia Mecânica'),
    (23, 'CP - Complexo Pedagógico, Científico e Tecnológico'),
    (24, 'IEETA – Instituto de Engenharia Eletrónica e Telemática de Aveiro'),
    (27, 'STIC - Serviços de Tecnologias de Informação e Comunicação'),
    (28, 'DEC - Departamento de Engenharia Civil'),
    (29, 'CP - Complexo de Laboratórios Tecnológicos'),
    (32, 'CICFANO – Complexo Interdisciplinar de Ciências Físicas Aplicadas à Nanotecnologia e à Oceanografia'),
    (35, 'ISCA - Instituto Superior de Contabilidade e Administração da UA'),
    (36, 'ECOMARE - Laboratório para a Inovação e Sustentabilidade dos Recursos Biológicos Marinhos da Universidade de Aveiro'),
    (37, 'CESAM – Centro de Estudos do Ambiente e do Mar'),
    (40, 'CCCI – Complexo das Ciências de Comunicação e Imagem')

--CREATE SERVICES
INSERT INTO BUD.services
    (id, [name], description)
VALUES
    (1, 'Email', 'Manage and provide access to email accounts.'),
    (2, 'Web Hosting', 'Web content hosting platform for projects, partnerships, UCs and personal pages.'),
    (3, 'Audiovisual', 'Installation of equipment, management of the Educast platform and support for audiovisual productions.'),
    (4, 'E-Learning', 'Manage areas and users of the support platform for distance learning.'),
    (5, 'Online Surveys', 'Service to create forms and surveys for data collection within the scope of projects.'),
    (6, 'Networks', 'Departmental data communications service, internet access, through wired and wireless network.'),
    (7, 'User Management', 'Management of the electronic identity of the academic community users: personal data'),
    (8, 'Helpdesk', 'Technical support for face-to-face or video-call assistance.'),
    (9, 'Report an Incident', 'Request assistance for a security, performance, or availability issue.')

--CREATE CATEGORIES
INSERT INTO BUD.categories
    (id, [name], description, service_id)
VALUES
    (1, 'Create an email account for project, event or institution', 'Request the creation of an email account for a project, event or institution.', 3, 1),
    (2, 'Delegate access to project email account', 'Request access letting a user access a project email account.', 3, 1),
    (3, 'Redirect email to an external account', 'Request the redirection of an email account to an external account from other email providers.', 3, 1),
    (4, 'Delete a mailling list', 'Request the deletion of a mailing list.', 3, 1),
    (5, 'Change/Recover project email account password', 'Request the change or recovery of the password for a project email account.', 1, 1),
    (6, 'Request operations on generic websites', 'Request operation on generic websites related to projects, partnerships, UCs and personal pages.', 1, 2),
    (7, 'Educast', 'Platform for the dissemination of audiovisual content.', 2, 3),
    (8, 'Create an area in the e-learning platform', 'Request the creation of a page for a project, event or course in the e-learning platform.', 2, 4),
    (9, 'Associate user with course in Moodle', 'Request the association of a user with a course in the e-learning platform.', 1, 4),
    (10, 'Create / change physical connection to department network', 'Request the creation or change of a physical connection to the department network.', 1, 6)

--CREATE ROOMS
INSERT INTO BUD.room
    ([number], [floor], [name], department)
VALUES
    (1, 1, 'Auditorium 1', 1)
    (2, 1, 'Auditorium 2', 1)
    (1, 2, 'Room 2.1', 1)
    (2, 2, 'Room 2.2', 1)
    (3, 2, 'Room 2.3', 1)
    (4, 2, 'Room 2.4', 1)
    (5, 2, 'Room 2.5', 1)
    (6, 2, 'Room 2.6', 1)
    (7, 2, 'Room 2.7', 1)
    (8, 2, 'Room 2.8', 1)
    (9, 2, 'Room 2.9', 1)
    (1, 3, 'Office 3.1', 1)
    (2, 3, 'Office 3.2', 1)
    (3, 3, 'Office 3.3', 1)
    (4, 3, 'Office 3.4', 1)
    (5, 3, 'Office 3.5', 1)
    (1, 1, 'Room 1.1', 2)
    (2, 1, 'Room 1.2', 2)
    (3, 1, 'Room 1.3', 2)
    (4, 1, 'Room 1.4', 2)
    (5, 1, 'Room 1.5', 2)
    (6, 1, 'Room 1.6', 2)
    (7, 1, 'Room 1.7', 2)
    (8, 1, 'Room 1.8', 2)
    (9, 1, 'Room 1.9', 2)
    (1, 2, 'Room 2.1', 2)
    (2, 2, 'Room 2.2', 2)
    (3, 2, 'Room 2.3', 2)
    (4, 2, 'Room 2.4', 2)
    (5, 2, 'Room 2.5', 2)
    (6, 2, 'Room 2.6', 2)
    (7, 2, 'Room 2.7', 2)
    (8, 2, 'Room 2.8', 2)
    (9, 2, 'Room 2.9', 2)
    (1, 3, 'Office 3.1', 2)
    (2, 3, 'Office 3.2', 2)
    (3, 3, 'Office 3.3', 2)
    (4, 3, 'Office 3.4', 2)
    (5, 3, 'Office 3.5', 2)
    (1, 1, 'Room 1.1', 3)
    (2, 1, 'Room 1.2', 3)
    (3, 1, 'Room 1.3', 3)
    (4, 1, 'Room 1.4', 3)
    (5, 1, 'Room 1.5', 3)
    (6, 1, 'Room 1.6', 3)
    (7, 1, 'Room 1.7', 3)
    (8, 1, 'Room 1.8', 3)
    (9, 1, 'Room 1.9', 3)
    (1, 2, 'Room 2.1', 3)
    (2, 2, 'Room 2.2', 3)
    (3, 2, 'Room 2.3', 3)
    (4, 2, 'Room 2.4', 3)
    (5, 2, 'Room 2.5', 3)
    (6, 2, 'Room 2.6', 3)
    (7, 2, 'Room 2.7', 3)
    (8, 2, 'Room 2.8', 3)
    (9, 2, 'Room 2.9', 3)
    (1, 3, 'Office 3.1', 3)
    (2, 3, 'Office 3.2', 3)
    (3, 3, 'Office 3.3', 3)
    (4, 3, 'Office 3.4', 3)
    (5, 3, 'Office 3.5', 3)
    (1, 1, 'Room 1.1', 4)
    (2, 1, 'Room 1.2', 4)
    (3, 1, 'Room 1.3', 4)
    (4, 1, 'Room 1.4', 4)
    (5, 1, 'Room 1.5', 4)
    (6, 1, 'Room 1.6', 4)
    (7, 1, 'Room 1.7', 4)
    (8, 1, 'Room 1.8', 4)
    (9, 1, 'Room 1.9', 4)
    (1, 2, 'Room 2.1', 4)
    (2, 2, 'Room 2.2', 4)
    (3, 2, 'Room 2.3', 4)
    (4, 2, 'Room 2.4', 4)
    (5, 2, 'Room 2.5', 4)
    (6, 2, 'Room 2.6', 4)
    (7, 2, 'Room 2.7', 4)
    (8, 2, 'Room 2.8', 4)
    (9, 2, 'Room 2.9', 4)
    (1, 3, 'Office 3.1', 4)
    (2, 3, 'Office 3.2', 4)
    (3, 3, 'Office 3.3', 4)
    (4, 3, 'Office 3.4', 4)
    (5, 3, 'Office 3.5', 4)
    (1, 1, 'Room 1.1', 5)
    (2, 1, 'Room 1.2', 5)
    (3, 1, 'Room 1.3', 5)
    (4, 1, 'Room 1.4', 5)
    (5, 1, 'Room 1.5', 5)
    (6, 1, 'Room 1.6', 5)
    (7, 1, 'Room 1.7', 5)
    (8, 1, 'Room 1.8', 5)
    (9, 1, 'Room 1.9', 5)
    (1, 2, 'Room 2.1', 5)
    (2, 2, 'Room 2.2', 5)
    (3, 2, 'Room 2.3', 5)
    (4, 2, 'Room 2.4', 5)
    (5, 2, 'Room 2.5', 5)
    (6, 2, 'Room 2.6', 5)
    (7, 2, 'Room 2.7', 5)
    (8, 2, 'Room 2.8', 5)
    (9, 2, 'Room 2.9', 5)
    (1, 3, 'Office 3.1', 5)
    (2, 3, 'Office 3.2', 5)
    (3, 3, 'Office 3.3', 5)
    (4, 3, 'Office 3.4', 5)
    (5, 3, 'Office 3.5', 5)
    (1, 1, 'Room 1.1', 6)
    (2, 1, 'Room 1.2', 6)
    (3, 1, 'Room 1.3', 6)
    (4, 1, 'Room 1.4', 6)
    (5, 1, 'Room 1.5', 6)
    (6, 1, 'Room 1.6', 6)
    (7, 1, 'Room 1.7', 6)
    (8, 1, 'Room 1.8', 6)
    (9, 1, 'Room 1.9', 6)
    (1, 2, 'Room 2.1', 6)
    (2, 2, 'Room 2.2', 6)
    (3, 2, 'Room 2.3', 6)
    (4, 2, 'Room 2.4', 6)
    (5, 2, 'Room 2.5', 6)
    (6, 2, 'Room 2.6', 6)
    (7, 2, 'Room 2.7', 6)
    (8, 2, 'Room 2.8', 6)
    (9, 2, 'Room 2.9', 6)
    (1, 3, 'Office 3.1', 6)
    (2, 3, 'Office 3.2', 6)
    (3, 3, 'Office 3.3', 6)
    (4, 3, 'Office 3.4', 6)
    (5, 3, 'Office 3.5', 6)
    (1, 1, 'Room 1.1', 7)
    (2, 1, 'Room 1.2', 7)
    (3, 1, 'Room 1.3', 7)
    (4, 1, 'Room 1.4', 7)
    (5, 1, 'Room 1.5', 7)
    (6, 1, 'Room 1.6', 7)
    (7, 1, 'Room 1.7', 7)
    (8, 1, 'Room 1.8', 7)
    (9, 1, 'Room 1.9', 7)
    (1, 2, 'Room 2.1', 7)
    (2, 2, 'Room 2.2', 7)
    (3, 2, 'Room 2.3', 7)
    (4, 2, 'Room 2.4', 7)
    (5, 2, 'Room 2.5', 7)
    (6, 2, 'Room 2.6', 7)
    (7, 2, 'Room 2.7', 7)
    (8, 2, 'Room 2.8', 7)
    (9, 2, 'Room 2.9', 7)
    (1, 3, 'Office 3.1', 7)
    (2, 3, 'Office 3.2', 7)
    (3, 3, 'Office 3.3', 7)
    (4, 3, 'Office 3.4', 7)
    (5, 3, 'Office 3.5', 7)
    (1, 1, 'Room 1.1', 8)
    (2, 1, 'Room 1.2', 8)
    (3, 1, 'Room 1.3', 8)
    (4, 1, 'Room 1.4', 8)
    (5, 1, 'Room 1.5', 8)
    (6, 1, 'Room 1.6', 8)
    (7, 1, 'Room 1.7', 8)
    (8, 1, 'Room 1.8', 8)
    (9, 1, 'Room 1.9', 8)
    (1, 2, 'Room 2.1', 8)
    (2, 2, 'Room 2.2', 8)
    (3, 2, 'Room 2.3', 8)
    (4, 2, 'Room 2.4', 8)
    (5, 2, 'Room 2.5', 8)
    (6, 2, 'Room 2.6', 8)
    (7, 2, 'Room 2.7', 8)
    (8, 2, 'Room 2.8', 8)
    (9, 2, 'Room 2.9', 8)
    (1, 3, 'Office 3.1', 8)
    (2, 3, 'Office 3.2', 8)
    (3, 3, 'Office 3.3', 8)
    (4, 3, 'Office 3.4', 8)
    (5, 3, 'Office 3.5', 8)
    (1, 1, 'Room 1.1', 9)
    (2, 1, 'Room 1.2', 9)
    (3, 1, 'Room 1.3', 9)
    (4, 1, 'Room 1.4', 9)
    (5, 1, 'Room 1.5', 9)
    (6, 1, 'Room 1.6', 9)
    (7, 1, 'Room 1.7', 9)
    (8, 1, 'Room 1.8', 9)
    (9, 1, 'Room 1.9', 9)
    (1, 2, 'Room 2.1', 9)
    (2, 2, 'Room 2.2', 9)
    (3, 2, 'Room 2.3', 9)
    (4, 2, 'Room 2.4', 9)
    (5, 2, 'Room 2.5', 9)
    (6, 2, 'Room 2.6', 9)
    (7, 2, 'Room 2.7', 9)
    (8, 2, 'Room 2.8', 9)
    (9, 2, 'Room 2.9', 9)
    (1, 3, 'Office 3.1', 9)
    (2, 3, 'Office 3.2', 9)
    (3, 3, 'Office 3.3', 9)
    (4, 3, 'Office 3.4', 9)
    (5, 3, 'Office 3.5', 9)
    (1, 1, 'Room 1.1', 10)
    (2, 1, 'Room 1.2', 10)
    (3, 1, 'Room 1.3', 10)
    (4, 1, 'Room 1.4', 10)
    (5, 1, 'Room 1.5', 10)
    (6, 1, 'Room 1.6', 10)
    (7, 1, 'Room 1.7', 10)
    (8, 1, 'Room 1.8', 10)
    (9, 1, 'Room 1.9', 10)
    (1, 2, 'Room 2.1', 10)
    (2, 2, 'Room 2.2', 10)
    (3, 2, 'Room 2.3', 10)
    (4, 2, 'Room 2.4', 10)
    (5, 2, 'Room 2.5', 10)
    (6, 2, 'Room 2.6', 10)
    (7, 2, 'Room 2.7', 10)
    (8, 2, 'Room 2.8', 10)
    (9, 2, 'Room 2.9', 10)
    (1, 3, 'Office 3.1', 10)
    (2, 3, 'Office 3.2', 10)
    (3, 3, 'Office 3.3', 10)
    (4, 3, 'Office 3.4', 10)
    (5, 3, 'Office 3.5', 10)
    (1, 1, 'Room 1.1', 11)
    (2, 1, 'Room 1.2', 11)
    (3, 1, 'Room 1.3', 11)
    (4, 1, 'Room 1.4', 11)
    (5, 1, 'Room 1.5', 11)
    (6, 1, 'Room 1.6', 11)
    (7, 1, 'Room 1.7', 11)
    (8, 1, 'Room 1.8', 11)
    (9, 1, 'Room 1.9', 11)
    (1, 2, 'Room 2.1', 11)
    (2, 2, 'Room 2.2', 11)
    (3, 2, 'Room 2.3', 11)
    (4, 2, 'Room 2.4', 11)
    (5, 2, 'Room 2.5', 11)
    (6, 2, 'Room 2.6', 11)
    (7, 2, 'Room 2.7', 11)
    (8, 2, 'Room 2.8', 11)
    (9, 2, 'Room 2.9', 11)
    (1, 3, 'Office 3.1', 11)
    (2, 3, 'Office 3.2', 11)
    (3, 3, 'Office 3.3', 11)
    (4, 3, 'Office 3.4', 11)
    (5, 3, 'Office 3.5', 11)
    (1, 1, 'Room 1.1', 12)
    (2, 1, 'Room 1.2', 12)
    (3, 1, 'Room 1.3', 12)
    (4, 1, 'Room 1.4', 12)
    (5, 1, 'Room 1.5', 12)
    (6, 1, 'Room 1.6', 12)
    (7, 1, 'Room 1.7', 12)
    (8, 1, 'Room 1.8', 12)
    (9, 1, 'Room 1.9', 12)
    (1, 2, 'Room 2.1', 12)
    (2, 2, 'Room 2.2', 12)
    (3, 2, 'Room 2.3', 12)
    (4, 2, 'Room 2.4', 12)
    (5, 2, 'Room 2.5', 12)
    (6, 2, 'Room 2.6', 12)
    (7, 2, 'Room 2.7', 12)
    (8, 2, 'Room 2.8', 12)
    (9, 2, 'Room 2.9', 12)
    (1, 3, 'Office 3.1', 12)
    (2, 3, 'Office 3.2', 12)
    (3, 3, 'Office 3.3', 12)
    (4, 3, 'Office 3.4', 12)
    (5, 3, 'Office 3.5', 12)
    (1, 1, 'Room 1.1', 13)
    (2, 1, 'Room 1.2', 13)
    (3, 1, 'Room 1.3', 13)
    (4, 1, 'Room 1.4', 13)
    (5, 1, 'Room 1.5', 13)
    (6, 1, 'Room 1.6', 13)
    (7, 1, 'Room 1.7', 13)
    (8, 1, 'Room 1.8', 13)
    (9, 1, 'Room 1.9', 13)
    (1, 2, 'Room 2.1', 13)
    (2, 2, 'Room 2.2', 13)
    (3, 2, 'Room 2.3', 13)
    (4, 2, 'Room 2.4', 13)
    (5, 2, 'Room 2.5', 13)
    (6, 2, 'Room 2.6', 13)
    (7, 2, 'Room 2.7', 13)
    (8, 2, 'Room 2.8', 13)
    (9, 2, 'Room 2.9', 13)
    (1, 3, 'Office 3.1', 13)
    (2, 3, 'Office 3.2', 13)
    (3, 3, 'Office 3.3', 13)
    (4, 3, 'Office 3.4', 13)
    (5, 3, 'Office 3.5', 13)
    (1, 1, 'Room 1.1', 14)
    (2, 1, 'Room 1.2', 14)
    (3, 1, 'Room 1.3', 14)
    (4, 1, 'Room 1.4', 14)
    (5, 1, 'Room 1.5', 14)
    (6, 1, 'Room 1.6', 14)
    (7, 1, 'Room 1.7', 14)
    (8, 1, 'Room 1.8', 14)
    (9, 1, 'Room 1.9', 14)
    (1, 2, 'Room 2.1', 14)
    (2, 2, 'Room 2.2', 14)
    (3, 2, 'Room 2.3', 14)
    (4, 2, 'Room 2.4', 14)
    (5, 2, 'Room 2.5', 14)
    (6, 2, 'Room 2.6', 14)
    (7, 2, 'Room 2.7', 14)
    (8, 2, 'Room 2.8', 14)
    (9, 2, 'Room 2.9', 14)
    (1, 3, 'Office 3.1', 14)
    (2, 3, 'Office 3.2', 14)
    (3, 3, 'Office 3.3', 14)
    (4, 3, 'Office 3.4', 14)
    (5, 3, 'Office 3.5', 14)
    (1, 1, 'Room 1.1', 15)
    (2, 1, 'Room 1.2', 15)
    (3, 1, 'Room 1.3', 15)
    (4, 1, 'Room 1.4', 15)
    (5, 1, 'Room 1.5', 15)
    (6, 1, 'Room 1.6', 15)
    (7, 1, 'Room 1.7', 15)
    (8, 1, 'Room 1.8', 15)
    (9, 1, 'Room 1.9', 15)
    (1, 2, 'Room 2.1', 15)
    (2, 2, 'Room 2.2', 15)
    (3, 2, 'Room 2.3', 15)
    (4, 2, 'Room 2.4', 15)
    (5, 2, 'Room 2.5', 15)
    (6, 2, 'Room 2.6', 15)
    (7, 2, 'Room 2.7', 15)
    (8, 2, 'Room 2.8', 15)
    (9, 2, 'Room 2.9', 15)
    (1, 3, 'Office 3.1', 15)
    (2, 3, 'Office 3.2', 15)
    (3, 3, 'Office 3.3', 15)
    (4, 3, 'Office 3.4', 15)
    (5, 3, 'Office 3.5', 15)
    (1, 1, 'Room 1.1', 16)
    (2, 1, 'Room 1.2', 16)
    (3, 1, 'Room 1.3', 16)
    (4, 1, 'Room 1.4', 16)
    (5, 1, 'Room 1.5', 16)
    (6, 1, 'Room 1.6', 16)
    (7, 1, 'Room 1.7', 16)
    (8, 1, 'Room 1.8', 16)
    (9, 1, 'Room 1.9', 16)
    (1, 2, 'Room 2.1', 16)
    (2, 2, 'Room 2.2', 16)
    (3, 2, 'Room 2.3', 16)
    (4, 2, 'Room 2.4', 16)
    (5, 2, 'Room 2.5', 16)
    (6, 2, 'Room 2.6', 16)
    (7, 2, 'Room 2.7', 16)
    (8, 2, 'Room 2.8', 16)
    (9, 2, 'Room 2.9', 16)
    (1, 3, 'Office 3.1', 16)
    (2, 3, 'Office 3.2', 16)
    (3, 3, 'Office 3.3', 16)
    (4, 3, 'Office 3.4', 16)
    (5, 3, 'Office 3.5', 16)
    (1, 1, 'Room 1.1', 17)
    (2, 1, 'Room 1.2', 17)
    (3, 1, 'Room 1.3', 17)
    (4, 1, 'Room 1.4', 17)
    (5, 1, 'Room 1.5', 17)
    (6, 1, 'Room 1.6', 17)
    (7, 1, 'Room 1.7', 17)
    (8, 1, 'Room 1.8', 17)
    (9, 1, 'Room 1.9', 17)
    (1, 2, 'Room 2.1', 17)
    (2, 2, 'Room 2.2', 17)
    (3, 2, 'Room 2.3', 17)
    (4, 2, 'Room 2.4', 17)
    (5, 2, 'Room 2.5', 17)
    (6, 2, 'Room 2.6', 17)
    (7, 2, 'Room 2.7', 17)
    (8, 2, 'Room 2.8', 17)
    (9, 2, 'Room 2.9', 17)
    (1, 3, 'Office 3.1', 17)
    (2, 3, 'Office 3.2', 17)
    (3, 3, 'Office 3.3', 17)
    (4, 3, 'Office 3.4', 17)
    (5, 3, 'Office 3.5', 17)
    (1, 1, 'Room 1.1', 18)
    (2, 1, 'Room 1.2', 18)
    (3, 1, 'Room 1.3', 18)
    (4, 1, 'Room 1.4', 18)
    (5, 1, 'Room 1.5', 18)
    (6, 1, 'Room 1.6', 18)
    (7, 1, 'Room 1.7', 18)
    (8, 1, 'Room 1.8', 18)
    (9, 1, 'Room 1.9', 18)
    (1, 2, 'Room 2.1', 18)
    (2, 2, 'Room 2.2', 18)
    (3, 2, 'Room 2.3', 18)
    (4, 2, 'Room 2.4', 18)
    (5, 2, 'Room 2.5', 18)
    (6, 2, 'Room 2.6', 18)
    (7, 2, 'Room 2.7', 18)
    (8, 2, 'Room 2.8', 18)
    (9, 2, 'Room 2.9', 18)
    (1, 3, 'Office 3.1', 18)
    (2, 3, 'Office 3.2', 18)
    (3, 3, 'Office 3.3', 18)
    (4, 3, 'Office 3.4', 18)
    (5, 3, 'Office 3.5', 18)
    (1, 1, 'Room 1.1', 19)
    (2, 1, 'Room 1.2', 19)
    (3, 1, 'Room 1.3', 19)
    (4, 1, 'Room 1.4', 19)
    (5, 1, 'Room 1.5', 19)
    (6, 1, 'Room 1.6', 19)
    (7, 1, 'Room 1.7', 19)
    (8, 1, 'Room 1.8', 19)
    (9, 1, 'Room 1.9', 19)
    (1, 2, 'Room 2.1', 19)
    (2, 2, 'Room 2.2', 19)
    (3, 2, 'Room 2.3', 19)
    (4, 2, 'Room 2.4', 19)
    (5, 2, 'Room 2.5', 19)
    (6, 2, 'Room 2.6', 19)
    (7, 2, 'Room 2.7', 19)
    (8, 2, 'Room 2.8', 19)
    (9, 2, 'Room 2.9', 19)
    (1, 3, 'Office 3.1', 19)
    (2, 3, 'Office 3.2', 19)
    (3, 3, 'Office 3.3', 19)
    (4, 3, 'Office 3.4', 19)
    (5, 3, 'Office 3.5', 19)
    (1, 1, 'Room 1.1', 20)
    (2, 1, 'Room 1.2', 20)
    (3, 1, 'Room 1.3', 20)
    (4, 1, 'Room 1.4', 20)
    (5, 1, 'Room 1.5', 20)
    (6, 1, 'Room 1.6', 20)
    (7, 1, 'Room 1.7', 20)
    (8, 1, 'Room 1.8', 20)
    (9, 1, 'Room 1.9', 20)
    (1, 2, 'Room 2.1', 20)
    (2, 2, 'Room 2.2', 20)
    (3, 2, 'Room 2.3', 20)
    (4, 2, 'Room 2.4', 20)
    (5, 2, 'Room 2.5', 20)
    (6, 2, 'Room 2.6', 20)
    (7, 2, 'Room 2.7', 20)
    (8, 2, 'Room 2.8', 20)
    (9, 2, 'Room 2.9', 20)
    (1, 3, 'Office 3.1', 20)
    (2, 3, 'Office 3.2', 20)
    (3, 3, 'Office 3.3', 20)
    (4, 3, 'Office 3.4', 20)
    (5, 3, 'Office 3.5', 20)
    (1, 1, 'Room 1.1', 21)
    (2, 1, 'Room 1.2', 21)
    (3, 1, 'Room 1.3', 21)
    (4, 1, 'Room 1.4', 21)
    (5, 1, 'Room 1.5', 21)
    (6, 1, 'Room 1.6', 21)
    (7, 1, 'Room 1.7', 21)
    (8, 1, 'Room 1.8', 21)
    (9, 1, 'Room 1.9', 21)
    (1, 2, 'Room 2.1', 21)
    (2, 2, 'Room 2.2', 21)
    (3, 2, 'Room 2.3', 21)
    (4, 2, 'Room 2.4', 21)
    (5, 2, 'Room 2.5', 21)
    (6, 2, 'Room 2.6', 21)
    (7, 2, 'Room 2.7', 21)
    (8, 2, 'Room 2.8', 21)
    (9, 2, 'Room 2.9', 21)
    (1, 3, 'Office 3.1', 21)
    (2, 3, 'Office 3.2', 21)
    (3, 3, 'Office 3.3', 21)
    (4, 3, 'Office 3.4', 21)
    (5, 3, 'Office 3.5', 21)
    (1, 1, 'Room 1.1', 22)
    (2, 1, 'Room 1.2', 22)
    (3, 1, 'Room 1.3', 22)
    (4, 1, 'Room 1.4', 22)
    (5, 1, 'Room 1.5', 22)
    (6, 1, 'Room 1.6', 22)
    (7, 1, 'Room 1.7', 22)
    (8, 1, 'Room 1.8', 22)
    (9, 1, 'Room 1.9', 22)
    (1, 2, 'Room 2.1', 22)
    (2, 2, 'Room 2.2', 22)
    (3, 2, 'Room 2.3', 22)
    (4, 2, 'Room 2.4', 22)
    (5, 2, 'Room 2.5', 22)
    (6, 2, 'Room 2.6', 22)
    (7, 2, 'Room 2.7', 22)
    (8, 2, 'Room 2.8', 22)
    (9, 2, 'Room 2.9', 22)
    (1, 3, 'Office 3.1', 22)
    (2, 3, 'Office 3.2', 22)
    (3, 3, 'Office 3.3', 22)
    (4, 3, 'Office 3.4', 22)
    (5, 3, 'Office 3.5', 22)
    (1, 1, 'Room 1.1', 23)
    (2, 1, 'Room 1.2', 23)
    (3, 1, 'Room 1.3', 23)
    (4, 1, 'Room 1.4', 23)
    (5, 1, 'Room 1.5', 23)
    (6, 1, 'Room 1.6', 23)
    (7, 1, 'Room 1.7', 23)
    (8, 1, 'Room 1.8', 23)
    (9, 1, 'Room 1.9', 23)
    (1, 2, 'Room 2.1', 23)
    (2, 2, 'Room 2.2', 23)
    (3, 2, 'Room 2.3', 23)
    (4, 2, 'Room 2.4', 23)
    (5, 2, 'Room 2.5', 23)
    (6, 2, 'Room 2.6', 23)
    (7, 2, 'Room 2.7', 23)
    (8, 2, 'Room 2.8', 23)
    (9, 2, 'Room 2.9', 23)
    (1, 3, 'Office 3.1', 23)
    (2, 3, 'Office 3.2', 23)
    (3, 3, 'Office 3.3', 23)
    (4, 3, 'Office 3.4', 23)
    (5, 3, 'Office 3.5', 23)
    (1, 1, 'Room 1.1', 24)
    (2, 1, 'Room 1.2', 24)
    (3, 1, 'Room 1.3', 24)
    (4, 1, 'Room 1.4', 24)
    (5, 1, 'Room 1.5', 24)
    (6, 1, 'Room 1.6', 24)
    (7, 1, 'Room 1.7', 24)
    (8, 1, 'Room 1.8', 24)
    (9, 1, 'Room 1.9', 24)
    (1, 2, 'Room 2.1', 24)
    (2, 2, 'Room 2.2', 24)
    (3, 2, 'Room 2.3', 24)
    (4, 2, 'Room 2.4', 24)
    (5, 2, 'Room 2.5', 24)
    (6, 2, 'Room 2.6', 24)
    (7, 2, 'Room 2.7', 24)
    (8, 2, 'Room 2.8', 24)
    (9, 2, 'Room 2.9', 24)
    (1, 3, 'Office 3.1', 24)
    (2, 3, 'Office 3.2', 24)
    (3, 3, 'Office 3.3', 24)
    (4, 3, 'Office 3.4', 24)
    (5, 3, 'Office 3.5', 24)
    (1, 1, 'Room 1.1', 25)
    (2, 1, 'Room 1.2', 25)
    (3, 1, 'Room 1.3', 25)
    (4, 1, 'Room 1.4', 25)
    (5, 1, 'Room 1.5', 25)
    (6, 1, 'Room 1.6', 25)
    (7, 1, 'Room 1.7', 25)
    (8, 1, 'Room 1.8', 25)
    (9, 1, 'Room 1.9', 25)
    (1, 2, 'Room 2.1', 25)
    (2, 2, 'Room 2.2', 25)
    (3, 2, 'Room 2.3', 25)
    (4, 2, 'Room 2.4', 25)
    (5, 2, 'Room 2.5', 25)
    (6, 2, 'Room 2.6', 25)
    (7, 2, 'Room 2.7', 25)
    (8, 2, 'Room 2.8', 25)
    (9, 2, 'Room 2.9', 25)
    (1, 3, 'Office 3.1', 25)
    (2, 3, 'Office 3.2', 25)
    (3, 3, 'Office 3.3', 25)
    (4, 3, 'Office 3.4', 25)
    (5, 3, 'Office 3.5', 25)
    (1, 1, 'Room 1.1', 26)
    (2, 1, 'Room 1.2', 26)
    (3, 1, 'Room 1.3', 26)
    (4, 1, 'Room 1.4', 26)
    (5, 1, 'Room 1.5', 26)
    (6, 1, 'Room 1.6', 26)
    (7, 1, 'Room 1.7', 26)
    (8, 1, 'Room 1.8', 26)
    (9, 1, 'Room 1.9', 26)
    (1, 2, 'Room 2.1', 26)
    (2, 2, 'Room 2.2', 26)
    (3, 2, 'Room 2.3', 26)
    (4, 2, 'Room 2.4', 26)
    (5, 2, 'Room 2.5', 26)
    (6, 2, 'Room 2.6', 26)
    (7, 2, 'Room 2.7', 26)
    (8, 2, 'Room 2.8', 26)
    (9, 2, 'Room 2.9', 26)
    (1, 3, 'Office 3.1', 26)
    (2, 3, 'Office 3.2', 26)
    (3, 3, 'Office 3.3', 26)
    (4, 3, 'Office 3.4', 26)
    (5, 3, 'Office 3.5', 26)
    (1, 1, 'Room 1.1', 27)
    (2, 1, 'Room 1.2', 27)
    (3, 1, 'Room 1.3', 27)
    (4, 1, 'Room 1.4', 27)
    (5, 1, 'Room 1.5', 27)
    (6, 1, 'Room 1.6', 27)
    (7, 1, 'Room 1.7', 27)
    (8, 1, 'Room 1.8', 27)
    (9, 1, 'Room 1.9', 27)
    (1, 2, 'Room 2.1', 27)
    (2, 2, 'Room 2.2', 27)
    (3, 2, 'Room 2.3', 27)
    (4, 2, 'Room 2.4', 27)
    (5, 2, 'Room 2.5', 27)
    (6, 2, 'Room 2.6', 27)
    (7, 2, 'Room 2.7', 27)
    (8, 2, 'Room 2.8', 27)
    (9, 2, 'Room 2.9', 27)
    (1, 3, 'Office 3.1', 27)
    (2, 3, 'Office 3.2', 27)
    (3, 3, 'Office 3.3', 27)
    (4, 3, 'Office 3.4', 27)
    (5, 3, 'Office 3.5', 27)
    (1, 1, 'Room 1.1', 28)
    (2, 1, 'Room 1.2', 28)
    (3, 1, 'Room 1.3', 28)
    (4, 1, 'Room 1.4', 28)
    (5, 1, 'Room 1.5', 28)
    (6, 1, 'Room 1.6', 28)
    (7, 1, 'Room 1.7', 28)
    (8, 1, 'Room 1.8', 28)
    (9, 1, 'Room 1.9', 28)
    (1, 2, 'Room 2.1', 28)
    (2, 2, 'Room 2.2', 28)
    (3, 2, 'Room 2.3', 28)
    (4, 2, 'Room 2.4', 28)
    (5, 2, 'Room 2.5', 28)
    (6, 2, 'Room 2.6', 28)
    (7, 2, 'Room 2.7', 28)
    (8, 2, 'Room 2.8', 28)
    (9, 2, 'Room 2.9', 28)
    (1, 3, 'Office 3.1', 28)
    (2, 3, 'Office 3.2', 28)
    (3, 3, 'Office 3.3', 28)
    (4, 3, 'Office 3.4', 28)
    (5, 3, 'Office 3.5', 28)
    (1, 1, 'Room 1.1', 29)
    (2, 1, 'Room 1.2', 29)
    (3, 1, 'Room 1.3', 29)
    (4, 1, 'Room 1.4', 29)
    (5, 1, 'Room 1.5', 29)
    (6, 1, 'Room 1.6', 29)
    (7, 1, 'Room 1.7', 29)
    (8, 1, 'Room 1.8', 29)
    (9, 1, 'Room 1.9', 29)
    (1, 2, 'Room 2.1', 29)
    (2, 2, 'Room 2.2', 29)
    (3, 2, 'Room 2.3', 29)
    (4, 2, 'Room 2.4', 29)
    (5, 2, 'Room 2.5', 29)
    (6, 2, 'Room 2.6', 29)
    (7, 2, 'Room 2.7', 29)
    (8, 2, 'Room 2.8', 29)
    (9, 2, 'Room 2.9', 29)
    (1, 3, 'Office 3.1', 29)
    (2, 3, 'Office 3.2', 29)
    (3, 3, 'Office 3.3', 29)
    (4, 3, 'Office 3.4', 29)
    (5, 3, 'Office 3.5', 29)
    (1, 1, 'Room 1.1', 30)
    (2, 1, 'Room 1.2', 30)
    (3, 1, 'Room 1.3', 30)
    (4, 1, 'Room 1.4', 30)
    (5, 1, 'Room 1.5', 30)
    (6, 1, 'Room 1.6', 30)
    (7, 1, 'Room 1.7', 30)
    (8, 1, 'Room 1.8', 30)
    (9, 1, 'Room 1.9', 30)
    (1, 2, 'Room 2.1', 30)
    (2, 2, 'Room 2.2', 30)
    (3, 2, 'Room 2.3', 30)
    (4, 2, 'Room 2.4', 30)
    (5, 2, 'Room 2.5', 30)
    (6, 2, 'Room 2.6', 30)
    (7, 2, 'Room 2.7', 30)
    (8, 2, 'Room 2.8', 30)
    (9, 2, 'Room 2.9', 30)
    (1, 3, 'Office 3.1', 30)
    (2, 3, 'Office 3.2', 30)
    (3, 3, 'Office 3.3', 30)
    (4, 3, 'Office 3.4', 30)
    (5, 3, 'Office 3.5', 30)
    (1, 1, 'Room 1.1', 31)
    (2, 1, 'Room 1.2', 31)
    (3, 1, 'Room 1.3', 31)
    (4, 1, 'Room 1.4', 31)
    (5, 1, 'Room 1.5', 31)
    (6, 1, 'Room 1.6', 31)
    (7, 1, 'Room 1.7', 31)
    (8, 1, 'Room 1.8', 31)
    (9, 1, 'Room 1.9', 31)
    (1, 2, 'Room 2.1', 31)
    (2, 2, 'Room 2.2', 31)
    (3, 2, 'Room 2.3', 31)
    (4, 2, 'Room 2.4', 31)
    (5, 2, 'Room 2.5', 31)
    (6, 2, 'Room 2.6', 31)
    (7, 2, 'Room 2.7', 31)
    (8, 2, 'Room 2.8', 31)
    (9, 2, 'Room 2.9', 31)
    (1, 3, 'Office 3.1', 31)
    (2, 3, 'Office 3.2', 31)
    (3, 3, 'Office 3.3', 31)
    (4, 3, 'Office 3.4', 31)
    (5, 3, 'Office 3.5', 31)
    (1, 1, 'Room 1.1', 32)
    (2, 1, 'Room 1.2', 32)
    (3, 1, 'Room 1.3', 32)
    (4, 1, 'Room 1.4', 32)
    (5, 1, 'Room 1.5', 32)
    (6, 1, 'Room 1.6', 32)
    (7, 1, 'Room 1.7', 32)
    (8, 1, 'Room 1.8', 32)
    (9, 1, 'Room 1.9', 32)
    (1, 2, 'Room 2.1', 32)
    (2, 2, 'Room 2.2', 32)
    (3, 2, 'Room 2.3', 32)
    (4, 2, 'Room 2.4', 32)
    (5, 2, 'Room 2.5', 32)
    (6, 2, 'Room 2.6', 32)
    (7, 2, 'Room 2.7', 32)
    (8, 2, 'Room 2.8', 32)
    (9, 2, 'Room 2.9', 32)
    (1, 3, 'Office 3.1', 32)
    (2, 3, 'Office 3.2', 32)
    (3, 3, 'Office 3.3', 32)
    (4, 3, 'Office 3.4', 32)
    (5, 3, 'Office 3.5', 32)
    (1, 1, 'Room 1.1', 33)
    (2, 1, 'Room 1.2', 33)
    (3, 1, 'Room 1.3', 33)
    (4, 1, 'Room 1.4', 33)
    (5, 1, 'Room 1.5', 33)
    (6, 1, 'Room 1.6', 33)
    (7, 1, 'Room 1.7', 33)
    (8, 1, 'Room 1.8', 33)
    (9, 1, 'Room 1.9', 33)
    (1, 2, 'Room 2.1', 33)
    (2, 2, 'Room 2.2', 33)
    (3, 2, 'Room 2.3', 33)
    (4, 2, 'Room 2.4', 33)
    (5, 2, 'Room 2.5', 33)
    (6, 2, 'Room 2.6', 33)
    (7, 2, 'Room 2.7', 33)
    (8, 2, 'Room 2.8', 33)
    (9, 2, 'Room 2.9', 33)
    (1, 3, 'Office 3.1', 33)
    (2, 3, 'Office 3.2', 33)
    (3, 3, 'Office 3.3', 33)
    (4, 3, 'Office 3.4', 33)
    (5, 3, 'Office 3.5', 33)
    (1, 1, 'Room 1.1', 34)
    (2, 1, 'Room 1.2', 34)
    (3, 1, 'Room 1.3', 34)
    (4, 1, 'Room 1.4', 34)
    (5, 1, 'Room 1.5', 34)
    (6, 1, 'Room 1.6', 34)
    (7, 1, 'Room 1.7', 34)
    (8, 1, 'Room 1.8', 34)
    (9, 1, 'Room 1.9', 34)
    (1, 2, 'Room 2.1', 34)
    (2, 2, 'Room 2.2', 34)
    (3, 2, 'Room 2.3', 34)
    (4, 2, 'Room 2.4', 34)
    (5, 2, 'Room 2.5', 34)
    (6, 2, 'Room 2.6', 34)
    (7, 2, 'Room 2.7', 34)
    (8, 2, 'Room 2.8', 34)
    (9, 2, 'Room 2.9', 34)
    (1, 3, 'Office 3.1', 34)
    (2, 3, 'Office 3.2', 34)
    (3, 3, 'Office 3.3', 34)
    (4, 3, 'Office 3.4', 34)
    (5, 3, 'Office 3.5', 34)
    (1, 1, 'Room 1.1', 35)
    (2, 1, 'Room 1.2', 35)
    (3, 1, 'Room 1.3', 35)
    (4, 1, 'Room 1.4', 35)
    (5, 1, 'Room 1.5', 35)
    (6, 1, 'Room 1.6', 35)
    (7, 1, 'Room 1.7', 35)
    (8, 1, 'Room 1.8', 35)
    (9, 1, 'Room 1.9', 35)
    (1, 2, 'Room 2.1', 35)
    (2, 2, 'Room 2.2', 35)
    (3, 2, 'Room 2.3', 35)
    (4, 2, 'Room 2.4', 35)
    (5, 2, 'Room 2.5', 35)
    (6, 2, 'Room 2.6', 35)
    (7, 2, 'Room 2.7', 35)
    (8, 2, 'Room 2.8', 35)
    (9, 2, 'Room 2.9', 35)
    (1, 3, 'Office 3.1', 35)
    (2, 3, 'Office 3.2', 35)
    (3, 3, 'Office 3.3', 35)
    (4, 3, 'Office 3.4', 35)
    (5, 3, 'Office 3.5', 35)
    (1, 1, 'Room 1.1', 36)
    (2, 1, 'Room 1.2', 36)
    (3, 1, 'Room 1.3', 36)
    (4, 1, 'Room 1.4', 36)
    (5, 1, 'Room 1.5', 36)
    (6, 1, 'Room 1.6', 36)
    (7, 1, 'Room 1.7', 36)
    (8, 1, 'Room 1.8', 36)
    (9, 1, 'Room 1.9', 36)
    (1, 2, 'Room 2.1', 36)
    (2, 2, 'Room 2.2', 36)
    (3, 2, 'Room 2.3', 36)
    (4, 2, 'Room 2.4', 36)
    (5, 2, 'Room 2.5', 36)
    (6, 2, 'Room 2.6', 36)
    (7, 2, 'Room 2.7', 36)
    (8, 2, 'Room 2.8', 36)
    (9, 2, 'Room 2.9', 36)
    (1, 3, 'Office 3.1', 36)
    (2, 3, 'Office 3.2', 36)
    (3, 3, 'Office 3.3', 36)
    (4, 3, 'Office 3.4', 36)
    (5, 3, 'Office 3.5', 36)
    (1, 1, 'Room 1.1', 37)
    (2, 1, 'Room 1.2', 37)
    (3, 1, 'Room 1.3', 37)
    (4, 1, 'Room 1.4', 37)
    (5, 1, 'Room 1.5', 37)
    (6, 1, 'Room 1.6', 37)
    (7, 1, 'Room 1.7', 37)
    (8, 1, 'Room 1.8', 37)
    (9, 1, 'Room 1.9', 37)
    (1, 2, 'Room 2.1', 37)
    (2, 2, 'Room 2.2', 37)
    (3, 2, 'Room 2.3', 37)
    (4, 2, 'Room 2.4', 37)
    (5, 2, 'Room 2.5', 37)
    (6, 2, 'Room 2.6', 37)
    (7, 2, 'Room 2.7', 37)
    (8, 2, 'Room 2.8', 37)
    (9, 2, 'Room 2.9', 37)
    (1, 3, 'Office 3.1', 37)
    (2, 3, 'Office 3.2', 37)
    (3, 3, 'Office 3.3', 37)
    (4, 3, 'Office 3.4', 37)
    (5, 3, 'Office 3.5', 37)
    (1, 1, 'Room 1.1', 38)
    (2, 1, 'Room 1.2', 38)
    (3, 1, 'Room 1.3', 38)
    (4, 1, 'Room 1.4', 38)
    (5, 1, 'Room 1.5', 38)
    (6, 1, 'Room 1.6', 38)
    (7, 1, 'Room 1.7', 38)
    (8, 1, 'Room 1.8', 38)
    (9, 1, 'Room 1.9', 38)
    (1, 2, 'Room 2.1', 38)
    (2, 2, 'Room 2.2', 38)
    (3, 2, 'Room 2.3', 38)
    (4, 2, 'Room 2.4', 38)
    (5, 2, 'Room 2.5', 38)
    (6, 2, 'Room 2.6', 38)
    (7, 2, 'Room 2.7', 38)
    (8, 2, 'Room 2.8', 38)
    (9, 2, 'Room 2.9', 38)
    (1, 3, 'Office 3.1', 38)
    (2, 3, 'Office 3.2', 38)
    (3, 3, 'Office 3.3', 38)
    (4, 3, 'Office 3.4', 38)
    (5, 3, 'Office 3.5', 38)
    (1, 1, 'Room 1.1', 39)
    (2, 1, 'Room 1.2', 39)
    (3, 1, 'Room 1.3', 39)
    (4, 1, 'Room 1.4', 39)
    (5, 1, 'Room 1.5', 39)
    (6, 1, 'Room 1.6', 39)
    (7, 1, 'Room 1.7', 39)
    (8, 1, 'Room 1.8', 39)
    (9, 1, 'Room 1.9', 39)
    (1, 2, 'Room 2.1', 39)
    (2, 2, 'Room 2.2', 39)
    (3, 2, 'Room 2.3', 39)
    (4, 2, 'Room 2.4', 39)
    (5, 2, 'Room 2.5', 39)
    (6, 2, 'Room 2.6', 39)
    (7, 2, 'Room 2.7', 39)
    (8, 2, 'Room 2.8', 39)
    (9, 2, 'Room 2.9', 39)
    (1, 3, 'Office 3.1', 39)
    (2, 3, 'Office 3.2', 39)
    (3, 3, 'Office 3.3', 39)
    (4, 3, 'Office 3.4', 39)
    (5, 3, 'Office 3.5', 39)
    (1, 1, 'Room 1.1', 40)
    (2, 1, 'Room 1.2', 40)
    (3, 1, 'Room 1.3', 40)
    (4, 1, 'Room 1.4', 40)
    (5, 1, 'Room 1.5', 40)
    (6, 1, 'Room 1.6', 40)
    (7, 1, 'Room 1.7', 40)
    (8, 1, 'Room 1.8', 40)
    (9, 1, 'Room 1.9', 40)
    (1, 2, 'Room 2.1', 40)
    (2, 2, 'Room 2.2', 40)
    (3, 2, 'Room 2.3', 40)
    (4, 2, 'Room 2.4', 40)
    (5, 2, 'Room 2.5', 40)
    (6, 2, 'Room 2.6', 40)
    (7, 2, 'Room 2.7', 40)
    (8, 2, 'Room 2.8', 40)
    (9, 2, 'Room 2.9', 40)
    (1, 3, 'Office 3.1', 40)
    (2, 3, 'Office 3.2', 40)
    (3, 3, 'Office 3.3', 40)
    (4, 3, 'Office 3.4', 40)
    (5, 3, 'Office 3.5', 40)


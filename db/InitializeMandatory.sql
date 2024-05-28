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

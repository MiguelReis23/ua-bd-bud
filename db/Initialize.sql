-- CREATE USER ROLES

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

GO

-- CREATE USERS
EXECUTE CreateUser 'João Almeida Santos', 'jas@ua.pt', NULL, 'jas123'
EXECUTE CreateUser 'Maria João Silva', 'mjs@ua.pt', NULL, 'mjs123'
EXECUTE CreateUser 'José Manuel', 'jm@ua.pt', NULL, 'jm123'
EXECUTE CreateUser 'Carlos Guilherme Penedo', 'cgp@ua.pt', NULL, 'cgp123'
GO


EXECUTE AssociateUserToRole @email = 'jas@ua.pt', @role = 'Student', @nmec = 12345
EXECUTE AssociateUserToRole @user_id = 2, @role = 'Teacher', @nmec = 54321
EXECUTE AssociateUserToRole @email = 'jm@ua.pt', @role = 'Administator', @nmec = 67890
EXECUTE AssociateUserToRole @user_id = 4, @role = 'Nao Existe', @nmec = 98765
GO

EXECUTE AssociateUserToRole @user_id = 4, @role = 'Staff', @nmec = 98765, @begin_date = '2021-01-01'
GO




DELETE FROM BUD.[user]
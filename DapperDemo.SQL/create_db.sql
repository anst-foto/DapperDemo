-- *** *** *** TABLES *** *** ***
CREATE TABLE table_roles(
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE table_accounts (
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    login TEXT NOT NULL,
    password TEXT NOT NULL,
    role_id INTEGER NOT NULL,
    is_active INTEGER NOT NULL DEFAULT 1,
    FOREIGN KEY (role_id) REFERENCES table_roles(id) 
        ON UPDATE NO ACTION 
        ON UPDATE NO ACTION
);

CREATE TABLE table_users (
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    email TEXT NOT NULL,
    FOREIGN KEY (id) REFERENCES table_accounts(id) 
        ON UPDATE NO ACTION
        ON DELETE NO ACTION 
);
-- ///|||\\\|||///|||\\\

-- *** *** *** VIEWS *** *** ***
CREATE VIEW view_accounts AS
SELECT table_accounts.id AS 'id',
       last_name, first_name,
       login, password,
       email, is_active
FROM table_accounts
JOIN table_roles 
    ON table_accounts.role_id = table_roles.id
JOIN table_users 
    ON table_accounts.id = table_users.id;
-- ///|||\\\|||///|||\\\

-- *** *** *** TEST DATA *** *** ***
INSERT INTO table_roles(name) VALUES ('admin');
INSERT INTO table_roles(name) VALUES ('user');

INSERT INTO table_accounts(login, password, role_id) 
VALUES ('admin', '12345', (SELECT id FROM table_roles WHERE name = 'admin'));
INSERT INTO table_accounts(login, password, role_id, is_active)
VALUES ('adm', '12345', (SELECT id FROM table_roles WHERE name = 'admin'), 0);
INSERT INTO table_accounts(login, password, role_id)
VALUES ('user', '12345', (SELECT id FROM table_roles WHERE name = 'user'));
INSERT INTO table_accounts(login, password, role_id, is_active)
VALUES ('usr', '12345', (SELECT id FROM table_roles WHERE name = 'user'), 0);

INSERT INTO table_users(first_name, last_name, email)
VALUES ('Admin', 'Administrator', 'admin@company.net');
INSERT INTO table_users(first_name, last_name, email)
VALUES ('Admin', 'Administrator', 'admin@company.net');
INSERT INTO table_users(first_name, last_name, email)
VALUES ('User01', 'User', 'user01@company.net');
INSERT INTO table_users(first_name, last_name, email)
VALUES ('User00', 'User', 'user00@company.net');
-- ///|||\\\|||///|||\\\
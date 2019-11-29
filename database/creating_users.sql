CREATE USER 'adminuser'@'localhost' IDENTIFIED BY 'MyPassword1';
GRANT ALL PRIVILEGES ON *.* TO 'adminuser'@'localhost' WITH GRANT OPTION;
CREATE USER 'adminuser'@'%' IDENTIFIED BY 'MyPassword1';
GRANT ALL PRIVILEGES ON *.* TO 'adminuser'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

CREATE USER 'normaluser'@'localhost' IDENTIFIED BY 'MyPassword1';
CREATE USER 'normaluser'@'%' IDENTIFIED BY 'MyPassword1';
FLUSH PRIVILEGES;

GRANT SELECT ON *.* TO 'normaluser'@'localhost';
GRANT SELECT ON *.* TO 'normaluser'@'%';
FLUSH PRIVILEGES;

REVOKE SELECT ON mfdb.user FROM 'normaluser'@'localhost';
REVOKE SELECT ON mfdb.user FROM 'normaluser'@'%';
FLUSH PRIVILEGES;

GRANT INSERT (email, password, username, name, surname, street, house_nr) ON mfdb.user TO 'normaluser'@'localhost';
GRANT INSERT(email, password, username, name, surname, street, house_nr) ON mfdb.user TO  'normaluser'@'%';
FLUSH PRIVILEGES;

GRANT UPDATE (email, password, username, name, surname, street, house_nr) ON mfdb.user TO 'normaluser'@'localhost';
GRANT UPDATE (email, password, username, name, surname, street, house_nr) ON mfdb.user TO 'normaluser'@'%';
FLUSH PRIVILEGES;
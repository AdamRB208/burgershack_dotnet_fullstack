CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE burgers (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name TINYTEXT NOT NULL,
    price DECIMAL(19, 2) NOT NULL
) DEFAULT CHARSET utf8mb4;

DROP TABLE burgers;

INSERT INTO
    burgers (name, price)
VALUES ('Cheese Burger', 5.00),
    ('Bacon Cheese Burger', 7.00),
    ('Hamburger', 4.50),
    ('Double Cheese Burger', 7.50);

DELETE FROM burgers WHERE id = 1;

SELECT * FROM burgers;

SELECT * FROM burgers WHERE id = 1;

CREATE TABLE sides (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name TINYTEXT NOT NULL,
    price DECIMAL(19, 2) NOT NULL
) DEFAULT CHARSET utf8mb4;

INSERT INTO
    sides (name, price)
VALUES ('Fries', 2.00),
    ('Tots', 2.00),
    ('Curly Fries', 2.00),
    ('Sweet Potato Fries', 3.00);

DROP TABLE sides;
ALTER TABLE burgers
ADD COLUMN imgUrl VARCHAR(255) NOT NULL DEFAULT(
    'https://images.unsplash.com/photo-1571091718767-18b5b1457add?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGJ1cmdlcnN8ZW58MHx8MHx8fDI%3D'
) AFTER price;

ALTER TABLE burgers
ADD COLUMN imgUrl VARCHAR(255) NOT NULL DEFAULT(
    'https://images.unsplash.com/photo-1571091718767-18b5b1457add?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGJ1cmdlcnN8ZW58MHx8MHx8fDI%3D'
) AFTER price;

ALTER TABLE sides
ADD COLUMN imgUrl VARCHAR(255) NOT NULL DEFAULT(
    'https://images.unsplash.com/photo-1736826201130-c8a3d4e1427c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDd8fGZyaWVzfGVufDB8MHwwfHx8Mg%3D%3D'
) AFTER price;

ALTER TABLE sides
ADD COLUMN imgUrl VARCHAR(255) NOT NULL AFTER price;

ALTER TABLE burgers DROP COLUMN imgUrl;

ALTER TABLE sides DROP COLUMN imgUrl;

UPDATE burgers SET name = @Name, price = @Price WHERE id = @Id;

SELECT * FROM burgers WHERE id = @Id;

-- Img for loaded fries
-- https://images.unsplash.com/photo-1641848462100-a83532dbece5?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGRpZmZlcmVudCUyMGtpbmRzJTIwb2YlMjBmcmllc3xlbnwwfHwwfHx8Mg%3D%3D

CREATE DATABASE IF NOT EXISTS APIFinalProject;
USE APIFinalProject;

DROP TABLE IF EXISTS Post;
DROP TABLE IF EXISTS User;

CREATE TABLE User(
	UserId INT NOT NULL auto_increment,
    UserName VARCHAR(255) NOT NULL UNIQUE,
    Email VARCHAR(255) NOT NULL UNIQUE,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Bio VARCHAR(255),
    City VARCHAR(255),
    Education VARCHAR(255),
    ImgUrl VARCHAR(255),
    PRIMARY KEY (UserId, UserName, Email)
);

CREATE TABLE Post(
	PostId INT NOT NULL auto_increment,
    UserId INT NOT NULL,
    UserName VARCHAR(255) NOT NULL,
    PostDescription TEXT NOT NULL,
    CreatedAt DATETIME,
    PRIMARY KEY (PostId),
    FOREIGN KEY (UserId, UserName) REFERENCES user(UserId, UserName)
);

INSERT INTO User(UserName, Email, FirstName, LastName) VALUES
('Tommy133', 'tommytest@gmail.com', 'Tommy', 'Liang'),
('Bob', 'bob123@gmail.com', 'Bob', 'Last');

SELECT * FROM User;
 
INSERT INTO Post(UserId, UserName, PostDescription, CreatedAt) VALUES
(1, 'Tommy133', 'test text for Tommy', concat(CURDATE(), ' ', CURTIME())),
(2, 'Bob', 'test text for Bob', concat(CURDATE(), ' ', CURTIME()));

SELECT * FROM Post;
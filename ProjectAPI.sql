DROP DATABASE IF EXISTS APIFinalProject;
CREATE DATABASE APIFinalProject;
USE APIFinalProject;

CREATE TABLE User(
	UserId INT NOT NULL auto_increment,
    UserName VARCHAR(255) NOT NULL UNIQUE,
    Email VARCHAR(255) NOT NULL UNIQUE,
    PRIMARY KEY (UserId, UserName, Email)
);

CREATE TABLE UserInfo(
	UserInfoId INT NOT NULL auto_increment,
	UserId INT NOT NULL,
    Age INT NOT NULL,
    Bio VARCHAR(255),
    Location VARCHAR(255),
    Education VARCHAR(255),
    PRIMARY KEY(UserInfoId),
    FOREIGN KEY(UserId) REFERENCES User(UserId) ON DELETE CASCADE
);

CREATE TABLE Post(
	PostId INT NOT NULL auto_increment,
    UserId INT NOT NULL,
    UserName VARCHAR(255) NOT NULL,
    PostDescription TEXT NOT NULL,
    CreatedAt DATETIME,
    PRIMARY KEY (PostId),
    FOREIGN KEY (UserId, UserName) REFERENCES user(UserId, UserName) ON DELETE CASCADE
);

INSERT INTO User(UserName, Email) VALUES
('Tommy133', 'tommytest@gmail.com'),
('Bob', 'bob123@gmail.com');

SELECT * FROM User;

INSERT INTO UserInfo(UserId, Age, Bio, Location, Education) VALUES
(1, 20, "Hello World", "New York", "Hunter College"),
(2, 18, "Life is ---", "Boston", "Krusty Krabs");
 
 SELECT * FROM UserInfo;
 
INSERT INTO Post(UserId, UserName, PostDescription, CreatedAt) VALUES
(1, 'Tommy133', 'test text for Tommy', concat(CURDATE(), ' ', CURTIME())),
(2, 'Bob', 'test text for Bob', concat(CURDATE(), ' ', CURTIME()));

SELECT * FROM Post;
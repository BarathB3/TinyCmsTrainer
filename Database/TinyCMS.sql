IF DB_ID('TinyCMS') IS NULL
    CREATE DATABASE TinyCMS;
GO

USE TinyCMS;
GO


IF OBJECT_ID('Roles') IS NOT NULL DROP TABLE Roles;
CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);


IF OBJECT_ID('Users') IS NOT NULL DROP TABLE Users;
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(150),
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);


IF OBJECT_ID('Pages') IS NOT NULL DROP TABLE Pages;
CREATE TABLE Pages (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Slug NVARCHAR(200) NOT NULL UNIQUE,
    Content NVARCHAR(MAX),
    IsPublished BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME,
    AuthorId INT,
    FOREIGN KEY (AuthorId) REFERENCES Users(Id)
);


IF OBJECT_ID('Posts') IS NOT NULL DROP TABLE Posts;
CREATE TABLE Posts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Slug NVARCHAR(200) NOT NULL UNIQUE,
    Excerpt NVARCHAR(500),
    Content NVARCHAR(MAX),
    ImageUrl NVARCHAR(255),
    PublishedAt DATETIME,
    IsPublished BIT NOT NULL DEFAULT 0,
    AuthorId INT,
    FOREIGN KEY (AuthorId) REFERENCES Users(Id)
);

IF OBJECT_ID('MediaLibrary') IS NOT NULL DROP TABLE MediaLibrary;
CREATE TABLE MediaLibrary (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    UploadedAt DATETIME DEFAULT GETDATE(),
    UploadedBy INT,
    FOREIGN KEY (UploadedBy) REFERENCES Users(Id)
);


IF OBJECT_ID('Contacts') IS NOT NULL DROP TABLE Contacts;
CREATE TABLE Contacts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(150),
    Message NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);


IF OBJECT_ID('ScheduledPosts') IS NOT NULL DROP TABLE ScheduledPosts;
CREATE TABLE ScheduledPosts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT NOT NULL,
    ScheduledFor DATETIME NOT NULL,
    FOREIGN KEY (PostId) REFERENCES Posts(Id)
);


IF OBJECT_ID('Settings') IS NOT NULL DROP TABLE Settings;
CREATE TABLE Settings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SettingKey NVARCHAR(100) UNIQUE,
    SettingValue NVARCHAR(255)
);


INSERT INTO Settings (SettingKey, SettingValue)
VALUES ('theme', 'light');


INSERT INTO Roles (RoleName) VALUES ('Editor'), ('Author');

INSERT INTO Users (Username, PasswordHash, Email, RoleId)
VALUES 
('editor1', 'hashed_password_here', 'editor@example.com', 1),
('author1', 'hashed_password_here', 'author@example.com', 2);


INSERT INTO Pages (Title, Slug, Content, IsPublished, AuthorId)
VALUES 
('Rólam', 'rolam', '<p>Bemutatkozás tartalma...</p>', 1, 1);

INSERT INTO Posts (Title, Slug, Excerpt, Content, IsPublished, AuthorId)
VALUES 
('5 tipp kezdő futóknak', '5-tipp-kezdoknek', 'Tippek kezdőknek…', 
 '<p>Teljes bejegyzés tartalma...</p>', 1, 2);

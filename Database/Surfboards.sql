CREATE TABLE Surfboards (
    SurfboardId INT          IDENTITY(1,1) NOT NULL,
    UserId      INT                        NOT NULL,
    Name        VARCHAR(100)               NOT NULL,

    CONSTRAINT PK_Surfboards       PRIMARY KEY (SurfboardId),
    CONSTRAINT FK_Surfboards_Users FOREIGN KEY (UserId) REFERENCES Users (UserId)
);

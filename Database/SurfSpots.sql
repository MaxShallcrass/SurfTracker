CREATE TABLE SurfSpots (
    SurfSpotId INT          IDENTITY(1,1) NOT NULL,
    UserId     INT                        NOT NULL,
    Name       VARCHAR(100)               NOT NULL,
    Latitude   DECIMAL(9,6)               NOT NULL,
    Longitude  DECIMAL(9,6)               NOT NULL,

    CONSTRAINT PK_SurfSpots       PRIMARY KEY (SurfSpotId),
    CONSTRAINT FK_SurfSpots_Users FOREIGN KEY (UserId) REFERENCES Users (UserId)
);

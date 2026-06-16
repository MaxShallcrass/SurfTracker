CREATE TABLE SurfSessions (
    SurfSessionId INT       IDENTITY(1,1) NOT NULL,
    UserId        INT                     NOT NULL,
    StartTime     DATETIME2               NOT NULL,
    EndTime       DATETIME2               NOT NULL,
    SurfboardId   INT                     NOT NULL,
    SurfSpotId    INT                     NOT NULL,
    CreatedAt     DATETIME2               NOT NULL DEFAULT GETUTCDATE(),

    CONSTRAINT PK_SurfSessions            PRIMARY KEY (SurfSessionId),
    CONSTRAINT FK_SurfSessions_Users      FOREIGN KEY (UserId)      REFERENCES Users      (UserId),
    CONSTRAINT FK_SurfSessions_Surfboards FOREIGN KEY (SurfboardId) REFERENCES Surfboards (SurfboardId),
    CONSTRAINT FK_SurfSessions_SurfSpots  FOREIGN KEY (SurfSpotId)  REFERENCES SurfSpots  (SurfSpotId)
);

CREATE TABLE SurfSessionUserObservations (
    SurfSessionUserObservationId INT          IDENTITY(1,1) NOT NULL,
    SurfSessionId                INT                        NOT NULL,
    Notes                        VARCHAR(2000)              NULL,

    CONSTRAINT PK_SurfSessionUserObservations              PRIMARY KEY (SurfSessionUserObservationId),
    CONSTRAINT FK_SurfSessionUserObservations_SurfSessions FOREIGN KEY (SurfSessionId) REFERENCES SurfSessions (SurfSessionId)
);

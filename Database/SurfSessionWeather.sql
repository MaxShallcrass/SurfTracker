CREATE TABLE SurfSessionWeather (
    SurfSessionWeatherId INT          IDENTITY(1,1) NOT NULL,
    SurfSessionId        INT                        NOT NULL,
    [Time]               DATETIME2                  NOT NULL,
    Temperature2m        DECIMAL(5,2)               NULL,
    WeatherCode          INT                        NULL,
    CloudCover           INT                        NULL,
    WindSpeed10m         DECIMAL(5,2)               NULL,
    WindDirection10m     INT                        NULL,
    UvIndex              DECIMAL(5,2)               NULL,
    Precipitation        DECIMAL(5,2)               NULL,

    CONSTRAINT PK_SurfSessionWeather              PRIMARY KEY (SurfSessionWeatherId),
    CONSTRAINT FK_SurfSessionWeather_SurfSessions FOREIGN KEY (SurfSessionId) REFERENCES SurfSessions (SurfSessionId),
    CONSTRAINT UQ_SurfSessionWeather_SessionTime  UNIQUE      (SurfSessionId, [Time])
);

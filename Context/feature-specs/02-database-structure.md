# Feature Spec: Database

I would like to define the tables to be used in the folder 'Database'

The Users table already exists.

And we will be now adding the tables SurfSpots, Surfboards, SurfSessions, SessionSwell.

To define the tables:

Users:
UserId (Int) [Primary Key]
CognitoId (NVARCHAR(128) ) [NOT NULL] 
CreatedAt (DATETIME2) [NOT NULL DEFAULT GETUTCDATE()]


SurfSpots:
SurfSpotId (Int) [Primary Key]
Name VarChar(100) [Not Null]
Latitude (DECIMAL(9,6)) [Not Null]
Longitude (DECIMAL(9,6)) [Not Null]

Surfboards:
SurfBoardId (Int) [Primary Key]
Name VarChar(100) [Not Null]

SurfSessions
SurfSessionId (Int) [Primary Key]
UserId (Int) [NOT NULL] [References Users table]
StartTime (DATETIME2) [NOT NULL]
EndTime (DATETIME2) [NOT NULL]
SurfboardId (Int) [NOT NULL] [References Surfboards table]
SurfSpotId (Int) [NOT NULL] [References SurfSpots table]
CreatedAt (DATETIME2) [NOT NULL DEFAULT GETUTCDATE()]

SurfSessionUserObservations:
SurfSessionUserObservationId (Int) [Primary Key]
SurfSessionId (Int) [NOT NULL] [References SurfSessions table]
Notes (Varchar (2000)) [NULL]

SurfSessionSwell:
SurfSessionSwellId          (INT)           [Primary Key]
SurfSessionId               (INT)           [NOT NULL] [References SurfSessions table]
Time                        (DATETIME2)     [NOT NULL]
WaveHeight                  (DECIMAL(5,2))  [NULL]   -- m
WavePeriod                  (DECIMAL(5,2))  [NULL]   -- s
WaveDirection               (INT)           [NULL]   -- °
SwellWaveHeight             (DECIMAL(5,2))  [NULL]   -- m
SwellWavePeriod             (DECIMAL(5,2))  [NULL]   -- s
SwellWaveDirection          (INT)           [NULL]   -- °
WindWaveHeight              (DECIMAL(5,2))  [NULL]   -- m
WindWavePeriod              (DECIMAL(5,2))  [NULL]   -- s
WindWaveDirection           (INT)           [NULL]   -- °
SecondarySwellWaveHeight    (DECIMAL(5,2))  [NULL]   -- m
SecondarySwellWavePeriod    (DECIMAL(5,2))  [NULL]   -- s
SecondarySwellWaveDirection (INT)           [NULL]   -- °
SeaLevelHeightMsl           (DECIMAL(5,2))  [NULL]   -- m
SeaSurfaceTemperature       (DECIMAL(5,2))  [NULL]   -- °C
OceanCurrentVelocity        (DECIMAL(5,2))  [NULL]   -- km/h
OceanCurrentDirection       (INT)           [NULL]   -- °
UNIQUE (SurfSessionId, Time)


SurfSessionWeather:
SurfSessionWeatherId  (INT)           [Primary Key]
SurfSessionId         (INT)           [NOT NULL] [References SurfSessions table]
Time                  (DATETIME2)     [NOT NULL]
Temperature2m         (DECIMAL(5,2))  [NULL]   -- °C
WeatherCode           (INT)           [NULL]   -- WMO code
CloudCover            (INT)           [NULL]   -- %
WindSpeed10m          (DECIMAL(5,2))  [NULL]   -- km/h
WindDirection10m      (INT)           [NULL]   -- °
UvIndex               (DECIMAL(5,2))  [NULL]
Precipitation         (DECIMAL(5,2))  [NULL]   -- mm

UNIQUE (SurfSessionId, Time)

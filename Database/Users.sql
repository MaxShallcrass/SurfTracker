CREATE TABLE Users (
    UserId    INT            IDENTITY(1,1)  NOT NULL,
    CognitoId NVARCHAR(128)                NOT NULL,
    Email     NVARCHAR(256)                NOT NULL,
    CreatedAt DATETIME2                    NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2                    NOT NULL DEFAULT GETUTCDATE(),

    CONSTRAINT PK_Users         PRIMARY KEY (UserId),
    CONSTRAINT UQ_Users_Cognito UNIQUE      (CognitoId)
);

CREATE TABLE [dbo].[Episodes] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   VARCHAR(50)  NOT NULL,
    [Details] VARCHAR(MAX) NOT NULL, 
    [Tags] VARCHAR(255) NULL, 
    [ArchiveUrl] VARCHAR(255) NULL, 
    [OriginalAirDate] DATETIME NOT NULL DEFAULT GetDate()
);
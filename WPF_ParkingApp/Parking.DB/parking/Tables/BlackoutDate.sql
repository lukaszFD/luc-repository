CREATE TABLE [parking].[BlackoutDate] (
    [DateId]       INT  IDENTITY (1, 1) NOT NULL,
    [BlackoutDate] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([DateId] ASC) ON [PRIMARY]
) ON [PRIMARY];


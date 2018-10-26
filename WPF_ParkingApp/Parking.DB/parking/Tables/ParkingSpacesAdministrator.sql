CREATE TABLE [parking].[ParkingSpacesAdministrator] (
    [AdministratorId]   INT            IDENTITY (1, 1) NOT NULL,
    [AdministratorName] NVARCHAR (100) NOT NULL,
    [StartsOn]          DATETIME       NOT NULL,
    [EndsOn]            DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([AdministratorId] ASC) ON [PRIMARY]
) ON [PRIMARY];


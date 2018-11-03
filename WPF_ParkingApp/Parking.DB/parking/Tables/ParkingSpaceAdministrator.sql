CREATE TABLE [parking].[ParkingSpaceAdministrator] (
    [AdministratorId]   INT            IDENTITY (1, 1) NOT NULL,
    [AdministratorName] NVARCHAR (100) NOT NULL,
    [StartsOn]            DATETIME       DEFAULT (GETDATE()) NOT NULL,
    [EndsOn]              DATETIME       DEFAULT ('9999-12-31 23:59:59.000') NOT NULL,
    PRIMARY KEY CLUSTERED ([AdministratorId] ASC) ON [PRIMARY]
) ON [PRIMARY];


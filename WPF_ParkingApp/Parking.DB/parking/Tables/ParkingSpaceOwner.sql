CREATE TABLE [parking].[ParkingSpaceOwner] (
    [ParkingSpaceOwnerID] INT            IDENTITY (1, 1) NOT NULL,
    [OwnerName]           NVARCHAR (100) DEFAULT (LOWER(SUBSTRING(SUSER_SNAME(),CHARINDEX('\',SUSER_SNAME())+(1),LEN(SUSER_SNAME())-CHARINDEX('\',SUSER_SNAME())))) NOT NULL,
    [SpaceNumber]         INT            NULL,
	[EmailContact]        smallint null,
    [StartsOn]            DATETIME       DEFAULT (GETDATE()) NOT NULL,
    [EndsOn]              DATETIME       DEFAULT ('9999-12-31 23:59:59.000') NOT NULL,
    PRIMARY KEY CLUSTERED ([ParkingSpaceOwnerID] ASC) ON [PRIMARY]
) ON [PRIMARY];


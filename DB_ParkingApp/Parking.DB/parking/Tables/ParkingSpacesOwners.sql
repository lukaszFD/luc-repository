CREATE TABLE [parking].[ParkingSpacesOwners] (
    [OwnerID]     INT            IDENTITY (1, 1) NOT NULL,
    [OwnerName]   NVARCHAR (100) DEFAULT (lower(substring(suser_sname(),charindex('\',suser_sname())+(1),len(suser_sname())-charindex('\',suser_sname())))) NOT NULL,
    [SpaceNumber] INT            NULL,
    [StartsOn]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [EndsOn]      DATETIME       DEFAULT ('9999-12-31 23:59:59.000') NOT NULL
);


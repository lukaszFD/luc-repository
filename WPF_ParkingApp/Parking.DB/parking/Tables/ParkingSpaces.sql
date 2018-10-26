CREATE TABLE [parking].[ParkingSpaces] (
    [ParkingSpaceId]      INT  IDENTITY (1, 1) NOT NULL,
    [Date]                DATE NOT NULL,
    [PlaceRentedFor]      INT  NULL,
    [ParkingSpaceOwnerID] INT  NULL,
    PRIMARY KEY CLUSTERED ([ParkingSpaceId] ASC) ON [PRIMARY]
) ON [PRIMARY];


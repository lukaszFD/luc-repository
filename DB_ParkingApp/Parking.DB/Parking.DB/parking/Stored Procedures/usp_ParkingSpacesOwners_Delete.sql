﻿
CREATE PROC [parking].[usp_ParkingSpacesOwners_Delete]
(
 @OwnerID INT 
)
AS

update parking.ParkingSpacesOwners
SET EndsOn = GETDATE()
WHERE 
	OwnerID = @OwnerID

DELETE FROM parking.ParkingSpaces 
WHERE
	Date >= CAST(GETDATE() AS DATE )
	AND 
	ParkingSpacesOwnerID = @OwnerID
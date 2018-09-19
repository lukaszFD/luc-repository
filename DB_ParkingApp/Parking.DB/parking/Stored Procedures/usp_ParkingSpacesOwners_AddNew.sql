
CREATE PROC [parking].[usp_ParkingSpacesOwners_AddNew]
(
 @owner NVARCHAR(100)
,@space INT 
)
AS

INSERT INTO [parking].[ParkingSpacesOwners] ([OwnerName],[SpaceNumber]) 
VALUES (@owner,@space)

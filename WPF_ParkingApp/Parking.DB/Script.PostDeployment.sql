/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
BEGIN
	Truncate Table [parking].[ParkingSpaceOwner]
	Truncate Table [parking].[ParkingSpaceAdministrator]
	Truncate Table [parking].[ParkingSpaceGuest]
END

BEGIN
	INSERT INTO [parking].[ParkingSpaceOwner]([OwnerName], [SpaceNumber], [EmailContact]) 
	VALUES 
		 ('Guest',90, null)
		,('Guest',98, null)
		,('Guest',109, null)
		,('Guest',119, null)
		,('Guest',161, null)
		,('lukasz.dejko',null,1)
		,('Izabela.Kukawska', null,1)

	INSERT INTO [parking].[ParkingSpaceAdministrator]([AdministratorName])
	VALUES 
	('lukasz.dejko')
	END
GO

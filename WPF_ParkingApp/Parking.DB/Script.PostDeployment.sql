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

INSERT INTO [parking].[ParkingSpaceOwner]([OwnerName], [SpaceNumber]) 
VALUES 
	('Guest',90)
,('Guest',98)
,('Guest',109)
,('Guest',119)
,('Guest',161)

INSERT INTO [parking].[ParkingSpaceAdministrator]([AdministratorName])
VALUES 
('lukasz.dejko')
 
GO

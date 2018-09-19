CREATE PROCEDURE [parking].[usp_BlackoutDates_AddNew]
(
	@date Date 
)

AS
INSERT INTO parking.BlackoutDates(Date) 
VALUES 
	(@date)
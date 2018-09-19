CREATE PROCEDURE [parking].[usp_BlackoutDates_Delete]
(
	@date Date 
)
AS
DELETE FROM parking.BlackoutDates 
WHERE 
	Date = (@date)
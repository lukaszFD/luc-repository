

CREATE PROC [parking].[usp_AddFreeParkingSpaces]
(
   @ownerId INT 
  ,@date_start DATE
  ,@date_end DATE 
)

AS

CREATE TABLE #parking
(
      [Date]       DATE
	 ,ParkingPlaceStatus int
	 ,ParkingSpacesOwnerID int 
)

WHILE @date_start <= @date_end

BEGIN
        INSERT INTO #parking
			(
			 Date
			,ParkingPlaceStatus
			,ParkingSpacesOwnerID
			)
        VALUES 
			(@date_start
			,null
			,@ownerId
			)
				 
			SET @date_start = DATEADD(dd, 1, @date_start)

END

	MERGE parking.ParkingSpaces AS target 
	USING (SELECT * FROM #parking ) AS Source ON target.Date = source.Date AND target.ParkingSpacesOwnerID = source.ParkingSpacesOwnerID AND target.date = source.Date

	WHEN NOT MATCHED BY TARGET THEN 
	INSERT 
	(
		 Date
		,ParkingPlaceStatus
		,ParkingSpacesOwnerID
	) 
	VALUES
	(
	     SOURCE.Date
		,SOURCE.ParkingPlaceStatus
		,SOURCE.ParkingSpacesOwnerID
	);




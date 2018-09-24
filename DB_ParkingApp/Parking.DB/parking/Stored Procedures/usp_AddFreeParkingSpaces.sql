

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
	 ,PlaceRentedFor int
	 ,ParkingSpacesOwnerID int 
)

WHILE @date_start <= @date_end

BEGIN
        INSERT INTO #parking
			(
			 Date
			,PlaceRentedFor
			,ParkingSpacesOwnerID
			)
        VALUES 
			(@date_start
			,CASE 
				WHEN DATENAME(dw, @date_start) IN ('Saturday','Sunday') THEN -1  
				WHEN @date_start IN ( SELECT [Date] FROM parking.BlackoutDates ) THEN -1 
			 END 
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
		,PlaceRentedFor
		,ParkingSpacesOwnerID
	) 
	VALUES
	(
	     SOURCE.Date
		,SOURCE.PlaceRentedFor
		,SOURCE.ParkingSpacesOwnerID
	);




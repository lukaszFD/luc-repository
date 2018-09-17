

CREATE PROC [parking].[usp_AddParkingSpaces]
(
  @ownerId INT 
)

AS

CREATE TABLE #parking
(
      [Date]       DATE
	 ,ParkingPlaceStatus int
	 ,ParkingSpacesOwnerID int 
)

DECLARE @date_start DATE = CAST(GETDATE() AS DATE)
DECLARE @date_end DATE  = DATEADD(MONTH,2,GETDATE())

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
			,CASE 
				WHEN DATENAME(dw, @date_start) IN ('Saturday','Sunday') THEN 0  
				WHEN @date_start IN ( SELECT [Date] FROM parking.BlackoutDates ) THEN 0 
			ELSE 1 END 
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




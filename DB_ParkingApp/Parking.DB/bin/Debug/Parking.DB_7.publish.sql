﻿/*
Deployment script for Parking

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Parking"
:setvar DefaultFilePrefix "Parking"
:setvar DefaultDataPath "c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [parking].[ParkingSpaces].[ParkingPlaceStatus] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [parking].[ParkingSpaces])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [parking].[ParkingSpaces]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [parking].[tmp_ms_xx_ParkingSpaces] (
    [Date]                 DATE NOT NULL,
    [PlaceRentedFor]       INT  NULL,
    [ParkingSpacesOwnerID] INT  NULL
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [parking].[ParkingSpaces])
    BEGIN
        INSERT INTO [parking].[tmp_ms_xx_ParkingSpaces] ([Date], [ParkingSpacesOwnerID])
        SELECT [Date],
               [ParkingSpacesOwnerID]
        FROM   [parking].[ParkingSpaces];
    END

DROP TABLE [parking].[ParkingSpaces];

EXECUTE sp_rename N'[parking].[tmp_ms_xx_ParkingSpaces]', N'ParkingSpaces';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [parking].[usp_AddFreeParkingSpaces]...';


GO


ALTER PROC [parking].[usp_AddFreeParkingSpaces]
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
GO
PRINT N'Refreshing [parking].[usp_ParkingSpacesOwners_Delete]...';


GO
EXECUTE sp_refreshsqlmodule N'[parking].[usp_ParkingSpacesOwners_Delete]';


GO
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

GO

GO
PRINT N'Update complete.';


GO

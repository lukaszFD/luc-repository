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
PRINT N'Creating [Data]...';


GO
ALTER DATABASE [$(DatabaseName)]
    ADD FILEGROUP [Data];


GO
ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [Data_6513A2BE], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Data_6513A2BE.mdf') TO FILEGROUP [Data];


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Creating [parking]...';


GO
CREATE SCHEMA [parking]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [parking].[ParkingSpacesOwners]...';


GO
CREATE TABLE [parking].[ParkingSpacesOwners] (
    [OwnerID]     INT            IDENTITY (1, 1) NOT NULL,
    [OwnerName]   NVARCHAR (100) NOT NULL,
    [SpaceNumber] INT            NULL,
    [StartsOn]    DATETIME       NOT NULL,
    [EndsOn]      DATETIME       NOT NULL
);


GO
PRINT N'Creating [parking].[ParkingSpacesAdministrator]...';


GO
CREATE TABLE [parking].[ParkingSpacesAdministrator] (
    [AdministratorName] NVARCHAR (100) NOT NULL,
    [StartsOn]          DATETIME       NOT NULL,
    [EndsOn]            DATETIME       NOT NULL
);


GO
PRINT N'Creating [parking].[ParkingSpaces]...';


GO
CREATE TABLE [parking].[ParkingSpaces] (
    [Date]                 DATE NOT NULL,
    [ParkingPlaceStatus]   INT  NULL,
    [ParkingSpacesOwnerID] INT  NULL
);


GO
PRINT N'Creating [parking].[BlackoutDates]...';


GO
CREATE TABLE [parking].[BlackoutDates] (
    [Date] DATE NOT NULL
);


GO
PRINT N'Creating unnamed constraint on [parking].[ParkingSpacesOwners]...';


GO
ALTER TABLE [parking].[ParkingSpacesOwners]
    ADD DEFAULT (lower(substring(suser_sname(),charindex('\',suser_sname())+(1),len(suser_sname())-charindex('\',suser_sname())))) FOR [OwnerName];


GO
PRINT N'Creating unnamed constraint on [parking].[ParkingSpacesOwners]...';


GO
ALTER TABLE [parking].[ParkingSpacesOwners]
    ADD DEFAULT (getdate()) FOR [StartsOn];


GO
PRINT N'Creating unnamed constraint on [parking].[ParkingSpacesOwners]...';


GO
ALTER TABLE [parking].[ParkingSpacesOwners]
    ADD DEFAULT ('9999-12-31 23:59:59.000') FOR [EndsOn];


GO
PRINT N'Creating [parking].[usp_ParkingSpacesOwners_Delete]...';


GO

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
GO
PRINT N'Creating [parking].[usp_ParkingSpacesOwners_AddNew]...';


GO

CREATE PROC [parking].[usp_ParkingSpacesOwners_AddNew]
(
 @owner NVARCHAR(100)
,@space INT 
)
AS

INSERT INTO [parking].[ParkingSpacesOwners] ([OwnerName],[SpaceNumber]) 
VALUES (@owner,@space)
GO
PRINT N'Creating [parking].[usp_AddParkingSpaces]...';


GO


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
GO
PRINT N'Update complete.';


GO

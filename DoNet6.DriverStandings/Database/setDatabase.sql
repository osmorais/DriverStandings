CREATE DATABASE DriverStandingsDatabase;

CREATE TABLE Race (
	RaceId serial PRIMARY KEY,
	NumberOfLaps INT
)

CREATE TABLE Driver (
	DriverId serial PRIMARY KEY,
	DriverCode VARCHAR ( 50 ) UNIQUE NOT NULL,
	Name VARCHAR ( 50 ) NOT NULL,
	TotalTime TIME,
	RaceId INT NOT NULL,
	FOREIGN KEY (RaceId)
      REFERENCES Race (RaceId)
)

CREATE TABLE Lap (
	LapId serial PRIMARY KEY,
	LapTime TIME,
	AverageSpeed NUMERIC(5,2),
	LapNumber INT,
	DriverId INT NOT NULL,
	FOREIGN KEY (DriverId)
      REFERENCES Driver (DriverId)
)

CREATE OR REPLACE FUNCTION ListRaces() RETURNS SETOF Race AS $$
BEGIN
	RETURN QUERY 
		SELECT
			r.RaceId				as RaceId,
			r.NumberOfLaps		as NumberOfLaps
		FROM Race as r
		ORDER BY r.RaceId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION GetRaceById(idRace INTEGER) RETURNS SETOF Race AS $$
BEGIN
	RETURN QUERY 
		SELECT
			r.RaceId				as RaceId,
			r.NumberOfLaps		as NumberOfLaps
		FROM Race as r
		WHERE r.RaceId = idRace
		ORDER BY r.RaceId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION GetLapById(idLap INTEGER) RETURNS SETOF Lap AS $$
BEGIN
	RETURN QUERY 
		SELECT
			l.LapId				as LapId,
			l.LapNumber			as LapNumber,
			l.Laptime			as LapTime,
			l.AverageSpeed		as AverageSpeed
		FROM Lap as l
		WHERE l.LapId = idLap
		ORDER BY l.LapId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION GetLapsByDriverId(idDriver INTEGER) RETURNS SETOF Lap AS $$
BEGIN
	RETURN QUERY 
		SELECT
			l.LapId				as LapId,
			l.LapNumber			as LapNumber,
			l.Laptime			as LapTime,
			l.AverageSpeed		as AverageSpeed
		FROM Lap as l
		WHERE l.DriverId = idDriver
		ORDER BY l.LapId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION ListDrivers() RETURNS SETOF Driver AS $$
BEGIN
	RETURN QUERY 
		SELECT
			d.DriverId				as DriverId,
			d.DriverCode			as DriverCode,
			d.Name					as Name,
			d.TotalTime				as TotalTime
		FROM Driver as d
		ORDER BY d.DriverId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION GetDriverById(idDriver INTEGER) RETURNS SETOF Driver AS $$
BEGIN
	RETURN QUERY 
		SELECT
			d.DriverId				as DriverId,
			d.DriverCode			as DriverCode,
			d.Name					as Name,
			d.TotalTime				as TotalTime
		FROM Driver as d
		WHERE d.DriverId = idDriver
		ORDER BY d.DriverId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

CREATE OR REPLACE FUNCTION GetDriversByRaceId(idRace INTEGER) RETURNS SETOF Driver AS $$
BEGIN
	RETURN QUERY 
		SELECT
			d.DriverId				as DriverId,
			d.DriverCode			as DriverCode,
			d.Name					as Name,
			d.TotalTime				as TotalTime
		FROM Driver as d
		WHERE d.RaceId = idRace
		ORDER BY d.DriverId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'
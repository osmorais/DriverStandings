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
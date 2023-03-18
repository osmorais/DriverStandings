CREATE OR REPLACE FUNCTION GetDriversByRaceId(idRace INTEGER) RETURNS SETOF Driver AS $$
BEGIN
	RETURN QUERY 
		SELECT
			d.DriverId				as DriverId,
			d.DriverCode			as DriverCode,
			d.Name					as Name,
			d.TotalTime				as TotalTime,
			d.RaceId				as RaceId
		FROM Driver as d
		WHERE d.RaceId = idRace
		ORDER BY d.DriverId;
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

SELECT * FROM GetDriversByRaceId(1);
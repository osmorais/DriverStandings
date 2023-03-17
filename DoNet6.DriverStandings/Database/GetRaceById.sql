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

SELECT * FROM GetRaceById(1);
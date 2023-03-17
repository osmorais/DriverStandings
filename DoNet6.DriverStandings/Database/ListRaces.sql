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

SELECT * FROM ListRaces();
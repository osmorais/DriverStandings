CREATE OR REPLACE FUNCTION ListRaces() RETURNS SETOF Race AS $$
BEGIN
	RETURN QUERY 
		SELECT
			RaceId				as RaceId,
			NumberOfLaps		as NumberOfLaps
		FROM Race
		ORDER BY RaceId
	RETURN;
END;
$$ LANGUAGE 'plpgsql'

SELECT * FROM ListRaces();
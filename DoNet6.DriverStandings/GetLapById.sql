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

SELECT * FROM GetLapById(1);
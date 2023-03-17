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

SELECT * FROM GetLapsByDriverId(1);
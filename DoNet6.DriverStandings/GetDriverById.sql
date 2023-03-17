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

SELECT * FROM GetDriverById(1);
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

SELECT * FROM ListDrivers();
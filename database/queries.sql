DELIMITER //
create PROCEDURE find_lati_longi(in l_name varchar(45))
BEGIN
                                 SELECT s.latitude, s.longitude
                                 FROM Team t, League l, Stadium s
                                 WHERE t.League_id=l.id
                                 AND t.Stadium_id=s.id
                                 AND l.name LIKE l_name;
END //
DELIMITER ;
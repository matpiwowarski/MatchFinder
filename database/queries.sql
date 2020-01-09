-- 1

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

-- 3

DELIMITER //
create PROCEDURE find_teamName_teamPosition_teamLast5games_ofOponnent(in t_name varchar(45))
BEGIN
                                 SELECT t.name, tc.position, tc.5th_last_game, tc.4th_last_game, tc.3rd_last_game, tc.2nd_last_game, tc.last_game
                                 FROM Team t, Team_currentForm tc, Game g
                                 WHERE t.Team_currentForm_id=tc.id
                                 AND (t.id=g.Team_home_id OR t.id=g.Team_away_id)
                                 AND g.game_date BETWEEN NOW() AND DATE_ADD(NOW(), INTERVAL 7 DAY);
END //
DELIMITER ;

-- 4
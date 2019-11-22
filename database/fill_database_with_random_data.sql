-- drop database mydb;


-- drop procedure fill_league;

delimiter //
CREATE PROCEDURE fill_league(
IN num INT)
BEGIN
DECLARE Country_id INT;
DECLARE name VARCHAR(45);
DECLARE tier INT;
DECLARE rememberNum INT;

DECLARE done BOOL;
DECLARE CountryCursor CURSOR FOR SELECT id FROM Country;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN CountryCursor;

SET rememberNum=num;
Country_Loop: LOOP
    IF done THEN
      LEAVE Country_Loop;
    END IF;
    SET num=rememberNum;
    WHILE num > 0 DO
    
	FETCH CountryCursor INTO Country_id;
    
	SET name= CONCAT('name', num);
    IF MOD (num, 10)=0 THEN
        SET tier= 1;
	END IF;
    IF MOD (num, 10)=9 THEN
        SET tier= 2;
	END IF;
    IF MOD (num, 10)=8 THEN
        SET tier= 3;
	END IF;
    IF MOD (num, 10)=7 THEN
        SET tier= 4;
	END IF;
    IF MOD (num, 10)=6 THEN
        SET tier= 5;
	END IF;
    IF MOD (num, 10)=5 THEN
        SET tier= 6;
	END IF;
    IF MOD (num, 10)=4 THEN
        SET tier= 7;
	END IF;
    IF MOD (num, 10)=3 THEN
        SET tier= 8;
	END IF; 
    IF MOD (num, 10)=2 THEN
        SET tier= 9;
	END IF; 
    IF MOD (num, 10)=1 THEN
        SET tier= 10;
	END IF;
    INSERT INTO league(Country_id, name, tier)
    VALUES (Country_id, name, tier);
    SET num = num - 1;
END WHILE;
END LOOP;

close CountryCursor;
END //
delimiter ;


-- call  fill_league(100);

-- select * from league;


delimiter //
CREATE PROCEDURE fill_stadium(
IN num INT)
BEGIN
DECLARE City_id INT;
DECLARE street VARCHAR(45);
DECLARE name VARCHAR(45);
DECLARE capacity INT;
DECLARE number INT;
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE CityCursor CURSOR FOR SELECT id FROM City;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN CityCursor;

SET rememberNum=num;
    city_Loop: LOOP
	FETCH CityCursor INTO City_id;
    IF done THEN
      LEAVE city_Loop;
    END IF;
	SET num=rememberNum;
    WHILE num > 0 DO
    
    SET capacity = FLOOR(100 + (RAND() * 90000));
	SET name = CONCAT('name',num);
	SET street = CONCAT('street',num);
    SET number = FLOOR(0 + (RAND() * 99));
    INSERT INTO stadium(City_id,street,number,name,capacity)
    VALUES (City_id,street,number,name,capacity);
    SET num = num - 1;
    
END WHILE;
END LOOP;

close CityCursor;
END //
delimiter ;

call fill_stadium(100);

select * from stadium;

-- drop procedure fill_team;

delimiter //
CREATE PROCEDURE fill_team(
IN num INT)
BEGIN
DECLARE League_id INT;
DECLARE Stadium_id INT;
DECLARE Team_currentForm_id INT;
DECLARE Team_achievements_id INT;
DECLARE name VARCHAR(45);
DECLARE coachName VARCHAR(45);
DECLARE logo_image LONGBLOB;

DECLARE rememberNum Int;

DECLARE done INT;
DECLARE LeagueCursor CURSOR FOR SELECT id FROM league;
DECLARE StadiumCursor CURSOR FOR SELECT id FROM stadium;
DECLARE currentFormCursor CURSOR FOR SELECT id FROM team_currentform;
DECLARE achievementsCursor CURSOR FOR SELECT id FROM team_achievements;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN LeagueCursor;
OPEN StadiumCursor;
OPEN currentFormCursor;
OPEN achievementsCursor;

SET rememberNum=num;
Team_Loop: LOOP
FETCH LeagueCursor INTO League_id;
	
    IF done THEN
      LEAVE Team_Loop;
    END IF;
    SET num=rememberNum;
    WHILE num > 0 DO
    
	FETCH StadiumCursor INTO Stadium_id;
	FETCH currentFormCursor INTO Team_currentForm_id;
	FETCH achievementsCursor INTO Team_achievements_id;
    Set name = CONCAT('name',num);
    Set coachName = CONCAT('Coach',num);
    SET logo_image=0;
    
    INSERT INTO team(League_id, Stadium_id, Team_currentForm_id, Team_achievements_id, name, logo_image, coach_name)
    VALUES (League_id, Stadium_id, Team_currentForm_id, Team_achievements_id, name, logo_image, coachName);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE LeagueCursor;
CLOSE StadiumCursor;
CLOSE currentFormCursor;
CLOSE achievementsCursor;

END //
delimiter ;

call fill_team(20);

select * from team;

    INSERT INTO team(League_id, Stadium_id, name, numberOfPlayers, position, capitanName)
    VALUES (1, 1, 'Korona Kielce', 23, 14, 'Andan Kovacevic');

delimiter //
CREATE PROCEDURE fill_team_currentForm(
IN num INT)
BEGIN
DECLARE position INT;
DECLARE ranking INT;
DECLARE goalsScored INT;
DECLARE goalsAgainst INT;
DECLARE goalsDifference INT;
DECLARE cleanSheets INT;
DECLARE 5th_last_game ENUM('w','d','l');
DECLARE 4th_last_game ENUM('w','d','l');
DECLARE 3rd_last_game ENUM('w','d','l');
DECLARE 2nd_last_game ENUM('w','d','l');
DECLARE last_game ENUM('w','d','l');

    WHILE num > 0 DO
    
	SET ranking = FLOOR(0 + (RAND() * 1114));
	SET goalsScored = FLOOR(0 + (RAND() * 150));
    SET goalsAgainst= FLOOR(0 + (RAND() * 150));
	SET goalsDifference = goalsScored-goalsAgainst;
    SET cleanSheets= FLOOR(0 + (RAND() * 38));
    SET position = FLOOR(0 + (RAND() * 24));
    
    IF MOD (num, 3)=0 THEN
        SET 5th_last_game = 'w';
        SET 4th_last_game = 'w';
        SET 3rd_last_game = 'd';
        SET 2nd_last_game = 'w';
        SET last_game = 'w';
	END IF; 
    IF MOD (num, 3)=2 THEN
        SET 5th_last_game = 'l';
        SET 4th_last_game = 'w';
        SET 3rd_last_game = 'l';
        SET 2nd_last_game = 'l';
        SET last_game = 'd';
	END IF; 
    IF MOD (num, 3)=1 THEN
        SET 5th_last_game = 'l';
        SET 4th_last_game = 'd';
        SET 3rd_last_game = 'd';
        SET 2nd_last_game = 'd';
        SET last_game = 'w';
	END IF;
    
    INSERT INTO team_currentform (position,ranking,5th_last_game,4th_last_game,3rd_last_game,2nd_last_game,last_game,points,goalsScored,goalsAgainst,goalsDifference,cleanSheets)
    VALUES (position,ranking,5th_last_game,4th_last_game,3rd_last_game,2nd_last_game,last_game,points,goalsScored,goalsAgainst,goalsDifference,cleanSheets);
    SET num = num - 1;
    
	END WHILE;


END //
delimiter ;


delimiter //
CREATE PROCEDURE fill_team_achievements(
IN num INT)
BEGIN
DECLARE nr_of_championship INT;
DECLARE years_of_championship varchar(45);
DECLARE nr_of_cup_wins INT;
DECLARE years_of_cup_wins varchar(45);
DECLARE nr_of_lesser_cups_win INT;
DECLARE years_of_leser_cups_win varchar(45);
DECLARE nr_of_club_wc_win INT;
DECLARE years_of_club_wc_win varchar(45);
DECLARE nr_of_champions_league_win INT;
DECLARE years_of_champions_league_win varchar(45);
DECLARE nr_of_lesser_international_wins INT;
DECLARE years_of_lesser_international_wins varchar(45);


    WHILE num > 0 DO
    
	SET nr_of_championship = FLOOR(0 + (RAND() * 5));
	SET nr_of_cup_wins = FLOOR(0 + (RAND() * 5));
	SET nr_of_lesser_cups_win = FLOOR(0 + (RAND() * 5));
	SET nr_of_club_wc_win = FLOOR(0 + (RAND() * 5));
	SET nr_of_champions_league_win = FLOOR(0 + (RAND() * 5));
	SET nr_of_lesser_international_wins = FLOOR(0 + (RAND() * 5));
    
    
    INSERT INTO team_achievements (nr_of_championship,nr_of_cup_wins,nr_of_lesser_cups_win,nr_of_club_wc_win,nr_of_champions_league_win,nr_of_lesser_international_wins)
    VALUES (nr_of_championship,nr_of_cup_wins,nr_of_lesser_cups_win,nr_of_club_wc_win,nr_of_champions_league_win,nr_of_lesser_international_wins);
    SET num = num - 1;
    
	END WHILE;


END //
delimiter ;


-- drop procedure fill_city;

delimiter //
CREATE PROCEDURE fill_city(
IN num INT)
BEGIN
DECLARE Country_id INT;
DECLARE name VARCHAR(45);
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE CountryCursor CURSOR FOR SELECT id FROM country;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN CountryCursor;


SET rememberNum=num;

Country_loop: LOOP
	FETCH CountryCursor INTO Country_id;
    IF done THEN
      LEAVE Country_Loop;
    END IF;
    SET num=rememberNum;
    WHILE num > 0 DO
    
    Set name = CONCAT('name',num);
    
    INSERT INTO city(Country_id, name)
    VALUES (Country_id, name);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE CountryCursor;

END //
delimiter ;

delimiter //
CREATE PROCEDURE fill_country(
IN num INT)
BEGIN
DECLARE name VARCHAR(45);

    WHILE num > 0 DO
    
    Set name = CONCAT('name',num);
    
    INSERT INTO country(name)
    VALUES (name);
    SET num = num - 1;
    
	END WHILE;


END //
delimiter ;


-- drop procedure fill_game;

delimiter //
CREATE PROCEDURE fill_game(
IN num INT)
BEGIN
DECLARE Team_home_id INT;
DECLARE Team_away_id INT;
DECLARE League_id INT;
DECLARE Stadium_id INT;
DECLARE home_score INT;
DECLARE away_score INT;
DECLARE game_date DATETIME;
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE LeagueCursor CURSOR FOR SELECT id FROM league;
DECLARE StadiumCursor CURSOR FOR SELECT id FROM stadium;
DECLARE HomeTeamCursor CURSOR FOR SELECT id FROM team where mod(id,2)=1;
DECLARE AwayTeamCursor CURSOR FOR SELECT id FROM team where mod(id,1)=0;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN LeagueCursor;
OPEN HomeTeamCursor;
OPEN AwayTeamCursor;
OPEN StadiumCursor;


SET @MIN = '2019-08-08 00:00:00';
SET @MAX = '2020-06-30 00:00:00';

SET rememberNum=num;

game_Loop: LOOP
	FETCH LeagueCursor INTO League_id;
    IF done THEN
      LEAVE game_Loop;
    END IF;
	SET num=rememberNum;
    WHILE num > 0 DO
	FETCH StadiumCursor INTO Stadium_id;	
	FETCH HomeTeamCursor INTO Team_home_id;
	FETCH AwayTeamCursor INTO Team_away_id;

	SET home_score = FLOOR(0 + (RAND() * 4));
	SET away_score = FLOOR(0 + (RAND() * 4));
    SET game_date  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
    
    INSERT INTO game(Stadium_id, Team_home_id, Team_away_id, League_id, home_score, away_score, game_date)
    VALUES (Team_home_id, Team_away_id, League_id, home_score, away_score, game_date);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE StadiumCursor;
CLOSE LeagueCursor;
CLOSE HomeTeamCursor;
CLOSE AwayTeamCursor;

END //
delimiter ;



delimiter //
CREATE PROCEDURE fill_user(
IN num INT)
BEGIN
DECLARE email VARCHAR(255);
DECLARE upassword VARCHAR(32);
DECLARE nr_of_games INT;
DECLARE username VARCHAR(16);
DECLARE name VARCHAR(45);
DECLARE surname VARCHAR(45);
DECLARE street VARCHAR(45);
DECLARE house_nr INT;
DECLARE create_time TIMESTAMP;
DECLARE City_id INT;
DECLARE Country_id INT;
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE CityCursor CURSOR FOR SELECT id FROM city;
DECLARE CountryCursor CURSOR FOR SELECT id FROM country;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN CityCursor;
OPEN CountryCursor;

SET rememberNum=num;
    user_Loop: LOOP
    IF done THEN
      LEAVE user_Loop;
    END IF;
	SET num=rememberNum;
    WHILE num > 0 DO
	FETCH CityCursor INTO City_id;
	FETCH CountryCursor INTO Country_id;
	
	SET email = CONCAT('email',num,'@gmail.com');
	SET name = CONCAT('name',num);
	SET surname = CONCAT('surname',num);
	SET username = CONCAT('username',num);
	SET upassword = CONCAT('password',num);
	SET street = CONCAT('street',num);
    SET house_nr = FLOOR(0 + (RAND() * 99));
    SET nr_of_games = FLOOR(0 + (RAND() * 99));
    
    
    
    
    
    INSERT INTO user(email, password, nr_of_games, username, name, surname, City_id, Country_id, street, house_nr)
    VALUES (email, password, nr_of_games, username, name, surname, City_id, Country_id, street, house_nr);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE CityCursor;
CLOSE CountryCursor;

END //
delimiter ;


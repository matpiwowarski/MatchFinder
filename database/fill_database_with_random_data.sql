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

call fill_teamStats(100);

select * from teamStats;


delimiter //
CREATE PROCEDURE fill_owner(
IN num INT)
BEGIN
DECLARE TeamID INT;
DECLARE name VARCHAR(45);
DECLARE surname VARCHAR(45);
DECLARE date_of_birth DATETIME;
DECLARE value INT;

DECLARE done INT;
DECLARE OwnerCursor CURSOR FOR SELECT id FROM team;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN OwnerCursor;


SET @MIN = '1960-01-01 00:00:00';
SET @MAX = '2001-12-30 00:00:00';

Owner_Loop: LOOP
    IF done THEN
      LEAVE Owner_Loop;
    END IF;
    WHILE num > 0 DO
    
	FETCH OwnerCursor INTO TeamID;
    Set name = CONCAT('name',num);
    Set surname = CONCAT('surname',num);
    SET date_of_birth  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
	SET value = FLOOR(100 + (RAND() * 50000000));
    
    
    INSERT INTO owner(Team_id, name, surname, date_of_birth, value)
    VALUES (TeamID, name, surname, date_of_birth, value);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE OwnerCursor;

END //
delimiter ;

call fill_owner(100);

select * from owner;

-- drop procedure fill_coach;

delimiter //
CREATE PROCEDURE fill_coach(
IN num INT)
BEGIN
DECLARE TeamID INT;
DECLARE name VARCHAR(45);
DECLARE surname VARCHAR(45);
DECLARE role VARCHAR(45);
DECLARE date_of_birth DATETIME;
DECLARE salary INT;
DECLARE contractLength DATETIME;
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE CoachCursor CURSOR FOR SELECT id FROM team;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN CoachCursor;


SET @MIN1 = '1960-01-01 00:00:00';
SET @MAX1 = '1996-12-30 00:00:00';

SET @MIN2 = '2020-01-01 00:00:00';
SET @MAX2 = '2025-12-30 00:00:00';

SET rememberNum=num;
Coach_Loop: LOOP
	FETCH CoachCursor INTO TeamID;
    IF done THEN
      LEAVE Coach_Loop;
    END IF;
    SET num=rememberNum;
    WHILE num > 0 DO
    
    Set name = CONCAT('name',num);
    Set surname = CONCAT('surname',num);
    SET date_of_birth  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN1, @MAX1)), @MIN1);
	SET salary = FLOOR(100 + (RAND() * 200000));
    SET contractLength  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN2, @MAX2)), @MIN2);
    
    IF MOD (num, 3)=2 THEN
        SET role= 'Main coach';
	END IF; 
    IF MOD (num, 3)=1 THEN
        SET role= 'Assistant coach';
	END IF; 
    IF MOD (num, 3)=0 THEN
        SET role= 'Goalkeeper coach';
	END IF;
    
    INSERT INTO coach (Team_id, name, surname, role, date_of_birth, salary, contractLength)
    VALUES (TeamID, name, surname, role, date_of_birth, salary, contractLength);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE CoachCursor;

END //
delimiter ;

call fill_coach(3);

select * from coach;

-- drop procedure fill_player;

delimiter //
CREATE PROCEDURE fill_player(
IN num INT)
BEGIN
DECLARE name VARCHAR(45);
DECLARE surname VARCHAR(45);
DECLARE date_of_birth DATETIME;
DECLARE number INT;
DECLARE salary INT;
DECLARE rememberNum INT;
DECLARE Team_id INT;
DECLARE nr INT;

DECLARE done INT;
DECLARE PlayerCursor CURSOR FOR SELECT id FROM team;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN PlayerCursor;

SET @MIN = '1979-01-01 00:00:00';
SET @MAX = '2002-12-30 00:00:00';

SET RememberNum=num;

Player_Loop: LOOP
	FETCH PlayerCursor INTO Team_ID;
    IF done THEN
      LEAVE Player_Loop;
    END IF;
    
    SET num=RememberNum;
    WHILE num > 0 DO
    
    SET nr = FLOOR(1 + (RAND() * 10000));
    Set name = CONCAT('name',nr);
    Set surname = CONCAT('surname',nr);
    SET date_of_birth  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
	SET salary = FLOOR(100 + (RAND() * 500000));
    SET number= FLOOR(1 + (RAND() * 99));
    
	INSERT INTO player(Team_id, name, surname, date_of_birth, number, salary)
	VALUES (Team_id, name, surname, date_of_birth, number, salary);

    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE PlayerCursor;

END //
delimiter ;

call fill_player(20);

select * from player;

-- drop procedure fill_playerStats;

delimiter //
CREATE PROCEDURE fill_playerStats(
IN num INT)
BEGIN
DECLARE PlayerID INT;
DECLARE contractLenght DATETIME;
DECLARE apperances INT;
DECLARE minutesPlayed INT;
DECLARE goals INT;
DECLARE assists INT;
DECLARE yellowCards INT;
DECLARE redCards INT;
DECLARE minutesInGame INT;
DECLARE RememberNum INT;


DECLARE done INT;
DECLARE PlayerStatsCursor CURSOR FOR SELECT id FROM player;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN PlayerStatsCursor;

SET @MIN = '2020-06-30 00:00:00';
SET @MAX = '2025-12-30 00:00:00';

PlayerStats_Loop: LOOP
    IF done THEN
      LEAVE PlayerStats_Loop;
    END IF;
    WHILE num > 0 DO
    
	FETCH PlayerStatsCursor INTO PlayerID;
    SET contractLenght  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
	SET goals = FLOOR(0 + (RAND() * 30));
    SET assists= FLOOR(0 + (RAND() * 20));
	SET apperances = FLOOR(0 + (RAND() * 38));
    SET minutesInGame= FLOOR(60 + (RAND() * 90));
    SET minutesPlayed= apperances*minutesInGame;
	SET yellowCards = FLOOR(0 + (RAND() * 20));
    SET redCards= FLOOR(0 + (RAND() * 10));
    
    
    
    INSERT INTO playerstats(Player_id, apperances, minutesPlayed, goals, assists, contractLenght, yellowCards, redCards)
    VALUES (PlayerID, apperances, minutesPlayed, goals, assists, contractLenght, yellowCards, redCards);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE PlayerStatsCursor;

END //
delimiter ;

call fill_playerStats(20);

select * from playerStats;


-- drop procedure fill_game;

delimiter //
CREATE PROCEDURE fill_game(
IN num INT)
BEGIN
DECLARE Team_home_id INT;
DECLARE Team_away_id INT;
DECLARE League_id INT;
DECLARE homeGoals INT;
DECLARE awayGoals INT;
DECLARE date DATETIME;
DECLARE rememberNum INT;


DECLARE done INT;
DECLARE LeagueCursor CURSOR FOR SELECT id FROM league;
DECLARE HomeTeamCursor CURSOR FOR SELECT id FROM team where mod(id,2)=1;
DECLARE AwayTeamCursor CURSOR FOR SELECT id FROM team where mod(id,1)=0;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN LeagueCursor;
OPEN HomeTeamCursor;
OPEN AwayTeamCursor;


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
		
	FETCH HomeTeamCursor INTO Team_home_id;
	FETCH AwayTeamCursor INTO Team_away_id;

	SET homeGoals = FLOOR(0 + (RAND() * 4));
	SET awayGoals = FLOOR(0 + (RAND() * 4));
    SET date  = TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, @MIN, @MAX)), @MIN);
    
    INSERT INTO game(Team_home_id, Team_away_id, League_id, homeGoals, awayGoals, date)
    VALUES (Team_home_id, Team_away_id, League_id, homeGoals, awayGoals, date);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE LeagueCursor;
CLOSE HomeTeamCursor;
CLOSE AwayTeamCursor;

END //
delimiter ;

call fill_game(100);

select * from game;

-- drop procedure fill_gameevent;

delimiter //
CREATE PROCEDURE fill_gameevent(
IN num INT)
BEGIN
DECLARE Game_id INT;
DECLARE Player_id INT;
DECLARE name VARCHAR(45);
DECLARE minute INT;
DECLARE min INT;
DECLARE rememberNum INT;

DECLARE done INT;
DECLARE GameCursor CURSOR FOR SELECT id FROM game;
DECLARE PlayerCursor CURSOR FOR SELECT id FROM player;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
SET done = false;
OPEN GameCursor;
OPEN PlayerCursor;

SET rememberNum=num;
    match_Loop: LOOP
	FETCH GameCursor INTO Game_id;
    IF done THEN
      LEAVE match_Loop;
    END IF;
	SET num=rememberNum;
    WHILE num > 0 DO
	FETCH PlayerCursor INTO Player_id;

	IF MOD (num, 5)=2 THEN
	SET name= 'Goal scored';
	END IF; 
    IF MOD (num, 5)=1 THEN
        SET name= 'Yellow card';
	END IF; 
    IF MOD (num, 5)=0 THEN
        SET name= 'Red card';
	END IF;
    IF MOD (num, 5)=4 THEN
        SET name= 'Substitution on';
	END IF;
    IF MOD (num, 5)=3 THEN
        SET name= 'Substitution off';
	END IF;
    
	SET minute = FLOOR(0 + (RAND() * 90));
    
    
    
    
    
    INSERT INTO gameevent(Game_id, Player_id, name, minute)
    VALUES (Game_id, Player_id, name, minute);
    SET num = num - 1;
    
	END WHILE;
END LOOP;

CLOSE GameCursor;
CLOSE PlayerCursor;

END //
delimiter ;

call fill_gameevent(7);

select * from coach;
select * from game;
select * from league;
select * from owner;
select * from player;
select * from gameevent;
select * from playerstats;
select * from team;
select * from teamstats;
select * from stadium;

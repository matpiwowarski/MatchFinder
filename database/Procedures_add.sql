DELIMITER //
Create PROCEDURE add_stadium(in couName varchar(45), in ciName varchar(45), in latitude double, in longitude double, in street varchar(45), in number int)
BEGIN

DECLARE CountryID INT;
DECLARE CityID INT;
    DECLARE done1 INT DEFAULT 0;



DECLARE CountryCursor CURSOR FOR SELECT id FROM Country WHERE Country.name= couName;


DECLARE CityCursor CURSOR FOR SELECT id FROM City WHERE City.name= ciName;
   DECLARE CONTINUE HANDLER FOR NOT FOUND SET done1 = 1;




INSERT into Country(name) 
Select couName from dual
where not exists(select * from Country
where name=couName LIMIT 1);

Open CountryCursor;
FETCH CountryCursor INTO CountryID;



INSERT into City(Country_id, name)
Select CountryID, ciName from dual
where not exists(select * from City
where name=ciName AND Country_id = CountryID LIMIT 1);
Open CityCursor;

FETCH CityCursor INTO CityID;

INSERT into Stadium(City_id, latitude, longitude, street, number) 
SELECT CityID, latitude, longitude, street, number
from City
where City.name=ciName;

CLOSE CountryCursor;
CLOSE CityCursor;

END //
DELIMITER ;


-- add team_currentForm
DELIMITER //
Create PROCEDURE add_team_currentForm(in position int, in games_played int,  in wins int,  in draws int,  
in loses int,  in five_last_game ENUM('W','D','L'), in four_last_game ENUM('W','D','L'), in three_last_game ENUM('W','D','L'), 
in two_last_game ENUM('W','D','L'), in one_last_game ENUM('W','D','L'), in points int, in goalsScored int, 
in goalsAgainst int, in goalsDifference int)
BEGIN


INSERT into Team_currentForm (position,  games_played, wins, draws, loses,	5th_last_game, 4th_last_game, 3rd_last_game, 2nd_last_game, last_game, points, goalsScored, goalsAgainst, goalsDifference) 
values (position, games_played, wins, draws, loses, five_last_game, four_last_game, three_last_game, two_last_game, one_last_game, points, goalsScored, goalsAgainst,	goalsDifference);


END //
DELIMITER ;

call add_team_currentForm (3, 'W', 'W', 'W', 'D', 'L', 38, 37, 20, 17);

-- add team
-- austrian league id 1, slovenian 2

DELIMITER //
Create PROCEDURE add_team(in stadium_id int, in League_id int, in team_currentForm_id int, in name varchar(45), in coach_name varchar(45))
BEGIN


INSERT into Team(Stadium_id, League_id, Team_currentForm_id, name, coach_name) 
values (stadium_id, League_id, team_currentForm_id, name, coach_name);


END //
DELIMITER ;

DELIMITER //
Create PROCEDURE add_game(in home_name varchar(45), in away_name varchar(45), in game_date datetime)
BEGIN

DECLARE homeID INT;
DECLARE awayID INT;
DECLARE stadiumID INT;
DECLARE leagueID INT;



DECLARE homeCursor CURSOR FOR SELECT id FROM Team WHERE Team.name= home_name;


DECLARE awayCursor CURSOR FOR SELECT id FROM Team WHERE Team.name= away_Name;


DECLARE stadiumCursor CURSOR FOR SELECT Stadium_id FROM Team WHERE Team.name= home_name;

DECLARE leagueCursor CURSOR FOR SELECT League_id FROM Team WHERE Team.name= home_name;



Open homeCursor;
FETCH homeCursor INTO homeID;

Open awayCursor;
FETCH awayCursor INTO awayID;

Open stadiumCursor;
FETCH stadiumCursor INTO stadiumID;

Open leagueCursor;
FETCH leagueCursor INTO leagueID;


INSERT into Game(Stadium_id, League_id, Team_home_id, Team_away_id, game_date) 
values (stadiumID, leagueID, homeID, awayID, game_date);

CLOSE homeCursor;
CLOSE awayCursor;
CLOSE stadiumCursor;
CLOSE leagueCursor;

END //
DELIMITER ;
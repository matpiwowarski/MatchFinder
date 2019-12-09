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
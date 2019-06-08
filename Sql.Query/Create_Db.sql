CREATE DATABASE Racing
GO

USE Racing
GO

Create Table Driver (
	DriverId uniqueidentifier default NEWID() NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Speed int NOT NULL
	)

INSERT INTO Driver(FirstName, LastName, Speed)
VALUES	('Peter', 'Sagan', 20),
		('Alejandro', 'Valverde', 19),
		('Simon', 'Yates', 18),
		('Elia', 'Viviani', 17),
		('Richie', 'Porte', 16),
		('Julian', 'Alaphilippe', 15),
		('Niki', 'Terpstra', 14),
		('Michael Valgren', 'Andersen', 13),
		('Primoz', 'Roglic', 12),
		('Chris', 'Froome', 11),
		('Romain', 'Bardet', 10),
		('Egan Arley', 'Bernal Gomez', 9),
		('Tiesj', 'Benoot', 8),
		('Jakob', 'Fuglsang', 7),
		('Daryl', 'Impey', 6),
		('Greg', 'Van Avermaet', 5),
		('Adam', 'Yates', 4),
		('Tom', 'Dumoulin', 3),
		('Jasper', 'Stuyven', 2),
		('Geraint', 'Thomas', 1) 

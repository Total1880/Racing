USE Racing
GO

CREATE TABLE RaceParticipant (
	ParticipantId UNIQUEIDENTIFIER NOT NULL,
	DriverId UNIQUEIDENTIFIER NOT NULL,
	RaceId UNIQUEIDENTIFIER NOT NULL,
	Position VARCHAR(200)
	)

CREATE TABLE Race (
	RaceId UNIQUEIDENTIFIER NOT NULL,
	RaceTrackId UNIQUEIDENTIFIER NOT NULL,
	SeasonId INT NOT NULL
	)

CREATE TABLE Season (
	SeasonId INT NOT NULL
	)
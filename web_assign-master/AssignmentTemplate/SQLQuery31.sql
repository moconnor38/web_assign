CREATE PROC uspInsertGame1
@GameName varchar(50),
@DeveloperID varchar(100),
@Genre varchar(50),
@Publisher varchar(50),
@GameImage varchar(100),
@RequiredSpec xml,
@DateReleased date
AS
INSERT INTO Game1 VALUES(@GameName,@DeveloperID,@Genre,@Publisher,@GameImage, @RequiredSpec, @DateReleased)
CREATE PROC uspBowseGames @Genre varchar(30)
AS
SELECT * FROM Game
WHERE Genre = @Genre
Go

EXEC uspBowseGames @Genre = 'Action'
CREATE PROC uspDisplayMemberLibrary
@email nvarchar(100)
AS
SELECT GAMENAME FROM MemberLibrary1
WHERE Email= @email
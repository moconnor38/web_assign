CREATE PROC uspSearch @Search varchar(30)
AS
Select * from Game1 
where GameName like '%' + @Search + '%'
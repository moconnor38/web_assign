CREATE PROC uspSearchMember @Search varchar(30)
AS
Select * from Member 
where UserName like '%' + @Search + '%'
use AcademicInfo
GO

drop security policy if exists Table1Filter 
drop function if exists sec.[fn_Table1Security] 
GO

EXEC Create_Tables

IF NOT EXISTS (SELECT  schema_name
	FROM    information_schema.schemata
	WHERE   schema_name = 'sec' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA sec'
END
GO

GO
CREATE FUNCTION sec.[fn_Table1Security](@username AS VARCHAR(50))
RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN
	SELECT 1 AS fn_SecurityPredicateResult
	WHERE USER_NAME() = @username OR IS_ROLEMEMBER('Teacher') = 1 OR IS_ROLEMEMBER('Admin') = 1
GO
CREATE SECURITY POLICY Table1Filter
ADD FILTER PREDICATE sec.[fn_Table1Security](Email)
ON dbo.Table1
WITH (STATE=ON)
GO

--exec deleteUser admin1
exec Create_Admin 'admin@gmail.com', 'pass'
--EXEC sp_addrolemember N'db_owner', N'admin1@gmail.com'
--exec('create login admin with password = ''pass''')

--go
--create user admin@admin.com for login test_logingo
--go

--CREATE OR ALTER PROCEDURE [Create_Admin]
--@Username as nvarchar(30), @Password nvarchar(30) AS
--BEGIN
--	declare @s varchar(100)
--	set @s = 'create login [' + @Username + '] with password = ''' + @Password + ''''
--	print @s
--	exec(@s)
--	set @s = 'create user [' + @Username + '] for login [' + @Username + ']'
--	print @s
--	exec(@s)
--	set @s = 'alter role Admin add member [' + @Username + ']'
--	print(@s)
--	exec(@s)
--	--set @s = 'create user [' + @Username + '] for login [' + @Username + ']'
--	--print @s
--	--exec(@s)
--	--exec('EXEC sp_addlogin ' + @Username + ',' + @Password)
	
--	--exec('EXEC sp_adduser ' + @Username + ',' + @Username + ',' +  '''Admin''')
--END
--GO

--use AcademicInfo
--create user ['mada'] with password = 'pass'

--revert
--select user
--exec Create_Admin 'admin2@admin.ro', 'pass'

--execute as login='admin2@admin.ro'


--execute as login='admin4'
--exec Create_Admin 'teacher@teacher.com', 'pass'

--grant execute on Create_Admin to Admin
--use AcademicInfo
--GRANT ALTER ANY LOGIN TO Admin

--grant alter any login to Admin
--grant alter credential to Admin
--grant alter user to Admin

--DELETE FROM [Table1Table3]
--GO
--DELETE FROM [Table2Table3]
--GO
--DELETE FROM [Table3]
--GO
--DELETE FROM [Users]
--GO
--DELETE FROM [Table5]
--GO
--DELETE FROM [Table6]
--GO
--DELETE FROM [Table2]
--GO
--DELETE FROM [Table7]
--GO
--DELETE FROM [Table8]
--GO

EXEC Table8_Insert '9097dc47-e843-4a1c-9978-bb5519f047b2', 'Matematica-Informatica'
GO
EXEC Table8_Insert 'bc425374-81d3-45a1-8789-1239745cf428', 'Drept'
GO
EXEC Table8_Insert '3467882d-f557-4278-93f6-958d99359576', 'Litere'
GO

EXEC Table7_Insert 'd65d97bd-b6d1-4829-a6d3-26bd51e921fa', 'Curs'
GO
EXEC Table7_Insert '63e3df71-a7d4-4a30-9299-16a11e104536', 'Seminar'
GO
EXEC Table7_Insert '08ac7284-0228-4267-b3bd-a5ff5f5c9e5b', 'Laborator'
GO
EXEC Table7_Insert 'a9ad4e26-3611-4a32-b72f-d4a35b88ad14', 'Bonus'
GO
EXEC Table7_Insert '2e9f5cda-5322-40e1-aa7d-faa0b51393e3', 'Partial'
GO

--exec deleteUser rares
GO
EXEC Table2_Insert '2357f5bd-cdbe-4e66-ae06-d013b3511050', 'BOIAN Rares', 'rares@123.com', 'pass'
GO
--exec deleteUser vancea
GO
EXEC Table2_Insert '99506ecd-d561-432f-8245-ec5ea3360ee8', 'VANCEA Alexandru', 'vancea@ks.com', 'pass'
GO
--exec deleteUser tzutzu
GO
EXEC Table2_Insert 'd813d59d-4827-4dc1-8d4b-4aef1b898a82', 'SUCIU Dan Mircea', 'tzutzu@dkwo.com', 'pass'
GO
--exec deleteUser forest
GO
EXEC Table2_Insert '426fef7f-4288-47f2-9df2-8c448dc04786', 'STERCA Adrian', 'forest@deo.com', '1234'
GO
--exec deleteUser florin
GO
EXEC Table2_Insert 'a1fde6e0-37de-4b13-b5a8-8db8a7da2187', 'STRETEANU Florin', 'florin@doe.ro', '1234'
GO
--exec deleteUser ioana
GO
EXEC Table2_Insert 'a9e2492f-85b0-47fa-bb36-8e04d8900c6d', 'VASIU Ioana', 'ioana@dow.ro', '1234'
GO
--exec deleteUser cuibus
GO
EXEC Table2_Insert 'fa76bd8c-fbab-45b6-a6e1-725378a778ae', 'CUIBUS Daiana', 'cuibus@lcdsp.com', 'pass'
GO
--exec deleteUser bocbocboc
GO
EXEC Table2_Insert 'cafdccfc-0073-413e-9c62-c7f6e84df9ff', 'BOC Oana', 'bocbocboc@qsl.com', '121212'
GO



EXEC Table6_Insert 'ebeb04bd-0610-4eb7-9184-1206eaeac40a', 'Matematica', '9097dc47-e843-4a1c-9978-bb5519f047b2'
GO
EXEC Table6_Insert '83604cf3-bc0a-4f59-aabe-841b14b12a17', 'Informatica', '9097dc47-e843-4a1c-9978-bb5519f047b2'
GO
EXEC Table6_Insert '95366cea-de83-4c47-b004-cee1056540d4', 'Drept Public', 'bc425374-81d3-45a1-8789-1239745cf428'
GO
EXEC Table6_Insert '6fee514f-81f0-414c-8c3d-f6966dd2bcf3', 'Drept Privat', 'bc425374-81d3-45a1-8789-1239745cf428'
GO
EXEC Table6_Insert '4fec4636-0c5c-468b-8320-6a65b2b01ac7', 'Literatură Română şi Teoria Literaturii', '3467882d-f557-4278-93f6-958d99359576'
GO
EXEC Table6_Insert 'dabf09a2-7e02-4941-9ff3-5a6a36d61d16', 'Limbi si literaturi clasice', '3467882d-f557-4278-93f6-958d99359576'
GO

EXEC Table5_Insert 931, '83604cf3-bc0a-4f59-aabe-841b14b12a17'
GO
EXEC Table5_Insert 932, '83604cf3-bc0a-4f59-aabe-841b14b12a17'
GO
EXEC Table5_Insert 934, '83604cf3-bc0a-4f59-aabe-841b14b12a17'
GO
EXEC Table5_Insert 935, '83604cf3-bc0a-4f59-aabe-841b14b12a17'
GO
EXEC Table5_Insert 11, 'ebeb04bd-0610-4eb7-9184-1206eaeac40a'
GO
EXEC Table5_Insert 261, '95366cea-de83-4c47-b004-cee1056540d4'
GO

--exec deleteUser mmie2169
GO
EXEC Table1_Insert 2169, 'Mircea V.D. Maria-Madalina', 'mmie2165@scs.ubbcluj.ro', 935, 'pass'
GO
--exec deleteUser mmie2165
GO
EXEC Table1_Insert 2165, 'Mihalache Mihai', 'mirceamariamadalina@yahoo.com', 935, '1234'
GO
--exec deleteUser biie2065
GO
EXEC Table1_Insert 2065, 'BILC Irina', 'maddamaddie@gmail.com', 931, '1234'
GO
--exec deleteUser jrie2143
GO
EXEC Table1_Insert 2143, 'JUGARU Robert', 'xyz@abc.com', 935, '1234'
GO
--exec deleteUser lskd1234
GO
EXEC Table1_Insert 1234, 'IONESCU Ion', '1@yahoo.ro', 11, '1234'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 2222, 'POPESCU Maria', 'hello@buhbye.co.uk', 11, '1234'
GO
--revert
--select user
--create login test_login with password = 'pass'
--go
--create user test_user for login test_login
--go

--use AcademicInfo
--exec as login='admin1@gmail.com'
--go
--EXEC Table1_Insert 2224, 'POP Maria', 'hello2211@buhbye.co.uk', 11, 'pass'
--exec Table1_ReadAll
--exec Table1_ReadById 2224
--exec Table1_Delete 2224
--go
--revert
--go

--select user

EXEC Table3_Insert 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab', 'Arhitectura Sistemelor de Calcul', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d', 'Virtual Reality', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 3, 7, 0
GO
EXEC Table3_Insert '0d223c71-6ddf-41e2-b266-25585f5b25f3', 'Drept', '95366cea-de83-4c47-b004-cee1056540d4', 1, 14, 14
GO
EXEC Table3_Insert '80f3c166-4067-40af-bc2e-8175618bde32', 'Literatura', 'dabf09a2-7e02-4941-9ff3-5a6a36d61d16', 2, 14, 7
GO
EXEC Table3_Insert 'b0094904-b0a7-4c66-a7d3-6c313d5d193a', 'Procesarea Datelor Audio Video', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 3, 7, 0
GO

EXEC Table2Table3_Insert '2357f5bd-cdbe-4e66-ae06-d013b3511050', 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d'
GO
EXEC Table2Table3_Insert '99506ecd-d561-432f-8245-ec5ea3360ee8', 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table2Table3_Insert '426fef7f-4288-47f2-9df2-8c448dc04786', 'b0094904-b0a7-4c66-a7d3-6c313d5d193a'
GO
EXEC Table2Table3_Insert 'a9e2492f-85b0-47fa-bb36-8e04d8900c6d', '0d223c71-6ddf-41e2-b266-25585f5b25f3'
GO
EXEC Table2Table3_Insert 'cafdccfc-0073-413e-9c62-c7f6e84df9ff', '80f3c166-4067-40af-bc2e-8175618bde32'
GO
EXEC Table2Table3_Insert '426fef7f-4288-47f2-9df2-8c448dc04786', 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO

EXEC Table1Table3_Insert 'c55ecf93-0396-4668-9ead-5c85627cdd14', 1234, '0d223c71-6ddf-41e2-b266-25585f5b25f3'
GO
EXEC Table1Table3_Insert '1ce4c47e-854b-427c-ba44-e932cced59f9', 2065, 'b0094904-b0a7-4c66-a7d3-6c313d5d193a'
GO
EXEC Table1Table3_Insert 'eb78364e-7842-4810-9c59-0830632adee8', 2143, 'b0094904-b0a7-4c66-a7d3-6c313d5d193a'
GO
EXEC Table1Table3_Insert 'fe3edbb7-cdbd-469a-903a-5f8831bf4c41', 2165, 'b0094904-b0a7-4c66-a7d3-6c313d5d193a'
GO
EXEC Table1Table3_Insert '878f4cca-f8c7-4d97-bb20-ceec3f78cb9d', 2169, 'b0094904-b0a7-4c66-a7d3-6c313d5d193a'
GO
EXEC Table1Table3_Insert 'ef64e4f2-bfbe-4f88-b088-6a0cae672215', 2222, '80f3c166-4067-40af-bc2e-8175618bde32'
GO
EXEC Table1Table3_Insert '5013cf3e-010e-4a52-8fa3-c534040bdd1d', 2143, 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d'
GO
EXEC Table1Table3_Insert '4e77a0e9-ac47-4f6b-8cd0-e4aca2c11f77', 2169, 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d'
GO

EXEC Table4_Insert '71bc1a66-a8f1-41f1-8ec9-3a1dfd589d43', 'eb78364e-7842-4810-9c59-0830632adee8', 2, '08ac7284-0228-4267-b3bd-a5ff5f5c9e5b', 10
GO
EXEC Table4_Insert '018a4207-9677-418a-9154-a8c14a808846', '4e77a0e9-ac47-4f6b-8cd0-e4aca2c11f77', 5, '63e3df71-a7d4-4a30-9299-16a11e104536', 9.50
GO
EXEC Table4_Insert '8e71804e-ba48-434e-8138-96cf0cbc6177', 'fe3edbb7-cdbd-469a-903a-5f8831bf4c41', 3, '63e3df71-a7d4-4a30-9299-16a11e104536', 5.75
GO
EXEC Table4_Insert 'd450a30f-7d2d-43b2-ba20-08de77f7982d', 'ef64e4f2-bfbe-4f88-b088-6a0cae672215', 10, '08ac7284-0228-4267-b3bd-a5ff5f5c9e5b', 7
GO
EXEC Table4_Insert 'a8a79787-1dbb-44c7-9c2e-f9dfae1ca0eb', 'c55ecf93-0396-4668-9ead-5c85627cdd14', 14, 'd65d97bd-b6d1-4829-a6d3-26bd51e921fa', 10.0
GO
EXEC Table4_Insert '27b2c9f5-1f38-4bf8-a0da-d616fa89cd57', 'ef64e4f2-bfbe-4f88-b088-6a0cae672215', 5, '08ac7284-0228-4267-b3bd-a5ff5f5c9e5b', NULL
GO


--execute Table1_ReadAll
--execute Table2_ReadAll
--execute Table1Table3_ReadAll
--execute Table3_ReadAll
--execute Table6_ReadAll
--execute Table8_ReadAll
--execute Table2Table3_ReadAll
--execute Table7_ReadAll
--execute Table4_ReadAll
--execute Table5_ReadAll

--execute as login='admin1'
--GO
--execute Table1_ReadAll
--GO
--revert
--execute as login='mmie2169'
--GO
--execute Table1_ReadAll
--execute Table1_ReadTable4
--execute Table4_ReadAll
--GO
--revert
--GO
--execute Table1_ReadAll

--execute as login='rares'

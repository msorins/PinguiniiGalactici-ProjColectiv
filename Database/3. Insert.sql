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
EXEC Table8_Insert '801c8f0d-f30c-4c0d-9f35-8611a8d52b5b', 'Fizica'
GO
EXEC Table8_Insert '5003086f-d507-4734-acc7-2410a42e9ccd', 'Chimie si Inginerie Chimica'
GO
EXEC Table8_Insert '151cf40f-3856-4b14-a1cb-3dee5b27ed0c', 'Biologie si Geologie'
GO
EXEC Table8_Insert '76ace7f4-f8f9-4347-bc96-2233b7574e7a', 'Geografie'
GO
EXEC Table8_Insert '1b8a482a-9c99-4889-8a88-8d84fef59d0e6', 'Stiinta si Ingineria Mediului'
GO
EXEC Table8_Insert '1d1d1a66-2fa9-4951-bf12-0de12b44f46c', 'Istorie si Filosofie'
GO
EXEC Table8_Insert '95ffffc2-6a8c-49ee-af63-4f4d23e0f302', 'Sociologie si Asistenta Sociala'
GO
EXEC Table8_Insert '7dd547c3-1315-4e9d-901f-3a098d78c8d4', 'Psihologie si Stiinte Ale Educatiei'
GO
EXEC Table8_Insert '655c6195-ee85-4c5f-a354-cb3363c50da8', 'Stiinte Economice si Gestiunea Afacerilor'
GO
EXEC Table8_Insert '96981183-c921-4b54-a157-608906595cb2', 'Studii Europene'
GO
EXEC Table8_Insert '5fb5e643-58f1-4643-94b5-7cbfee76d84d', 'Business'
GO
EXEC Table8_Insert 'c3e81a42-7bee-4656-b0bc-b54aaa210c13', 'Stiinte Politice, Administrative si ale Comunicarii'
GO
EXEC Table8_Insert 'e2357d57-c8c9-45e9-b23a-7bf9f30bd96d', 'Educatie Fizica si Sport'
GO
EXEC Table8_Insert 'fc1663d7-ae0c-4052-aec7-d944ad4e6f61', 'Stiinte Politice, Administrative si ale Comunicarii'
GO
EXEC Table8_Insert 'f373b55e-c924-4d41-b249-a1fe893cec8d', 'Educatie Fizica si Sport'
GO
EXEC Table8_Insert '1283c959-e99d-4937-8c98-3f4f41563f14', 'Teologie Ortodoxa'
GO
EXEC Table8_Insert '74a1e12c-ac23-41a2-95b0-466c5057b1ff', 'Teologie Greco-Catolica'
GO
EXEC Table8_Insert 'b6bcf5f2-f299-400a-bfbf-cffd99ba98d8', 'Teologie Reformata'
GO
EXEC Table8_Insert 'd07fb067-cd32-4829-b9f3-670dd25db448', 'Teologie Romano-Catolica'
GO
EXEC Table8_Insert '1d0d7331-e99a-4ff6-84e7-a45b8b6cc21b', 'Teatru si Film'
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
EXEC Table7_Insert 'a35f5669-fa38-4196-8346-8be80f792b56', 'Optional'
GO
EXEC Table7_Insert 'a0fc1d8a-c7a6-4a85-957c-2c9eaf1f45ac', 'Facultativ'
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
--exec deleteUser arthur
GO
EXEC Table2_Insert 'a6010569-2514-4d72-919c-38a218ad44b0', 'MOLNAR Arthur', 'arthur@raw.com', 'abcd'
GO
--exec deleteUser mihoc
GO
EXEC Table2_Insert 'eb0b09d9-16eb-46c6-bfd1-c62826c8a87f', 'MIHOC Tudor', 'mihoc@ubb.ro', '4321'
GO
--exec deleteUser lupsa
GO
EXEC Table2_Insert 'ed869b18-9c30-4256-a292-eb80241df1be', 'LUPSA Radu', 'lupsa@ubb.ro', 'bst'
GO
--exec deleteUser gaceanu
GO
EXEC Table2_Insert '0a4c8fe0-d4ea-4979-b661-9e39a4e7248f', 'GACEANU Radu', 'gaceanu@gml.com', '1234'
GO
--exec deleteUser cojocar
GO
EXEC Table2_Insert '8f20675a-7b60-416c-abfb-983a8b6a31a4', 'COJOCAR Dan', 'cojocar@mob.flt', '1234'
GO
--exec deleteUser bocior
GO
EXEC Table2_Insert '46d20b6e-cdcf-471c-b6d1-170ba1a12793', 'BOCICOR Maria', 'bocior@res.com', 'pass'
GO
--exec deleteUser motogna
GO
EXEC Table2_Insert '92515681-523c-4dff-a9e1-bca23f105112', 'MOTOGNA Simona', 'motogna@ceo.com', 'lr0'
GO
--exec deleteUser darabant
GO
EXEC Table2_Insert '6c39ecfd-9aec-4177-b296-128d49166d70', 'DARABANT Sergiu', 'darabant@mob.flt', '1234'
GO
--exec deleteUser craciun
GO
EXEC Table2_Insert 'd33490eb-ecc1-4638-be7b-f304844be99b', 'CRACIUN Florin', 'craciun@mob.flt', '1234'
GO
--exec deleteUser grigoreta
GO
EXEC Table2_Insert 'd5c0af94-bf35-47bb-88d0-b4f4a78f7a71', 'COJOCAR Grigoreta', 'grigoreta@jva.com', 'pass'
GO
--exec deleteUser czibula
GO
EXEC Table2_Insert 'ab20cd13-6d78-4a32-93e5-7346913ba414', 'CZIBULA Gabriela', 'darabant@mob.flt', '1234'
GO
--exec deleteUser diosan
GO
EXEC Table2_Insert 'baec3848-22a7-40bf-883b-431113f75eb7', 'DIOSAN Laura', 'diosan@ofc.ro', 'ml12'
GO
--exec deleteUser sotropa
GO
EXEC Table2_Insert '92d6dc44-f145-4133-ba80-47a04d292f2c', 'ŞOTROPA Dian', 'sotropa@scs.ro', 'pass'
GO
--exec deleteUser adela
GO
EXEC Table2_Insert '75910808-c33b-493a-be9d-69b58153e64c', 'RUS Adela', 'adela@new.com', 'qwerty'
GO
--exec deleteUser emilia
GO
EXEC Table2_Insert '794d12d8-605d-4335-8ae7-b403bf97cd7f', 'POP Emilia', 'emlia@ofc.ro', '4321'
GO
--exec deleteUser mircea
GO
EXEC Table2_Insert '76d89815-d7b2-4394-9e5e-b264fb3940bf', 'MIRCEA Ioan', 'mircea@pyt.com', 'asdf'
GO
--exec deleteUser adrianac
GO
EXEC Table2_Insert '039720f2-9be9-45a1-a7e7-eec955f0faad', 'COROIU Adriana', 'adrianac@lsp.ro', 'pass'
GO
--exec deleteUser ionut
GO
EXEC Table2_Insert '28caf36b-6c8b-4063-bd6e-44fdac48e4fb', 'BADARINZA Ioan', 'ionut@net.com', 'pass'
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
EXEC Table6_Insert '522ed0c2-e8c6-4050-93f0-68fb0d260b98', 'Departamentul de Fizica Biomedicala, Teoretica si Spectroscopie Moleculara', '801c8f0d-f30c-4c0d-9f35-8611a8d52b5b'
GO
EXEC Table6_Insert '547ec0c0-a0d3-4427-accf-6ab5c9d54dac', 'Departamentul de Fizica Starii Condensate si a Tehnologiilor Avansate', '801c8f0d-f30c-4c0d-9f35-8611a8d52b5b'
GO
EXEC Table6_Insert '0133c901-034b-43e0-b605-e4721626c906', 'Departamentul de Fizica al liniei maghiare', '801c8f0d-f30c-4c0d-9f35-8611a8d52b5b'
GO
EXEC Table6_Insert 'd233e89d-35c0-443a-833c-f085865f029f', 'Departamentul de Biologie Moleculară şi Biotehnologii', '151cf40f-3856-4b14-a1cb-3dee5b27ed0c'
GO
EXEC Table6_Insert '94df6943-04ff-41af-b3a8-57d4205d976c', 'Departamentul de Taxonomie şi Ecologie', '151cf40f-3856-4b14-a1cb-3dee5b27ed0c'
GO
EXEC Table6_Insert '2b16414d-aace-45c1-a97d-9852c4717e75', 'Departamentul de Geologie', '151cf40f-3856-4b14-a1cb-3dee5b27ed0c'
GO
EXEC Table6_Insert '23334ce2-0b3e-4705-828d-07fb9056d325', 'Departamentul Liniei Maghiare', '151cf40f-3856-4b14-a1cb-3dee5b27ed0c'
GO
EXEC Table6_Insert 'aa1ef44b-e67b-4717-8e38-07b55c759acf', 'Departamentul de Geografie Regională şi Planificare Teritorială', '76ace7f4-f8f9-4347-bc96-2233b7574e7a'
GO
EXEC Table6_Insert 'ae2e0014-6fd3-4ad1-8b8e-4b2248694d8d', 'Departamentul de Geografie Umană şi Turism', '76ace7f4-f8f9-4347-bc96-2233b7574e7a'
GO
EXEC Table6_Insert '51e53bc3-f38d-44cc-84ab-d85e645ccb16', 'Departamentul de Geografie Fizică şi Tehnică', '76ace7f4-f8f9-4347-bc96-2233b7574e7a'
GO
EXEC Table6_Insert '543cb256-d6ba-417f-bc6c-be1bdedd1d1a', 'Departamentul de Geografie al Liniei Maghiare', '76ace7f4-f8f9-4347-bc96-2233b7574e7a'
GO
EXEC Table6_Insert '0268f5c4-c54d-494b-b804-84997aa40efe', 'Departamentul de Geografie Fizică şi Tehnică', '76ace7f4-f8f9-4347-bc96-2233b7574e7a'
GO
EXEC Table6_Insert '58e60585-8b90-4d40-9cef-769c3af5c73d', 'Departamentul de Stiinta Mediului', '1b8a482a-9c99-4889-8a88-8d84fef59d0e6'
GO
EXEC Table6_Insert '44357938-03ed-4a72-90e3-5e4fd1386baf', 'Departamentul de Analiza si Ingineria Mediului', '1b8a482a-9c99-4889-8a88-8d84fef59d0e6'
GO
EXEC Table6_Insert 'e6cdcfee-d89e-4f17-b813-7838e3c0d2cb', 'Departamentul de Istorie Antică şi Arheologie', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert '48598018-2812-489a-aa55-fd103e6c8a01', 'Departamentul de Istorie Medievală, Premodernă şi Istoria Artei', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert 'da29b7f9-d85c-42fe-84f6-a69f896c3f51', 'Departamentul de Istorie Modernă, Arhivistică şi Etnologie', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert '6847f7d1-b391-4914-90ed-7deeb51b259f', 'Departamentul de Studii internaţionale şi Istorie Contemporană', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert '2248a815-3677-4354-8828-8f75ef204ebb', 'Departamentul de Istorie în limba maghiară', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert '0ca044aa-a500-4552-a738-663781fcec2c', 'Departamentul de Filosofie', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert 'e41ff27c-a72c-451d-8db4-3692dee11e06', 'Departamentul de Filosofie Premodernă şi Românească', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert 'dbd4146c-585d-428a-959a-e091506da49e', 'Departamentul de Filosofie în Limba maghiară', '1d1d1a66-2fa9-4951-bf12-0de12b44f46c'
GO
EXEC Table6_Insert '0a1e6215-1819-41ac-b120-9e43b53e77d6', 'Departamentul de Sociologie', '95ffffc2-6a8c-49ee-af63-4f4d23e0f302'
GO
EXEC Table6_Insert 'deae85a4-93e3-4c17-b7d3-6b6af683786c', 'Departamentul de Asistenţă Socială', '95ffffc2-6a8c-49ee-af63-4f4d23e0f302'
GO
EXEC Table6_Insert 'e29c3976-74e5-471d-8bf1-206a557097c0', 'Departamentul de Sociologie şi Asistenţă Socială al Liniei Maghiare', '95ffffc2-6a8c-49ee-af63-4f4d23e0f302'
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

/* ------------------------------  Galactic Penguins ------------------------------------------ */
--exec deleteUser mmie2169
GO
EXEC Table1_Insert 2169, 'Mircea V.D. Maria-Madalina', 'mmie2165@scs.ubbcluj.ro', 935, 'pass'
GO
--exec deleteUser mmie2165
GO
EXEC Table1_Insert 2165, 'Mihalache Mihai', 'mirceamariamadalina@yahoo.com', 935, '1234'
GO
--exec deleteUser jrie2143
GO
EXEC Table1_Insert 2143, 'JUGARU Robert', 'xyz@abc.com', 935, '1234'
GO
--exec deleteUser cnie2123
GO
EXEC Table1_Insert 2123, 'Ciprian Nazarie', 'cnie2123@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser nbie2124
GO
EXEC Table1_Insert 2124, 'Bianca Nemes', 'nbie2124@scs.ubbcluj.com', 935, 'pass'
GO
--exec deleteUser vdie2125
GO
EXEC Table1_Insert 2125, 'Denis Vieriu', 'vdie2125@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser daie2126
GO
EXEC Table1_Insert 2126, 'Alexandru Dogar', 'daie2126@scs.ubbcluj.com', 935, 'pass'
GO
--exec deleteUser oeie2127
GO
EXEC Table1_Insert 2127, 'Elena Obreja', 'oeie2127@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser meie2128
GO
EXEC Table1_Insert 2128, 'Emerson Micu', 'meie2128@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser aiie2129
GO
EXEC Table1_Insert 2129, 'Ioana Alexandra', 'aiie2129@scs.ubbcluj.com', 935, 'pass'
GO
--exec deleteUser maie2130
GO
EXEC Table1_Insert 2130, 'Alexandra Muresan', 'maie2130@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser mnie2131
GO
EXEC Table1_Insert 2131, 'Naomi Moisuc', 'mnie2131@scs.ubbcluj.com', 935, 'pass'
GO
--exec deleteUser nsie2132
GO
EXEC Table1_Insert 2132, 'Sebi Nechita', 'nsie2132@scs.ubbcluj.com', 935, 'pass'
GO
--exec deleteUser msie2133
GO
EXEC Table1_Insert 2133, 'Sorin Mircea', 'msie2133@scs.ubbcluj.com', 935, '1234'
GO
--exec deleteUser nvie2134
GO
EXEC Table1_Insert 2134, 'Vlad Neamt', 'nvie2134@scs.ubbcluj.com', 935, 'pass'
GO

/* ------------------------------------------ 921 ------------------------------------------*/
GO
EXEC Table1_Insert 2134, 'ARDELEANU Mircea', 'maie2134@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2135, 'Argint Cornel', 'caie2135@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2136, 'BADEA ION', 'ibie2136@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2137, 'BADEA NICOLAE', 'nbie2137@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2138, 'BADESCU LAVINIA', 'lbie2138@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2139, 'BADIC MIHAI', 'bmie2139@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2140, 'BALTAG OCTAVIAN', 'obie2140@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2141, 'BARABOI ADRIAN', 'abie2141@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2142, 'BARAN MARIA ILEANA', 'mbie2142@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2199, 'BECHET PAUL', 'pbie2143@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2144, 'BIDIAN DAN', 'bdie2144@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2145, 'SĂUTEA CAMELIA- GEORGETA', 'csie2145@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2146, 'NISTOR COSMINA', 'cnie2146@scs.ubbcluj.com', 921, 'pass'
GO
EXEC Table1_Insert 2147, 'CROICU ELENA', 'ecie2147@scs.ubbcluj.com', 921, 'pass'
GO

/* ------------------------------------------ 922 ------------------------------------------*/
GO
EXEC Table1_Insert 2148, 'MIXICH LORENA', 'lmie2148@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2149, 'ANDREICA SIMONA-AURICA', 'saie2149@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2150, 'STRĂULEA MARINA-ISABELA', 'msie2150@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2151, 'PĂUN LILIANA-MĂDĂLINA', 'lpie2151@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2152, 'GROSULEAC OVIDIU-ILIE', 'ogie2152@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2153, 'CUCUIAT ANDREI', 'acie2153@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2154, 'VASILIEV VALERIU', 'vvie2154@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2155, 'MARRALI MARIA CARMELA', 'mmie2155@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2156, 'UNTARU MARIA-ALEXANDRA', 'auie2156@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2157, 'ŞERBAN ANCA-ELENA', 'asie2157@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2158, 'PAVEL ANDRA-CRISTINA', 'apie2158@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2159, 'GULER CLAUDIA', 'cgie2159@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2160, 'ZDRENŢAN DACIAN', 'dzie2160@scs.ubbcluj.com', 922, 'pass'
GO
EXEC Table1_Insert 2161, 'HUHULEA ORIANA-RALUCA', 'ohie2161@scs.ubbcluj.com', 922, 'pass'
GO

/* ------------------------------------------ 911 ------------------------------------------*/
GO
EXEC Table1_Insert 2162, 'CÎRSTEA DAIANA-BIANCA', 'dcie2162@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2162, 'IVAN CRISTIAN-DENIS', 'ciie2162@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2163, 'NICOARĂ DENISA-MARIA', 'dnie2163@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2164, 'BOŢOC ANDREEA MALINA', 'abie2164@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2165, 'FRUJA ANDREEA-DAIANA', 'afie2165@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2166, 'HANG ALEXANDRU', 'ahie2166@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2167, 'LENHARDT SILVIU', 'slie2167@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2168, 'MERONIUC MĂLINA -  ŞTEFANIA', 'mmie2168@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2169, 'NUŢIU DORIN-IONUŢ', 'dnie2169@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2170, 'SANDU NARCIS-CASIAN', 'ns2170@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2171, 'BUBANSZKI ANDREEA-CRISTINA', 'abie2171@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2172, 'BALŞ DRAGOŞ-LUCIAN', 'dbie2172@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2173, 'CIOBANU ANA-MARIA', 'acie2173@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2174, 'BOLOGA DRAGOŞ - MIHAI', 'dbie2174@scs.ubbcluj.com', 911, 'pass'
GO
EXEC Table1_Insert 2175, 'CÎRLUGEA CĂTĂLIN-CONSTANTIN', 'ccie2175@scs.ubbcluj.com', 911, 'pass'

/* ------------------------------------------ 912 ------------------------------------------*/
GO
EXEC Table1_Insert 2176, 'NICOLA IOANA-ANDREEA', 'in2176@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2177, 'POPESCU DANIEL-PAUL', 'dpie2177@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2178, 'ROŞOIU NICOLETA-LOREDANA', 'nrie2178@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2179, 'ONEŢIU ADELINA-LIANA', 'aoie2179@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2180, 'MARINESCU ELENA-NICOLETA', 'emie2180@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2181, 'OLTEANU PATRICIA-DAIANA', 'poie2181@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2182, 'CRIŞAN GIORGIANA-ANDREEA', 'gcie2182@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2183, 'ENULESCU MIHAELA - ANDREEA', 'meie2183@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2184, 'GUBĂUCEANU DANA-CRISTINA', 'dgie2184@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2185, 'MIRCEA RALUCA-SORINA', 'mrie2185@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2186, 'UNGUR DAMARIS - LIDIA', 'du2186@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2187, 'RĂDUICA MARIA-IZABELA', 'mr2187@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2188, 'BAIAŞ CRISTINA-ELISABETA', 'cb2188@scs.ubbcluj.com', 912, 'abcd'
GO
EXEC Table1_Insert 2189, 'VUCEA ADELINA-NICOLETA', 'avie2189@scs.ubbcluj.com', 912, 'abcd'


--exec deleteUser biie2065
GO
EXEC Table1_Insert 2065, 'BILC Irina', 'maddamaddie@gmail.com', 931, '1234'
GO
--exec deleteUser lskd1234
GO
EXEC Table1_Insert 1234, 'IONESCU Ion', '1@yahoo.ro', 11, '1234'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 2222, 'POPESCU Maria', 'hello@buhbye.co.uk', 11, '1234'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 2256, 'POPESCU Ioana', 'pioana@scs.com', 11, '1234'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1467, 'Ioana Andrei', 'iandrei@scs.com', 11, 'pass'
GO
--exec deleteUser tmadalina4111
GO
EXEC Table1_Insert 4111, 'Tanase Madalina', 'tmadalina@scs.ubb.com', 934, 'pass'
GO
--exec deleteUser mcervinski1233
GO
EXEC Table1_Insert 1233, 'Cervinski Mariana', 'mcervinski@scs.ubbcluj.ro', 934, 'abcd'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1575, 'Mereniuc Edita', 'medita@edu.scs.com', 934, 'pass'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1722, 'Burlacu Maria', 'bmaria@scs.ubb.uk', 11, 'pass'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 8541, 'Chislea Sabina', 'csabina@edu.scc.com', 11, 'pass'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1456, 'Ciocan Liviu', 'cliviu@edu.scc.com', 932, 'pass'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1832, 'Corjan Anastasia', 'canstasia@edu.scs.com', 932, 'qwerty'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 9781, 'Curjos Diana', 'cdiana@edu.scs.com', 932, '1234'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1257, 'Sterpu Irina', 'sirina', 932, '4321'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1203, 'Lupascu Cristina', 'lcristina@edu.scs.com', 932, 'abcd'
GO
--exec deleteUser asdf2222
GO
EXEC Table1_Insert 1541, 'Mitu Ana', 'mana@edu.abc.com', 932, 'pass'
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
EXEC Table3_Insert '5ffa7ed7-42e4-4a80-9ded-e66da2df0271', 'Analiza matematica', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 0, 14
GO
EXEC Table3_Insert 'c87c5af0-3c1b-400a-a520-9d442f1c93d9', 'Algebra', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 0, 14
GO
EXEC Table3_Insert '1e15675f-daaa-4584-b0d7-395994dadeb5', 'Fundamentele Programarii', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert '5ee7eb35-3093-4a4e-b147-772043f8f351', 'Logica Computationala', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert '31e9b16a-c033-4d3c-b47e-f36d44b31a26', 'Comunicare si dezvoltare profesionala', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 0, 7
GO
EXEC Table3_Insert '26139308-c2a2-4868-bbd3-08918417192f', 'Programare in C', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 7, 7
GO
EXEC Table3_Insert '3190d74a-1e33-4220-9f74-c43a3177710d', 'Geometrie', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 0, 14
GO
EXEC Table3_Insert '342fcf03-3162-4a6f-a585-51280599df35', 'Sisteme dinamice', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert 'a72fe067-fe7a-4a8e-aa76-9287eb1a7a34', 'Programare orientata obiect', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert '8ddb8815-72ec-40db-9532-cef08e6647c5', 'Structuri de date si algoritmi', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert '032468af-02a9-4f46-aaeb-16e126bfe3c0', 'Algoritmica grafelor', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert '5f5d94d2-433f-4cfd-9e8d-9ad60dc69ee4', 'Sisteme de operare', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 14, 14
GO
EXEC Table3_Insert 'f7cc1449-d78b-4abd-af2c-53cf2b18d72f', 'Metode avansate de rezolvare a problemelor de matematică şi informatică', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 1, 7, 7
GO
EXEC Table3_Insert '02951ac8-e039-4a53-941e-840c08fbde4b', 'Programare functionala si logica', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert 'c747b445-2658-4778-8115-12eef5b9a152', 'Metode avansate de programare', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert 'b978db42-c291-4f98-b170-b4e49a52f79d', 'Retele de calculatoare', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert '59bf1af6-99b4-4fc5-b1ff-e295896acae1', 'Baze de date', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 7
GO
EXEC Table3_Insert 'eb0e258d-6553-4ca5-9fbc-45edade9f5f3', 'Probabilitati si statistica', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert 'd289505a-bce4-409c-8331-418a35abb203', 'Ingineria sistemelor soft', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 7
GO
EXEC Table3_Insert 'cc8d55c4-1c68-49d0-9e7a-547710706c47', 'Programare web', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert 'b639d4c7-9829-4bc8-9322-cd7b9f6116b2', 'Sisteme de gestiune a bazelor de date', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 7, 7
GO
EXEC Table3_Insert '5e1b4382-cfab-4e7e-a2d3-644af74462b4', 'Inteligenta artificiala', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 7, 14
GO
EXEC Table3_Insert 'edd395fb-3eca-4fd6-ae51-8f57747a7a4c', 'Medii de proiectare și programare', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 2, 14, 14
GO
EXEC Table3_Insert '440ca891-3686-4e95-9434-481a6272d241', 'Programare paralela si distribuita', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 3, 14, 7
GO
EXEC Table3_Insert 'b6b4cecb-68b6-4073-9266-5b32625ec760', 'Programare pentru dispozitive mobile', '83604cf3-bc0a-4f59-aabe-841b14b12a17', 3, 14, 14
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
EXEC Table2Table3_Insert 'a6010569-2514-4d72-919c-38a218ad44b0', '1e15675f-daaa-4584-b0d7-395994dadeb5'
GO
EXEC Table2Table3_Insert '92515681-523c-4dff-a9e1-bca23f105112', '26139308-c2a2-4868-bbd3-08918417192f'
GO
EXEC Table2Table3_Insert '46d20b6e-cdcf-471c-b6d1-170ba1a12793', 'a72fe067-fe7a-4a8e-aa76-9287eb1a7a34'
GO
EXEC Table2Table3_Insert 'ed869b18-9c30-4256-a292-eb80241df1be', '032468af-02a9-4f46-aaeb-16e126bfe3c0'
GO
EXEC Table2Table3_Insert '2357f5bd-cdbe-4e66-ae06-d013b3511050', '5f5d94d2-433f-4cfd-9e8d-9ad60dc69ee4'
GO
EXEC Table2Table3_Insert 'd33490eb-ecc1-4638-be7b-f304844be99b', 'c747b445-2658-4778-8115-12eef5b9a152'
GO
EXEC Table2Table3_Insert '6c39ecfd-9aec-4177-b296-128d49166d70', 'b978db42-c291-4f98-b170-b4e49a52f79d'
GO
EXEC Table2Table3_Insert '0a4c8fe0-d4ea-4979-b661-9e39a4e7248f', 'edd395fb-3eca-4fd6-ae51-8f57747a7a4c'
GO
EXEC Table2Table3_Insert '426fef7f-4288-47f2-9df2-8c448dc04786', 'cc8d55c4-1c68-49d0-9e7a-547710706c47'
GO
EXEC Table2Table3_Insert 'd813d59d-4827-4dc1-8d4b-4aef1b898a82', 'b639d4c7-9829-4bc8-9322-cd7b9f6116b2'
GO
EXEC Table2Table3_Insert 'eb0b09d9-16eb-46c6-bfd1-c62826c8a87f', '5e1b4382-cfab-4e7e-a2d3-644af74462b4'
GO
EXEC Table2Table3_Insert 'ed869b18-9c30-4256-a292-eb80241df1be', '440ca891-3686-4e95-9434-481a6272d241'
GO
EXEC Table2Table3_Insert '8f20675a-7b60-416c-abfb-983a8b6a31a4', 'b6b4cecb-68b6-4073-9266-5b32625ec760'
GO

EXEC Table1Table3_Insert 'c55ecf93-0396-4668-9ead-5c85627cdd14', 1234, '0d223c71-6ddf-41e2-b266-25585f5b25f3'
GO
EXEC Table1Table3_Insert '1ce4c47e-854b-427c-ba44-e932cced59f9', 2065, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert 'eb78364e-7842-4810-9c59-0830632adee8', 2143, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert 'fe3edbb7-cdbd-469a-903a-5f8831bf4c41', 2165, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert '878f4cca-f8c7-4d97-bb20-ceec3f78cb9d', 2169, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert 'ef64e4f2-bfbe-4f88-b088-6a0cae672215', 2222, '80f3c166-4067-40af-bc2e-8175618bde32'
GO
EXEC Table1Table3_Insert '5013cf3e-010e-4a52-8fa3-c534040bdd1d', 2143, 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d'
GO
EXEC Table1Table3_Insert '4e77a0e9-ac47-4f6b-8cd0-e4aca2c11f77', 2169, 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d'
GO
EXEC Table1Table3_Insert 'f3629c6e-8b70-464a-9ad1-f54fe2f7129c', 2170, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert 'c19d0b35-9d9f-4277-abab-c370451b61e4', 2171, '0d223c71-6ddf-41e2-b266-25585f5b25f3'
GO
EXEC Table1Table3_Insert '456f5658-a122-445f-ad45-13df93eb7b1f', 2172, 'f1647dfe-bdb0-4987-b0ac-45c7a7d80b4db'
GO
EXEC Table1Table3_Insert 'ea318bb6-b9c8-408c-8913-c458dac04ae1', 2173, '0d223c71-6ddf-41e2-b266-25585f5b25f3'
GO
EXEC Table1Table3_Insert '84ab75ce-a8d1-493d-89d1-abf078f2ae12', 2174, 'ba889e1a-0ec5-4089-b702-3c9bf80e5bab'
GO
EXEC Table1Table3_Insert '05382496-7111-4dee-a6a4-5aecfbc2b542', 2175, '80f3c166-4067-40af-bc2e-8175618bde32'
GO
EXEC Table1Table3_Insert 'f370566b-1de8-4ae8-8684-f735ad3f9923', 2176, '5ffa7ed7-42e4-4a80-9ded-e66da2df0271'
GO
EXEC Table1Table3_Insert 'bbba1b24-b781-4d73-8505-77a7541087eb', 2177, 'c87c5af0-3c1b-400a-a520-9d442f1c93d9'
GO
EXEC Table1Table3_Insert '4c56686b-5217-43bd-9aec-1cfb185816a3', 2178, '1e15675f-daaa-4584-b0d7-395994dadeb5'
GO
EXEC Table1Table3_Insert '14870209-cc67-4504-8014-05ef6830e27e', 2179, '5ee7eb35-3093-4a4e-b147-772043f8f351'
GO
EXEC Table1Table3_Insert '128f0497-8c77-44b6-8f79-e9bb5477f114', 2180, '31e9b16a-c033-4d3c-b47e-f36d44b31a26'
GO
EXEC Table1Table3_Insert '7889d2b5-dddc-4935-a703-d8b8e144254b', 2181, '26139308-c2a2-4868-bbd3-08918417192f'
GO
EXEC Table1Table3_Insert '32ff8f52-0db9-4364-917a-fa5aa966dd46', 2182, '3190d74a-1e33-4220-9f74-c43a3177710d'
GO
EXEC Table1Table3_Insert '83ab6f79-1209-4803-af2c-a717c82d4ba3', 2183, '342fcf03-3162-4a6f-a585-51280599df35'
GO
EXEC Table1Table3_Insert 'bd4dada6-063d-47f0-b89d-e826c1d21bb5', 2184, 'a72fe067-fe7a-4a8e-aa76-9287eb1a7a34'
GO
EXEC Table1Table3_Insert 'a3f01e99-e459-4abb-9184-78bdf8db4a5c', 2185, '8ddb8815-72ec-40db-9532-cef08e6647c5'
GO
EXEC Table1Table3_Insert '327cf402-125c-4439-a335-65c5ad256345', 2186, '032468af-02a9-4f46-aaeb-16e126bfe3c0'
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

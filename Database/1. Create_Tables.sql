USE AcademicInfo
GO
CREATE OR ALTER PROCEDURE [Create_Tables] AS
BEGIN

	IF OBJECT_ID('dbo.Table4', 'U') IS NOT NULL 
		DROP TABLE dbo.Table4;
	IF OBJECT_ID('dbo.Table1Table3', 'U') IS NOT NULL 
		DROP TABLE dbo.Table1Table3;
	IF OBJECT_ID('dbo.Table2Table3', 'U') IS NOT NULL 
		DROP TABLE dbo.Table2Table3;
	IF OBJECT_ID('dbo.Table3', 'U') IS NOT NULL 
		DROP TABLE dbo.Table3;
	--IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL 
	--	DROP TABLE dbo.Users;
		IF OBJECT_ID('dbo.Table1', 'U') IS NOT NULL 
		DROP TABLE dbo.Table1;
	IF OBJECT_ID('dbo.Table5', 'U') IS NOT NULL 
		DROP TABLE dbo.Table5;
	IF OBJECT_ID('dbo.Table6', 'U') IS NOT NULL 
		DROP TABLE dbo.Table6;
	IF OBJECT_ID('dbo.Table2', 'U') IS NOT NULL 
		DROP TABLE dbo.Table2;
	IF OBJECT_ID('dbo.Table7', 'U') IS NOT NULL 
		DROP TABLE dbo.Table7;
	IF OBJECT_ID('dbo.Table8', 'U') IS NOT NULL 
		DROP TABLE dbo.Table8;
	
		
	CREATE TABLE [Table8] (
		[FacultyID] UNIQUEIDENTIFIER,
		[Name] VARCHAR(100),
		CONSTRAINT [PK_Table8] PRIMARY KEY([FacultyID])
	)

	CREATE TABLE [Table7] (
		[TypeID] UNIQUEIDENTIFIER,
		[Name] VARCHAR(20),
		CONSTRAINT [PK_Table7] PRIMARY KEY([TypeID])
	)
	
	create table [Table2] (
		[TeacherID] UNIQUEIDENTIFIER,
		[Name] varchar(100),
		CONSTRAINT [PK_Table2] PRIMARY KEY ([TeacherID])
	)

	CREATE TABLE [Table6] (
		[DepartamentID] UNIQUEIDENTIFIER,
		[Name] NVARCHAR(50) NULL,
		[FacultyID] UNIQUEIDENTIFIER,
		CONSTRAINT [PK_Table6] PRIMARY KEY ([DepartamentID]),
		CONSTRAINT [FK_Table6Table8] FOREIGN KEY ([FacultyID]) 
			REFERENCES [Table8]([FacultyID]) ON DELETE CASCADE
	)

	CREATE TABLE [Table5] (
		[GroupNumber] INT,
		[DepartamentID] UNIQUEIDENTIFIER,
		CONSTRAINT [PK_Table5] PRIMARY KEY ([GroupNumber]),
		CONSTRAINT [FK_Table5Table6] FOREIGN KEY ([DepartamentID]) 
			REFERENCES [Table6]([DepartamentID]) ON DELETE CASCADE
	)

	create table [Table1] (
		[RegistrationNumber] int,
		[Name] varchar(100) NULL,
		[Email] text NULL,
		[GroupNumber] INT,
		[Username] VARCHAR(50),
		CONSTRAINT [PK_Table1] PRIMARY KEY ([RegistrationNumber]),
		CONSTRAINT [FK_Table1Table5] FOREIGN KEY([GroupNumber])
			REFERENCES [Table5]([GroupNumber]) ON DELETE SET NULL
	)

	--create table [Users](
	--	[Username] varchar(50),
	--	[Password] text,
	--	[TeacherID] UNIQUEIDENTIFIER foreign key
	--		references Table2(TeacherID)  ON DELETE CASCADE,
	--	[StudentID] INT foreign key references
	--		Table1(RegistrationNumber) ON DELETE CASCADE ,
	--	CONSTRAINT [PK_Users] PRIMARY KEY ([Username])
	--)
	
	CREATE TABLE [Table3](
		[CourseID] UNIQUEIDENTIFIER,
		[Name] NVARCHAR(100),
		[DepartamentID] UNIQUEIDENTIFIER,
		[Year] INT,
		[TotalLabNr] INT,
		[TotalSeminarNr] INT,
		CONSTRAINT [PK_Table3] PRIMARY KEY ([CourseID]),
		CONSTRAINT [FK_Table3Table6] FOREIGN KEY ([DepartamentID]) 
			REFERENCES [Table6]([DepartamentID]) ON DELETE CASCADE
	)

	CREATE TABLE [Table2Table3](
		[TeacherID] UNIQUEIDENTIFIER,
		[CourseID] UNIQUEIDENTIFIER,
		CONSTRAINT [FK_Table2Table3Table2] FOREIGN KEY ([TeacherID]) 
			REFERENCES [Table2]([TeacherID]) ON DELETE NO ACTION,
		CONSTRAINT [FK_Table2Table3Table3] FOREIGN KEY ([CourseID]) 
			REFERENCES Table3([CourseID]) ON DELETE NO ACTION,
		CONSTRAINT [PK_Table2Table3] PRIMARY KEY ([TeacherID], [CourseID])
	)
	
	CREATE TABLE [Table1Table3](
		[EnrollmentID] UNIQUEIDENTIFIER,
		[StudentID] INT,
		[CourseID] UNIQUEIDENTIFIER,
		CONSTRAINT [PK_Table1Table3] PRIMARY KEY ([EnrollmentID]),
		CONSTRAINT [FK_Table1Table3Table1] FOREIGN KEY ([StudentID]) 
			REFERENCES [Table1]([RegistrationNumber]) ON DELETE NO ACTION,
		CONSTRAINT [FK_Table1Table3Table3] FOREIGN KEY ([CourseID]) 
			REFERENCES [Table3]([CourseID]) ON DELETE NO ACTION
	)

	CREATE TABLE [Table4](
		[AttendanceID] UNIQUEIDENTIFIER,
		[EnrollmentID] UNIQUEIDENTIFIER,
		[WeekNr] INT,
		[TypeID] UNIQUEIDENTIFIER,
		[Grade] TINYINT,
		CONSTRAINT [PK_Table4] PRIMARY KEY ([AttendanceID]),
		CONSTRAINT [FK_Table4Table1Table3] FOREIGN KEY ([EnrollmentID]) 
			REFERENCES [Table1Table3]([EnrollmentID]) ON DELETE CASCADE ,
		CONSTRAINT [FK_Table4Table7] FOREIGN KEY ([TypeID]) 
			REFERENCES [Table7]([TypeID]) ON DELETE CASCADE
	)

END
GO

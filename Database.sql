USE [master]
GO
/****** Object:  Database [MVP_DB]    Script Date: 22.05.2023 23:37:30 ******/
CREATE DATABASE [MVP_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVP_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MVP_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MVP_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MVP_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MVP_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVP_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVP_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVP_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVP_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVP_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVP_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVP_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVP_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVP_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVP_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVP_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVP_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVP_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVP_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVP_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVP_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVP_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVP_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVP_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVP_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVP_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVP_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVP_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVP_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MVP_DB] SET  MULTI_USER 
GO
ALTER DATABASE [MVP_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVP_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVP_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVP_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MVP_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MVP_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MVP_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MVP_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MVP_DB]
GO
/****** Object:  Table [dbo].[[Admin]]]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[[Admin]]](
	[id] [int] IDENTITY(100,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Absence]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absence](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentSubjectId] [int] NULL,
	[date] [datetime] NULL,
	[teacherID] [int] NULL,
	[isMotivated] [bit] NULL,
	[studentID] [int] NULL,
	[classID] [int] NULL,
	[SubjectID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[specialization_id] [int] NULL,
	[head_teacher_id] [int] NULL,
	[name] [varchar](50) NULL,
	[number] [int] NULL,
	[year] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mark] [float] NULL,
	[studentSubjectID] [int] NULL,
	[finalMark] [float] NULL,
	[finalMarkID] [int] NULL,
	[teacherID] [int] NULL,
	[classID] [int] NULL,
	[studentID] [int] NULL,
	[SubjectID] [int] NULL,
	[semester] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeadTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeadTeacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[classID] [int] NULL,
	[studentSubjectID] [int] NULL,
	[specializationID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[specialization_id] [int] NULL,
	[path] [varchar](50) NULL,
	[teacherID] [int] NULL,
	[studentID] [int] NULL,
	[studentSubjectID] [int] NULL,
	[classID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isHeadTeacher] [bit] NULL,
	[teacherSubjectID] [int] NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[finalMarkID] [int] NULL,
	[finalMark] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempAdmin]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempAdmin](
	[id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absence]  WITH CHECK ADD FOREIGN KEY([studentSubjectId])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Absence]  WITH CHECK ADD FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([classID])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([studentSubjectID])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([teacherSubjectID])
REFERENCES [dbo].[Subject] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AddStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStudent]
    @name NVARCHAR(50),
    @surname NVARCHAR(50),
    @password NVARCHAR(50),
    @user_id int,
    @class_id int,
    @student_subject_id int,
    @specialization_id int
AS
BEGIN
    INSERT INTO [User] (name, surname, password)
    VALUES (@name, @surname, @password)

    INSERT INTO Student (id, classID, studentSubjectID, specializationID)
    VALUES (@user_id, @class_id, @student_subject_id, @specialization_id)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClass]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClass]
    @class_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Class
    WHERE id = @class_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCourse]
    @grade_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Subject
    WHERE id = @grade_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudent]
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Student
    WHERE id = @student_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTeacher]
    @teacher_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Teacher
    WHERE id = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[FindClassOfHeadTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindClassOfHeadTeacher]
    @teacher_id VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id
    FROM Class
    WHERE head_teacher_id = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[FindSubjectNameOfStudentSpecializationID]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindSubjectNameOfStudentSpecializationID]
    @student_subject_id INT
AS
BEGIN
    SELECT
        Subject.name
    FROM
        Student
    INNER JOIN Subject ON Student.studentSubjectID = Subject.id
    WHERE
        Student.id = @student_subject_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAbsencesByStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAbsencesByStudent]
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT A.id,A.date, A.isMotivated, S.name
    FROM Absence A
    INNER JOIN Subject S ON A.studentSubjectId = S.studentSubjectID
    WHERE A.studentID = @student_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAbsenteesByTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAbsenteesByTeacher]
    @teacher_id INT
AS
BEGIN
    SELECT
        A.studentSubjectId,
        A.isMotivated,
        A.date,
        A.studentID
    FROM
        Absence AS A
    INNER JOIN
        Student AS S ON A.studentID = S.id
    WHERE
        A.teacherId = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAbsenteesByTeacherClass]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAbsenteesByTeacherClass]
    @class_id INT,
    @teacher_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT s.studentSubjectID, a.isMotivated, a.date
    FROM Absence AS a
    INNER JOIN Subject s ON a.StudentSubjectID = s.studentSubjectID
    WHERE s.classID = @class_id AND s.teacherID = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAbsenteesByTeacherClassForStudentID]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAbsenteesByTeacherClassForStudentID]
    @class_id INT,
    @teacher_id INT,
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT studentSubjectID, isMotivated, date
    FROM Absence
    WHERE classID = @class_id
        AND teacherID = @teacher_id
        AND studentID = @student_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllAdmins]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAdmins]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT A.id, U.name, U.surname, U.password
    FROM TempAdmin AS A
    INNER JOIN [User] AS U ON A.id = U.id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllClasses]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllClasses]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id, specialization_id, head_teacher_id, name, number, year
    FROM Class;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllCourses]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCourses]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT c.id, c.name, s.name, c.path
    FROM Subject AS c
    INNER JOIN Specialization AS s ON c.specialization_id = s.id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudents]
AS
BEGIN
    SELECT
        S.id,
        S.classID,
        S.studentSubjectID,
        S.specializationID,
        U.name,
        U.surname,
        U.password
    FROM
        Student S
        INNER JOIN [User] AS U ON S.id = U.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllTeachers]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTeachers]
AS
BEGIN
SELECT
        T.id,
        T.teacherSubjectID,
        T.isHeadTeacher,
        U.name,
        U.surname,
        U.password
    FROM
        Teacher AS T
        INNER JOIN [User] AS U ON T.id = U.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS 
BEGIN
SELECT id,name,surname,password
FROM [User];
END
GO
/****** Object:  StoredProcedure [dbo].[GetClassFinalMarks]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassFinalMarks]
    @class_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT studentID, finalMark
    FROM Grade
    WHERE classID = @class_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClassFinalMarksWithStatus]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClassFinalMarksWithStatus]
    @class_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT studentID, finalMark,
        CASE
            WHEN finalMark >= 5 THEN
                CASE
                    WHEN ROW_NUMBER() OVER (ORDER BY finalMark DESC) <= 3 THEN
                        CASE ROW_NUMBER() OVER (ORDER BY finalMark DESC)
                            WHEN 1 THEN '1st Prize'
                            WHEN 2 THEN '2nd Prize'
                            WHEN 3 THEN '3rd Prize'
                        END
                    ELSE 'Mention'
                END
            ELSE 'Conditioned'
        END AS Status
    FROM Grade
    WHERE classID = @class_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetFinalGradesByStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFinalGradesByStudent]
    @student_id INT
AS
BEGIN
    SELECT
        Subject.name AS SubjectName,
        Grade.mark AS Mark
    FROM
        Grade
    INNER JOIN
        Subject ON Grade.studentSubjectID = Subject.id
    WHERE
        Grade.studentSubjectID IN (
            SELECT
                studentSubjectID
            FROM
                Student
            WHERE
                id = @student_id
        );
END;
GO
/****** Object:  StoredProcedure [dbo].[GetFinalGradesByTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFinalGradesByTeacher]
    @teacher_id INT
AS
BEGIN
    SELECT
        S.studentSubjectID,
        S.studentID,
        G.mark
    FROM
        Grade AS G
    INNER JOIN
        Subject AS S ON G.studentSubjectId = S.id
    WHERE
        S.teacherId = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetGradesByStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGradesByStudent]
    @student_id INT
AS
BEGIN
    SELECT
        Subject.name AS SubjectName,
        Grade.mark AS Mark
    FROM
        Grade
    INNER JOIN
        Subject ON Grade.studentSubjectID = Subject.id
    WHERE
        Grade.studentSubjectID IN (
            SELECT
                studentSubjectID
            FROM
                Student
            WHERE
                id = @student_id
        );
END;
GO
/****** Object:  StoredProcedure [dbo].[GetGradesByTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGradesByTeacher]
    @teacher_id INT
AS
BEGIN
    SELECT
        S.studentSubjectID,
        S.studentID,
        G.mark
    FROM
        Grade AS G
    INNER JOIN
        Subject AS S ON G.studentSubjectId = S.id
    WHERE
        S.teacherId = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSpecializationBySubjectID]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSpecializationBySubjectID]
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Specialization.name
    FROM Specialization
    INNER JOIN Subject ON Subject.specialization_id = Subject.id
    WHERE Subject.id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSpecializationIDByName]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSpecializationIDByName]
    @name VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id
    FROM Specialization
    WHERE name = @name;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSpecializationName]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSpecializationName]
    @id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT name
    FROM Specialization
    WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentFinalMarksByStudentId]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentFinalMarksByStudentId]
    @student_id VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [User].name, g.finalMark, g.semester, sub.name
    FROM Grade g
    INNER JOIN Student s ON s.id = g.studentID
    INNER JOIN Subject sub ON sub.id = g.subjectID
	INNER JOIN [User] ON [User].id=g.studentID
    WHERE g.studentID = @student_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentSpecializationName]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentSpecializationName]
    @specialization_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT name
    FROM Specialization
    WHERE id = @specialization_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentSubjects]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentSubjects]
    @student_id INT
AS
BEGIN
    SELECT
        Subject.name AS SubjectName,
        Teacher.name AS TeacherName,
        Teacher.surname AS TeacherSurname
    FROM
        Student
    INNER JOIN
        Subject ON Student.studentSubjectID = Subject.id
    INNER JOIN
        Teacher ON Subject.teacherID = Teacher.id
    WHERE
        Student.id = @student_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectByID]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSubjectByID]
    @subject_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id, name, specialization_id, path
    FROM Subject
    WHERE id = @subject_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectBySpecialization]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSubjectBySpecialization]
    @specialization_id INT,
    @name VARCHAR(50)
AS
BEGIN
    SELECT
        Subject.name
    FROM
        Subject
    WHERE
        Subject.specialization_id = @specialization_id
        AND Subject.name = @name;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectNameByStudentSubjectId]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSubjectNameByStudentSubjectId]
    @student_subject_id INT
AS
BEGIN
    SELECT
        Subject.name
    FROM
        Subject
    WHERE
        Subject.id = @student_subject_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherClasses]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeacherClasses]
    @teacher_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT name, number
    FROM Class
    WHERE head_teacher_iD = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherCourses]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeacherCourses]
    @teacher_id INT
AS
BEGIN
    SELECT
        S.id,
        S.name,
        S.specialization_id,
        S.path
    FROM
        Subject AS S
    WHERE
        S.teacherId = @teacher_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUnmotivatedAbsenteesByTeacherClass]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnmotivatedAbsenteesByTeacherClass]
    @class_id INT,
    @teacher_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT studentSubjectID, date
    FROM Absence
    WHERE classID = @class_id
        AND teacherID = @teacher_id
        AND isMotivated = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUnmotivatedAbsenteesByTeacherClassForStudentID]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnmotivatedAbsenteesByTeacherClassForStudentID]
    @class_id INT,
    @teacher_id INT,
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT studentSubjectID, isMotivated, date
    FROM Absence
    WHERE classID = @class_id
        AND teacherID = @teacher_id
        AND studentID = @student_id
        AND isMotivated = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertNewCourse]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertNewCourse]
    @subject_id INT,
    @name NVARCHAR(50),
    @specialization_ID INT,
    @path NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Subject (name, specialization_id, path)
    VALUES (@name, @specialization_ID, @path);
END;
GO
/****** Object:  StoredProcedure [dbo].[MotivateAbsence]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MotivateAbsence]
    @absence_id INT,
    @is_motivated BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Absence
    SET isMotivated = @is_motivated
    WHERE id = @absence_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[SaveGradesChanges]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveGradesChanges]
    @teacher_id INT,
    @isFinalGrade BIT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @grade_id INT, @student_subject_id INT, @mark FLOAT;

    DECLARE grade_cursor CURSOR FOR
        SELECT id, studentSubjectID, mark
        FROM Grade;

    OPEN grade_cursor;

    FETCH NEXT FROM grade_cursor INTO @grade_id, @student_subject_id, @mark;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @existing_grade_id INT;

        IF @isFinalGrade = 0
        BEGIN
            -- Check if grade with the same ID exists
            SELECT @existing_grade_id = id
            FROM Grade
            WHERE id = @grade_id;
        END
        ELSE
        BEGIN
            -- Check if final grade with the same ID exists
            SELECT @existing_grade_id = finalMarkID
            FROM Grade
            WHERE finalMarkID = @grade_id;
        END

        IF @existing_grade_id IS NOT NULL
        BEGIN
            -- Update existing grade
            IF @isFinalGrade = 0
            BEGIN
                UPDATE Grade
                SET Mark = @mark
                WHERE id = @grade_id;
            END
            ELSE
            BEGIN
                UPDATE Grade
                SET finalMark = @mark
                WHERE finalMarkID = @grade_id;
            END
        END
        ELSE
        BEGIN
            -- Insert new grade
            IF @isFinalGrade = 0
            BEGIN
                INSERT INTO Grade (studentSubjectID, mark, teacherID)
                VALUES ( @student_subject_id, @mark, @teacher_id);
            END
            ELSE
            BEGIN
                INSERT INTO Grade (finalMarkID, StudentSubjectID, finalMark, teacherID)
                VALUES (@grade_id, @student_subject_id, @mark, @teacher_id);
            END
        END

        FETCH NEXT FROM grade_cursor INTO @grade_id, @student_subject_id, @mark;
    END;

    CLOSE grade_cursor;
    DEALLOCATE grade_cursor;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateClass]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateClass]
    @id INT,
    @name NVARCHAR(50),
    @year INT,
    @number INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Class
    SET name = @name,
        year = @year,
        number = @number
    WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCourse]
    @subject_id INT,
    @name NVARCHAR(50),
    @specialization_ID INT,
    @path NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Subject
    SET name = @name,
        specialization_Id = @specialization_ID,
        path = @path
    WHERE id = @subject_id;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudent]
	@name VARCHAR(50),
	@surname VARCHAR(50),
	@password VARCHAR(50),
	@user_id INT,
	@class_id INT,
	@student_subject_id INT,
	@specialization_id INT
AS
BEGIN

UPDATE [User]
SET name=@name,
	surname=@surname,
	password=@password
WHERE [User].id=@user_id

UPDATE Student
SET classID= @class_id,
	studentSubjectID=@student_subject_id,
	specializationID=@specialization_id
WHERE id=@user_id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacher]    Script Date: 22.05.2023 23:37:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTeacher]
    @user_id INT,
    @name NVARCHAR(50),
    @surname NVARCHAR(50),
    @password NVARCHAR(50),
    @is_head_teacher BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [User]
    SET name = @name,
        surname = @surname,
        password = @password
    WHERE id= @user_id;

    UPDATE Teacher
    SET IsHeadTeacher = @is_head_teacher
    WHERE id = @user_id;
END;
GO
USE [master]
GO
ALTER DATABASE [MVP_DB] SET  READ_WRITE 
GO

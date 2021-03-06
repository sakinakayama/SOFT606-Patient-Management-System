USE [master]
GO
/****** Object:  Database [PatientManagementSyetem]    Script Date: 8/16/2021 3:14:07 PM ******/
CREATE DATABASE [PatientManagementSyetem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PatientManagementSyetem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PatientManagementSyetem.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PatientManagementSyetem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PatientManagementSyetem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PatientManagementSyetem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PatientManagementSyetem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PatientManagementSyetem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET ARITHABORT OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PatientManagementSyetem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PatientManagementSyetem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PatientManagementSyetem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PatientManagementSyetem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PatientManagementSyetem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET RECOVERY FULL 
GO
ALTER DATABASE [PatientManagementSyetem] SET  MULTI_USER 
GO
ALTER DATABASE [PatientManagementSyetem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PatientManagementSyetem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PatientManagementSyetem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PatientManagementSyetem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PatientManagementSyetem', N'ON'
GO
USE [PatientManagementSyetem]
GO
/****** Object:  Table [dbo].[tbAppointment]    Script Date: 8/16/2021 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbAppointment](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[SlotID] [int] NOT NULL,
	[PatientID] [int] NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[MedicalProblem] [varchar](200) NULL,
	[DiagnosisInfo] [varchar](200) NULL,
	[Prescription] [varchar](50) NULL,
	[Fee] [char](3) NULL,
	[Date] [date] NULL,
	[MedicalTests] [varchar](100) NULL,
	[PaymentOverdue] [varchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbDoctor]    Script Date: 8/16/2021 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbDoctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbPatient]    Script Date: 8/16/2021 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbPatient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[ContactNumber] [int] NOT NULL,
	[ImmigrationStatus] [varchar](20) NOT NULL,
	[Height] [decimal](5, 2) NULL,
	[Weight] [decimal](5, 2) NULL,
	[AdditionalNotes] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbSlot]    Script Date: 8/16/2021 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSlot](
	[SlotID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 8/16/2021 3:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUser](
	[UserID] [varchar](20) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[UserType] [varchar](20) NULL,
	[Password] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbAppointment] ON 

GO
INSERT [dbo].[tbAppointment] ([AppointmentID], [SlotID], [PatientID], [UserID], [DoctorID], [MedicalProblem], [DiagnosisInfo], [Prescription], [Fee], [Date], [MedicalTests], [PaymentOverdue]) VALUES (6, 1, 1, N'recep1', 1, N'Fever, Stomachache', N'Body tempreture 40 degree', N'Paracetamol 7 days', N'$15', CAST(N'2021-08-16' AS Date), N'Covid19 test', N'None')
GO
INSERT [dbo].[tbAppointment] ([AppointmentID], [SlotID], [PatientID], [UserID], [DoctorID], [MedicalProblem], [DiagnosisInfo], [Prescription], [Fee], [Date], [MedicalTests], [PaymentOverdue]) VALUES (11, 2, 1, N'recep1', 1, NULL, NULL, NULL, N'$15', CAST(N'2021-08-16' AS Date), NULL, N'None')
GO
INSERT [dbo].[tbAppointment] ([AppointmentID], [SlotID], [PatientID], [UserID], [DoctorID], [MedicalProblem], [DiagnosisInfo], [Prescription], [Fee], [Date], [MedicalTests], [PaymentOverdue]) VALUES (15, 5, 1, N'recep1', 2, NULL, NULL, NULL, N'$15', CAST(N'2021-08-18' AS Date), NULL, N'$20')
GO
INSERT [dbo].[tbAppointment] ([AppointmentID], [SlotID], [PatientID], [UserID], [DoctorID], [MedicalProblem], [DiagnosisInfo], [Prescription], [Fee], [Date], [MedicalTests], [PaymentOverdue]) VALUES (16, 1, 1, N'recep1', 1, NULL, NULL, NULL, NULL, CAST(N'2021-08-17' AS Date), NULL, NULL)
GO
INSERT [dbo].[tbAppointment] ([AppointmentID], [SlotID], [PatientID], [UserID], [DoctorID], [MedicalProblem], [DiagnosisInfo], [Prescription], [Fee], [Date], [MedicalTests], [PaymentOverdue]) VALUES (17, 1, 5, N'recep1', 1, N'Headeache', N'Stomachace caused by digestion', N'Anti-biotics for 14 days', N'$10', CAST(N'2021-08-18' AS Date), N'None', N'None')
GO
SET IDENTITY_INSERT [dbo].[tbAppointment] OFF
GO
SET IDENTITY_INSERT [dbo].[tbDoctor] ON 

GO
INSERT [dbo].[tbDoctor] ([DoctorID], [FirstName], [LastName]) VALUES (1, N'Masashi', N'Yoshida')
GO
INSERT [dbo].[tbDoctor] ([DoctorID], [FirstName], [LastName]) VALUES (2, N'Nick', N'Moriarty')
GO
SET IDENTITY_INSERT [dbo].[tbDoctor] OFF
GO
SET IDENTITY_INSERT [dbo].[tbPatient] ON 

GO
INSERT [dbo].[tbPatient] ([PatientID], [FirstName], [LastName], [Gender], [Address], [DOB], [Occupation], [ContactNumber], [ImmigrationStatus], [Height], [Weight], [AdditionalNotes]) VALUES (1, N'Saki', N'Nakayama', N'F', N'Morningside, Auckland', CAST(N'1990-04-11' AS Date), N'Developer', 12345, N'Student', CAST(156.00 AS Decimal(5, 2)), CAST(49.00 AS Decimal(5, 2)), N'New patient')
GO
INSERT [dbo].[tbPatient] ([PatientID], [FirstName], [LastName], [Gender], [Address], [DOB], [Occupation], [ContactNumber], [ImmigrationStatus], [Height], [Weight], [AdditionalNotes]) VALUES (2, N'Diana', N'Sanchez', N'F', N'Mt Wellington, Auckland', CAST(N'1992-12-02' AS Date), N'Student', 284757629, N'Student', NULL, NULL, NULL)
GO
INSERT [dbo].[tbPatient] ([PatientID], [FirstName], [LastName], [Gender], [Address], [DOB], [Occupation], [ContactNumber], [ImmigrationStatus], [Height], [Weight], [AdditionalNotes]) VALUES (5, N'Frodo', N'Baggins', N'M', N'1 Backend Street, Shire', CAST(N'1950-09-22' AS Date), N'Farmer', 9384734, N'Citizen', CAST(145.00 AS Decimal(5, 2)), CAST(60.00 AS Decimal(5, 2)), N'Had heart attack last year')
GO
SET IDENTITY_INSERT [dbo].[tbPatient] OFF
GO
SET IDENTITY_INSERT [dbo].[tbSlot] ON 

GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (1, CAST(N'09:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (2, CAST(N'09:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (3, CAST(N'09:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (4, CAST(N'09:45:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (5, CAST(N'10:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (6, CAST(N'10:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (7, CAST(N'10:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (8, CAST(N'11:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (9, CAST(N'11:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (10, CAST(N'12:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (11, CAST(N'12:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (12, CAST(N'12:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (13, CAST(N'12:45:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (14, CAST(N'13:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (15, CAST(N'14:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (16, CAST(N'14:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (17, CAST(N'14:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (18, CAST(N'14:45:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (19, CAST(N'15:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (20, CAST(N'15:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (21, CAST(N'15:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (22, CAST(N'15:45:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (23, CAST(N'16:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (24, CAST(N'16:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (25, CAST(N'16:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (26, CAST(N'16:45:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (27, CAST(N'17:00:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (28, CAST(N'17:15:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (29, CAST(N'17:30:00' AS Time))
GO
INSERT [dbo].[tbSlot] ([SlotID], [Time]) VALUES (30, CAST(N'17:45:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[tbSlot] OFF
GO
INSERT [dbo].[tbUser] ([UserID], [FirstName], [LastName], [UserType], [Password]) VALUES (N'doc1', N'Nick', N'Moriarty', N'Doctor', N'DOC1')
GO
INSERT [dbo].[tbUser] ([UserID], [FirstName], [LastName], [UserType], [Password]) VALUES (N'doc2', N'Masashi', N'Yoshida', N'Doctor', N'DOC2')
GO
INSERT [dbo].[tbUser] ([UserID], [FirstName], [LastName], [UserType], [Password]) VALUES (N'nurse1', N'Alexa', N'Chung', N'Nurse', N'NURSE1')
GO
INSERT [dbo].[tbUser] ([UserID], [FirstName], [LastName], [UserType], [Password]) VALUES (N'recep1', N'Emma', N'Watson', N'Receptionist', N'RECEP1')
GO
ALTER TABLE [dbo].[tbAppointment]  WITH CHECK ADD FOREIGN KEY([SlotID])
REFERENCES [dbo].[tbSlot] ([SlotID])
GO
ALTER TABLE [dbo].[tbAppointment]  WITH CHECK ADD  CONSTRAINT [FK_DoctorID] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[tbDoctor] ([DoctorID])
GO
ALTER TABLE [dbo].[tbAppointment] CHECK CONSTRAINT [FK_DoctorID]
GO
ALTER TABLE [dbo].[tbAppointment]  WITH CHECK ADD  CONSTRAINT [FK_PatientID] FOREIGN KEY([PatientID])
REFERENCES [dbo].[tbPatient] ([PatientID])
GO
ALTER TABLE [dbo].[tbAppointment] CHECK CONSTRAINT [FK_PatientID]
GO
ALTER TABLE [dbo].[tbAppointment]  WITH CHECK ADD  CONSTRAINT [FK_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[tbUser] ([UserID])
GO
ALTER TABLE [dbo].[tbAppointment] CHECK CONSTRAINT [FK_UserID]
GO
ALTER TABLE [dbo].[tbAppointment]  WITH CHECK ADD  CONSTRAINT [CHK_Fee] CHECK  (([Fee]='$15' OR [Fee]='$20' OR [Fee]='$10'))
GO
ALTER TABLE [dbo].[tbAppointment] CHECK CONSTRAINT [CHK_Fee]
GO
ALTER TABLE [dbo].[tbPatient]  WITH CHECK ADD  CONSTRAINT [chkGender] CHECK  (([Gender]='M' OR [Gender]='F'))
GO
ALTER TABLE [dbo].[tbPatient] CHECK CONSTRAINT [chkGender]
GO
ALTER TABLE [dbo].[tbPatient]  WITH CHECK ADD  CONSTRAINT [chkImmigrationStatus] CHECK  (([ImmigrationStatus]='Visitor' OR [ImmigrationStatus]='Student' OR [ImmigrationStatus]='Workers' OR [ImmigrationStatus]='Permanent residents' OR [ImmigrationStatus]='Citizen'))
GO
ALTER TABLE [dbo].[tbPatient] CHECK CONSTRAINT [chkImmigrationStatus]
GO
ALTER TABLE [dbo].[tbUser]  WITH CHECK ADD  CONSTRAINT [chkUserType] CHECK  (([UserType]='Nurse' OR [UserType]='Doctor' OR [UserType]='Receptionist'))
GO
ALTER TABLE [dbo].[tbUser] CHECK CONSTRAINT [chkUserType]
GO
USE [master]
GO
ALTER DATABASE [PatientManagementSyetem] SET  READ_WRITE 
GO

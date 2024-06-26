USE [master]
GO
/****** Object:  Database [hostel]    Script Date: 3/28/2024 3:28:28 AM ******/
CREATE DATABASE [hostel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hostel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\hostel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hostel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\hostel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [hostel] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hostel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hostel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hostel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hostel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hostel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hostel] SET ARITHABORT OFF 
GO
ALTER DATABASE [hostel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hostel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hostel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hostel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hostel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hostel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hostel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hostel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hostel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hostel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [hostel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hostel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hostel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hostel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hostel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hostel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hostel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hostel] SET RECOVERY FULL 
GO
ALTER DATABASE [hostel] SET  MULTI_USER 
GO
ALTER DATABASE [hostel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hostel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hostel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hostel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hostel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hostel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'hostel', N'ON'
GO
ALTER DATABASE [hostel] SET QUERY_STORE = ON
GO
ALTER DATABASE [hostel] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [hostel]
GO
/****** Object:  Table [dbo].[Backup_Student]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Backup_Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[lname] [varchar](250) NOT NULL,
	[fname] [varchar](250) NOT NULL,
	[mname] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[paddress] [varchar](250) NOT NULL,
	[college] [varchar](250) NOT NULL,
	[idproof] [varchar](250) NOT NULL,
	[roomNo] [varchar](250) NOT NULL,
	[living] [varchar](250) NULL,
	[username] [varchar](250) NOT NULL,
	[password] [varchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bus]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bus](
	[bienso] [varchar](50) NOT NULL,
	[machuyen] [varchar](50) NOT NULL,
	[gioxuatphat] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[machuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeSalary]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeSalary](
	[mobileNo] [bigint] NOT NULL,
	[fmonth] [varchar](60) NOT NULL,
	[amount] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[FeedbackText] [nvarchar](max) NULL,
	[FeedbackDate] [date] NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDungPhanHoi] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fees]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fees](
	[mobileNo] [bigint] NOT NULL,
	[fmonth] [varchar](60) NOT NULL,
	[amount] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[newEmployee]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[newEmployee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[emobile] [bigint] NOT NULL,
	[ename] [varchar](250) NOT NULL,
	[efname] [varchar](250) NOT NULL,
	[emname] [varchar](250) NOT NULL,
	[eemail] [varchar](250) NOT NULL,
	[epaddress] [varchar](250) NOT NULL,
	[eidproof] [varchar](250) NOT NULL,
	[edesignation] [varchar](250) NOT NULL,
	[working] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Student]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Student](
	[mobile] [varchar](20) NULL,
	[StudentName] [nvarchar](100) NULL,
	[RoomNo] [nvarchar](20) NULL,
	[Amount] [decimal](18, 2) NULL,
	[PaymentDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[roomNo] [varchar](250) NOT NULL,
	[roomStatus] [varchar](250) NOT NULL,
	[Booked] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[roomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mobile] [varchar](20) NULL,
	[lname] [varchar](250) NOT NULL,
	[fname] [varchar](250) NOT NULL,
	[mname] [varchar](250) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[paddress] [varchar](250) NOT NULL,
	[college] [varchar](250) NOT NULL,
	[idproof] [varchar](250) NOT NULL,
	[roomNo] [varchar](250) NOT NULL,
	[living] [varchar](250) NULL,
	[username] [varchar](250) NOT NULL,
	[password] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tieude] [nvarchar](100) NULL,
	[Noidung] [nvarchar](500) NULL,
	[Ghichu] [nvarchar](200) NULL,
	[LienLac] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/28/2024 3:28:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username_] [nvarchar](50) NOT NULL,
	[Password_] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Backup_Student] ON 

INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (2, 1234567890, N'Tuan', N'Nguyen', N'Anh', N'anhtuan@gmail.com', N'123 Le Loi, Q1, HCM', N'DHQG', N'123456789', N'101', N'Yes', N'1001', N'password1')
INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (3, 2345678901, N'Ngoc', N'Tran', N'Bao', N'baongoc@gmail.com', N'456 Tran Hung Dao, Q5, HCM', N'UIT', N'234567890', N'102', N'Yes', N'1002', N'password2')
INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (4, 3456789012, N'Mai', N'Le', N'Thi', N'thimai@gmail.com', N'789 Nguyen Trai, Q1, HCM', N'HUTECH', N'345678901', N'103', N'Yes', N'1003', N'password3')
INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (5, 4567890123, N'Minh', N'Pham', N'Van', N'vanminh@gmail.com', N'321 Le Lai, Q1, HCM', N'NEU', N'456789012', N'104', N'Yes', N'1004', N'password4')
INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (6, 5678901234, N'Trang', N'Ho', N'Thi', N'thitrang@gmail.com', N'654 Tran Phu, Q5, HCM', N'FTU', N'567890123', N'105', N'Yes', N'1005', N'password5')
INSERT [dbo].[Backup_Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (7, 5678901011, N'Thuy', N'Ho', N'Thi', N'thithuy@gmail.com', N'654 Tran Phu, Q5, HCM', N'FTU', N'5678901234', N'105', N'Yes', N'1006', N'password6')
SET IDENTITY_INSERT [dbo].[Backup_Student] OFF
GO
INSERT [dbo].[bus] ([bienso], [machuyen], [gioxuatphat]) VALUES (N'abc1', N'100', CAST(N'2024-03-26T11:45:00.000' AS DateTime))
INSERT [dbo].[bus] ([bienso], [machuyen], [gioxuatphat]) VALUES (N'abc4', N'110', CAST(N'2024-03-26T05:45:00.000' AS DateTime))
INSERT [dbo].[bus] ([bienso], [machuyen], [gioxuatphat]) VALUES (N'abc3', N'120', CAST(N'2024-03-26T04:45:00.000' AS DateTime))
INSERT [dbo].[bus] ([bienso], [machuyen], [gioxuatphat]) VALUES (N'abc2', N'130', CAST(N'2024-03-26T12:45:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [StudentID], [Name], [FeedbackText], [FeedbackDate], [TieuDe], [NoiDungPhanHoi]) VALUES (1, 1, N'John Doe', N'This is a sample feedback.', CAST(N'2024-03-20' AS Date), NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [StudentID], [Name], [FeedbackText], [FeedbackDate], [TieuDe], [NoiDungPhanHoi]) VALUES (2, 2, N'John Doe', N'This is a sample feedback.', CAST(N'2024-03-20' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
INSERT [dbo].[Payment_Student] ([mobile], [StudentName], [RoomNo], [Amount], [PaymentDate]) VALUES (N'5678901234', N'Ho', N'105', CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-03-27T22:50:11.607' AS DateTime))
INSERT [dbo].[Payment_Student] ([mobile], [StudentName], [RoomNo], [Amount], [PaymentDate]) VALUES (N'5678901011', N'Ho', N'105', CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-03-27T22:50:12.190' AS DateTime))
GO
INSERT [dbo].[rooms] ([roomNo], [roomStatus], [Booked]) VALUES (N'101', N'Available', N'No')
INSERT [dbo].[rooms] ([roomNo], [roomStatus], [Booked]) VALUES (N'102', N'Available', N'No')
INSERT [dbo].[rooms] ([roomNo], [roomStatus], [Booked]) VALUES (N'103', N'Available', N'No')
INSERT [dbo].[rooms] ([roomNo], [roomStatus], [Booked]) VALUES (N'104', N'Available', N'No')
INSERT [dbo].[rooms] ([roomNo], [roomStatus], [Booked]) VALUES (N'105', N'Available', N'No')
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (2, N'1234567890', N'Tuan', N'Nguyen', N'Anh', N'anhtuan@gmail.com', N'123 Le Loi, Q1, HCM', N'DHQG', N'123456789', N'101', N'Yes', N'1001', N'password1')
INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (3, N'2345678901', N'Ngoc', N'Tran', N'Bao', N'baongoc@gmail.com', N'456 Tran Hung Dao, Q5, HCM', N'UIT', N'234567890', N'102', N'Yes', N'1002', N'password2')
INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (4, N'3456789012', N'Mai', N'Le', N'Thi', N'thimai@gmail.com', N'789 Nguyen Trai, Q1, HCM', N'HUTECH', N'345678901', N'103', N'Yes', N'1003', N'password3')
INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (5, N'4567890123', N'Minh', N'Pham', N'Van', N'vanminh@gmail.com', N'321 Le Lai, Q1, HCM', N'NEU', N'456789012', N'104', N'Yes', N'1004', N'password4')
INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (6, N'5678901234', N'Trang', N'Ho', N'Thi', N'thitrang@gmail.com', N'654 Tran Phu, Q5, HCM', N'FTU', N'567890123', N'105', N'Yes', N'1005', N'password5')
INSERT [dbo].[Student] ([id], [mobile], [lname], [fname], [mname], [email], [paddress], [college], [idproof], [roomNo], [living], [username], [password]) VALUES (7, N'5678901011', N'Thuy', N'Ho', N'Thi', N'thithuy@gmail.com', N'654 Tran Phu, Q5, HCM', N'FTU', N'5678901234', N'105', N'Yes', N'1006', N'password6')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[Users] ([Username_], [Password_]) VALUES (N'admin', N'admin')
GO
ALTER TABLE [dbo].[newEmployee] ADD  DEFAULT ('Yes') FOR [working]
GO
ALTER TABLE [dbo].[rooms] ADD  DEFAULT ('No') FOR [Booked]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT ('Yes') FOR [living]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([roomNo])
REFERENCES [dbo].[rooms] ([roomNo])
GO
USE [master]
GO
ALTER DATABASE [hostel] SET  READ_WRITE 
GO

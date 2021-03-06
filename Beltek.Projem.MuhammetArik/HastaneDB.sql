USE [master]
GO
/****** Object:  Database [HastaneDB]    Script Date: 28.12.2021 20:44:43 ******/
CREATE DATABASE [HastaneDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HastaneDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HastaneDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HastaneDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HastaneDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HastaneDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HastaneDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HastaneDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HastaneDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HastaneDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HastaneDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HastaneDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HastaneDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HastaneDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HastaneDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HastaneDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HastaneDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HastaneDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HastaneDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HastaneDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HastaneDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HastaneDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HastaneDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HastaneDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HastaneDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HastaneDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HastaneDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HastaneDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HastaneDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HastaneDB] SET  MULTI_USER 
GO
ALTER DATABASE [HastaneDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HastaneDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HastaneDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HastaneDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HastaneDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HastaneDB]
GO
/****** Object:  Table [dbo].[tblDoktorlar]    Script Date: 28.12.2021 20:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDoktorlar](
	[DoktorId] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](20) NOT NULL,
	[Soyad] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tblDoktorlar] PRIMARY KEY CLUSTERED 
(
	[DoktorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHastalar]    Script Date: 28.12.2021 20:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHastalar](
	[HastaId] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](20) NOT NULL,
	[Soyad] [varchar](30) NOT NULL,
	[TCNo] [varchar](11) NOT NULL,
 CONSTRAINT [PK_tblHastalar] PRIMARY KEY CLUSTERED 
(
	[HastaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKlinikler]    Script Date: 28.12.2021 20:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKlinikler](
	[KlinikId] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblKlinikler] PRIMARY KEY CLUSTERED 
(
	[KlinikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRandevular]    Script Date: 28.12.2021 20:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRandevular](
	[RandevuId] [int] NOT NULL,
	[HastaId] [int] NOT NULL,
	[KlinikId] [int] NOT NULL,
	[DoktorId] [int] NOT NULL,
	[RandevuZamani] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblDoktorlar] ON 

INSERT [dbo].[tblDoktorlar] ([DoktorId], [Ad], [Soyad]) VALUES (5, N'Doktor', N'Doktor')
INSERT [dbo].[tblDoktorlar] ([DoktorId], [Ad], [Soyad]) VALUES (6, N'Doktor2', N'Doktor2')
SET IDENTITY_INSERT [dbo].[tblDoktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[tblHastalar] ON 

INSERT [dbo].[tblHastalar] ([HastaId], [Ad], [Soyad], [TCNo]) VALUES (4, N'Hasta', N'Hasta', N'12345678912')
INSERT [dbo].[tblHastalar] ([HastaId], [Ad], [Soyad], [TCNo]) VALUES (5, N'Hasta2', N'Hasta2', N'12345678913')
SET IDENTITY_INSERT [dbo].[tblHastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[tblKlinikler] ON 

INSERT [dbo].[tblKlinikler] ([KlinikId], [Adi]) VALUES (8, N'Cerrahi')
INSERT [dbo].[tblKlinikler] ([KlinikId], [Adi]) VALUES (9, N'Klinik2')
SET IDENTITY_INSERT [dbo].[tblKlinikler] OFF
GO
INSERT [dbo].[tblRandevular] ([RandevuId], [HastaId], [KlinikId], [DoktorId], [RandevuZamani]) VALUES (1, 4, 8, 5, CAST(N'2021-12-29T10:16:00.000' AS DateTime))
INSERT [dbo].[tblRandevular] ([RandevuId], [HastaId], [KlinikId], [DoktorId], [RandevuZamani]) VALUES (2, 5, 9, 6, CAST(N'2021-12-30T10:17:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tblHastalar]    Script Date: 28.12.2021 20:44:44 ******/
ALTER TABLE [dbo].[tblHastalar] ADD  CONSTRAINT [IX_tblHastalar] UNIQUE NONCLUSTERED 
(
	[TCNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblRandevular]  WITH CHECK ADD  CONSTRAINT [FK_tblRandevular_tblDoktorlar] FOREIGN KEY([DoktorId])
REFERENCES [dbo].[tblDoktorlar] ([DoktorId])
GO
ALTER TABLE [dbo].[tblRandevular] CHECK CONSTRAINT [FK_tblRandevular_tblDoktorlar]
GO
ALTER TABLE [dbo].[tblRandevular]  WITH CHECK ADD  CONSTRAINT [FK_tblRandevular_tblHastalar] FOREIGN KEY([HastaId])
REFERENCES [dbo].[tblHastalar] ([HastaId])
GO
ALTER TABLE [dbo].[tblRandevular] CHECK CONSTRAINT [FK_tblRandevular_tblHastalar]
GO
ALTER TABLE [dbo].[tblRandevular]  WITH CHECK ADD  CONSTRAINT [FK_tblRandevular_tblKlinikler] FOREIGN KEY([KlinikId])
REFERENCES [dbo].[tblKlinikler] ([KlinikId])
GO
ALTER TABLE [dbo].[tblRandevular] CHECK CONSTRAINT [FK_tblRandevular_tblKlinikler]
GO
USE [master]
GO
ALTER DATABASE [HastaneDB] SET  READ_WRITE 
GO

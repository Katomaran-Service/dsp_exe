USE [master]
GO
/****** Object:  Database [DSP_hotel]    Script Date: 10/02/2018 12:08:20 PM ******/
CREATE DATABASE [DSP_hotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DSP_hotrel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DSP_hotrel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DSP_hotrel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DSP_hotrel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DSP_hotel] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DSP_hotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DSP_hotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DSP_hotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DSP_hotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DSP_hotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DSP_hotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [DSP_hotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DSP_hotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DSP_hotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DSP_hotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DSP_hotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DSP_hotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DSP_hotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DSP_hotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DSP_hotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DSP_hotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DSP_hotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DSP_hotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DSP_hotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DSP_hotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DSP_hotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DSP_hotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DSP_hotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DSP_hotel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DSP_hotel] SET  MULTI_USER 
GO
ALTER DATABASE [DSP_hotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DSP_hotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DSP_hotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DSP_hotel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DSP_hotel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DSP_hotel] SET QUERY_STORE = OFF
GO
USE [DSP_hotel]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DSP_hotel]
GO
/****** Object:  User [paxstan]    Script Date: 10/02/2018 12:08:20 PM ******/
CREATE USER [paxstan] FOR LOGIN [paxstan] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [paxstan]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [paxstan]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [paxstan]
GO
ALTER ROLE [db_datareader] ADD MEMBER [paxstan]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [paxstan]
GO
/****** Object:  Table [dbo].[booking_status]    Script Date: 10/02/2018 12:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking_status](
	[booking_id] [nvarchar](50) NULL,
	[hotel] [nvarchar](50) NULL,
	[roomtype] [nvarchar](50) NULL,
	[booked_date] [nvarchar](50) NULL,
	[booked_intime] [nvarchar](50) NULL,
	[checkout_date] [nvarchar](50) NULL,
	[checkout_time] [nvarchar](50) NULL,
	[count] [nvarchar](50) NULL,
	[country_code] [nvarchar](50) NULL,
	[phonenumber] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[room_amount] [nvarchar](50) NULL,
	[advance_paid] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[checkin]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[checkin](
	[phonenumber] [nvarchar](50) NOT NULL,
	[room_group] [nvarchar](50) NULL,
	[checkin_date] [nvarchar](50) NULL,
	[checkin_time] [nvarchar](50) NULL,
	[checkin_out_date] [nvarchar](50) NULL,
	[checkin_out_time] [nvarchar](50) NULL,
	[referral] [nvarchar](50) NULL,
	[hotel_name] [nvarchar](50) NULL,
	[room_type] [nvarchar](100) NULL,
	[room_no] [nvarchar](50) NULL,
	[p_plan] [nvarchar](50) NULL,
	[person_count] [nvarchar](50) NULL,
	[kot_amount] [nvarchar](50) NULL,
	[kot_paid] [nvarchar](50) NULL,
	[nc_kot] [nvarchar](50) NULL,
	[post_charges] [nvarchar](50) NULL,
	[post_paid] [nvarchar](50) NULL,
	[advance_paid] [nvarchar](50) NULL,
	[advance_used] [nvarchar](50) NULL,
	[room_amt] [nvarchar](50) NULL,
	[room_paid] [nvarchar](50) NULL,
	[discount] [nvarchar](50) NULL,
	[total_amount] [nvarchar](50) NULL,
	[transaction_no] [nvarchar](200) NULL,
	[invoice] [nvarchar](200) NULL,
	[checkout] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[info1]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[info1](
	[name] [nchar](50) NOT NULL,
	[country_code] [nvarchar](50) NULL,
	[phone_number] [nchar](50) NOT NULL,
	[street_address] [nchar](50) NOT NULL,
	[district] [nchar](50) NOT NULL,
	[state] [nchar](50) NOT NULL,
	[country] [nchar](50) NOT NULL,
	[pincode] [nchar](50) NOT NULL,
	[mail] [nchar](50) NOT NULL,
	[dob] [nchar](50) NOT NULL,
	[marital_status] [nchar](50) NOT NULL,
	[anniversary_date] [nchar](50) NOT NULL,
	[id_proof] [nchar](50) NOT NULL,
	[id_num] [nchar](50) NOT NULL,
	[cform_filled] [nvarchar](50) NULL,
	[foreigner] [nchar](50) NULL,
	[foreigner_details] [nvarchar](4000) NULL,
	[visit_count] [nchar](50) NULL,
 CONSTRAINT [PK_info1] PRIMARY KEY CLUSTERED 
(
	[phone_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventory]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventory](
	[items] [nvarchar](50) NULL,
	[current_unit] [nvarchar](50) NULL,
	[threshold_unit] [nvarchar](50) NULL,
	[order_amount] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kot]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kot](
	[room_no] [nvarchar](50) NULL,
	[date] [nvarchar](50) NULL,
	[bill_no] [nvarchar](50) NULL,
	[nc_kot] [nvarchar](50) NULL,
	[amount] [nvarchar](50) NULL,
	[kot_type] [nvarchar](50) NULL,
	[number] [nvarchar](50) NULL,
	[items] [nvarchar](100) NULL,
	[session] [nvarchar](50) NULL,
	[steward] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[room_status]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[room_status](
	[room_no] [nvarchar](50) NOT NULL,
	[room_type] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[supervisor_name] [nvarchar](50) NOT NULL,
	[checkin_date] [nvarchar](50) NOT NULL,
	[checkin_time] [nvarchar](50) NOT NULL,
	[checkout_date] [nvarchar](50) NOT NULL,
	[checkout_time] [nvarchar](50) NOT NULL,
	[phonenumber] [nvarchar](50) NULL,
	[remark] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/02/2018 12:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[name] [nvarchar](50) NULL,
	[designation] [nvarchar](50) NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[front_desk] [int] NULL,
	[f_b] [int] NULL,
	[h_k] [int] NULL,
	[store] [int] NULL,
	[report] [int] NULL,
	[add_u] [int] NULL,
	[remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DSP_hotel] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [Shope]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE DATABASE [Shope]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shope', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Shope.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Shope_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Shope_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Shope] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shope].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shope] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Shope] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Shope] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Shope] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Shope] SET ARITHABORT OFF 
GO
ALTER DATABASE [Shope] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Shope] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Shope] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Shope] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Shope] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Shope] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Shope] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Shope] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Shope] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Shope] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Shope] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Shope] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Shope] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Shope] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Shope] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Shope] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Shope] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Shope] SET RECOVERY FULL 
GO
ALTER DATABASE [Shope] SET  MULTI_USER 
GO
ALTER DATABASE [Shope] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Shope] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Shope] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Shope] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Shope] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Shope] SET QUERY_STORE = OFF
GO
USE [Shope]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Shope]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carousel]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carousel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Carousel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Count] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](300) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ParentId] [int] NULL,
	[UserId] [int] NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factor]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Addres] [nvarchar](600) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Price] [int] NOT NULL,
	[Status] [nvarchar](15) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Count] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Factor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FactorProduct]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorProduct](
	[FactorId] [int] NOT NULL,
	[productsId] [int] NOT NULL,
 CONSTRAINT [PK_FactorProduct] PRIMARY KEY CLUSTERED 
(
	[FactorId] ASC,
	[productsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AltImage] [nvarchar](150) NOT NULL,
	[ImageName] [nvarchar](150) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupTitle] [nvarchar](200) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrowserTitle] [nvarchar](256) NOT NULL,
	[BrowserDescription] [nvarchar](300) NOT NULL,
	[PostTitle] [nvarchar](256) NOT NULL,
	[PostDescription] [nvarchar](300) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ImageName] [nvarchar](150) NOT NULL,
	[AltImage] [nvarchar](150) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Tags] [nvarchar](400) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](256) NOT NULL,
	[ProductBrowserDescription] [nvarchar](350) NOT NULL,
	[ProductBrowserTitle] [nvarchar](256) NOT NULL,
	[ProductText] [nvarchar](max) NOT NULL,
	[ProductImageName] [nvarchar](150) NULL,
	[AltImage] [nvarchar](200) NOT NULL,
	[Tags] [nvarchar](300) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[GroupId] [int] NOT NULL,
	[SubGroupId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPropertiy]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPropertiy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductPropertyTitle] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_ProductPropertiy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductPropertyRelations]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPropertyRelations](
	[PP_ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](150) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductPropertId] [int] NOT NULL,
 CONSTRAINT [PK_ProductPropertyRelations] PRIMARY KEY CLUSTERED 
(
	[PP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReviewText] [nvarchar](300) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleTitle] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[WalletId] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[SecureCode] [nvarchar](150) NOT NULL,
	[PhoneNumber] [nvarchar](11) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	[UserAvatar] [nvarchar](150) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WhishList]    Script Date: 11/25/2021 8:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WhishList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_WhishList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023115859_init', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023133525_edited_postalcode_factor', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023151622_init_docker', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211024060601_testing_connection', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211026125036_seed', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211026125900_seed_data', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Carousel] ON 

INSERT [dbo].[Carousel] ([Id], [Title], [Text], [Price], [Link], [Image]) VALUES (1, N'کالاهای باور نکردنی', N'همین حالا بخرش', 5000, N'http://localhost:5001/product', N'ZX6B5CPQFF80S7V2Y2H6FOE7U7ECO0589L0H8FS5FNIL5WFBBAQXRX6KT8Q77MBOJA1GGN4SJL02G2C71DBOKIRLPPX9ZV72L3B4484XF7NF6EE05TF4LXEATP11Z53YO7QN1IC3INJN.jpg')
INSERT [dbo].[Carousel] ([Id], [Title], [Text], [Price], [Link], [Image]) VALUES (2, N'مد بخر و بپوش', N'همبن حالا با مد جهانی همراه شو', 15000, N'http://localhost:5001/product/1', N'5LPKL6DGPCRYYBLOHD7KDY08X09XQMW7O1EHAQQ31XJMQ2YZ6YVEQ8JHVQXU6PZCPTK76DO0XESPPOR4CK010RRPR7WT356L7G67S033J5RMQ32G83SWY7L8C4Q9Q471HGSISULLQ7S5.jpg')
SET IDENTITY_INSERT [dbo].[Carousel] OFF
GO
SET IDENTITY_INSERT [dbo].[Factor] ON 

INSERT [dbo].[Factor] ([Id], [UserName], [LastName], [Phone], [Addres], [PostalCode], [Price], [Status], [CreateDate], [Count], [UserId]) VALUES (1, N'محمد', N'دبستانی', N'09135377502', N'میبد', N'65454', 1520000, N'SHIPPED', CAST(N'2021-10-23T06:43:41.8287713' AS DateTime2), 1, 9)
INSERT [dbo].[Factor] ([Id], [UserName], [LastName], [Phone], [Addres], [PostalCode], [Price], [Status], [CreateDate], [Count], [UserId]) VALUES (2, N'Mohamad', N'Dabestani', N'09135377502', N'Addres', N'123456', 3020000, N'DELIVERED', CAST(N'2021-11-25T01:38:47.5799052' AS DateTime2), 2, 1)
SET IDENTITY_INSERT [dbo].[Factor] OFF
GO
INSERT [dbo].[FactorProduct] ([FactorId], [productsId]) VALUES (1, 1)
INSERT [dbo].[FactorProduct] ([FactorId], [productsId]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([Id], [AltImage], [ImageName], [ProductId]) VALUES (4, N'prodcut alt image (gallery)', N'QPPA9FSMXXV8AQ5D74M76GMGIRYHXZ51DOEZLU72M5439CNVSYZ3AATKCI2RQKY7134VLF1M7UUBMTGGECZ8AB0C44WC2PLCG7BFH1JM7M5PPR8TCWMNV06ZD11RSYURIS5OSA8N2MBY.jpg', 1)
INSERT [dbo].[Gallery] ([Id], [AltImage], [ImageName], [ProductId]) VALUES (5, N'prodcut alt image (gallery)	', N'GKWM5DAGD7QQALCPA23I2OH7WTABX9VIZIT2EOWPXNOKCOOH8TMAT252DZZMC9TDMH121KKVFOVO965IF3DEWUZ7M1YPYJMX4L74XVPXI04EGR2H4RGI6OQ2S3P9W566C7UX8BUTNP55.jpg', 1)
INSERT [dbo].[Gallery] ([Id], [AltImage], [ImageName], [ProductId]) VALUES (6, N'This is a test alt image', N'XELEJIKZ13MZEOIW62XUPR24H42NVHXEOX8PUL7A3TOROUFCLWGHJN7GLQ7OQ6ETGHLRP2BV5X06CLQWZZC8BP4AZ1EENST7P4LGJYWSVVMWWBD99KZ14FS0MK1YX6HMD3QIAKMBCTNQ.jpg', 2)
INSERT [dbo].[Gallery] ([Id], [AltImage], [ImageName], [ProductId]) VALUES (7, N'This is a test alt image', N'DIOYXFEC32DKLU49685ZNAT3U59Z8YYK1CXE6DAS1ESKZG6PPNEEYYCCYUD2FPEFE3SI7ZD37M7JRIEO8TJUTTWDAUPMAIMM9NG6YXR0KLHL03UQPY3WFTWUHOINK13YAUJDCH0KBTKH.jpg', 2)
SET IDENTITY_INSERT [dbo].[Gallery] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (1, N'لوازم دیجیتالی', NULL)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (2, N'کامپیوتر', 1)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (3, N'تلویزیون', 1)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (5, N'کنسول بازی', 1)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (6, N'لوازم آشپزخانه', NULL)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (7, N'یخچال', 6)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (8, N'اجاق گاز', 6)
INSERT [dbo].[Group] ([GroupId], [GroupTitle], [ParentId]) VALUES (9, N'ماشین برقی', 1)
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [BrowserTitle], [BrowserDescription], [PostTitle], [PostDescription], [Text], [ImageName], [AltImage], [CreateDate], [Tags], [UserId]) VALUES (2, N'عنوان پست Browser Title', N'Browser Description value', N'عنوان پست', N'متن مختصر پست', N'توضیحات کامل پست', N'MKNH996LP0GP1WZJPEPSSSLFTROI8SUWJOH6BBNL5RJJO3MPSQ57E1Z49HXSUYN6FUGNO2IO0DXAIB1ZE8ZRXXSRYN74N50HDNE4X8BZIQGAEYV7P7NW86ISCZYB5NB5NQ6577CF7AIG.jpg', N'This is a test alt image', CAST(N'2021-11-25T02:01:16.9731467' AS DateTime2), N'asp.net 5 - asp.net 6', 1)
INSERT [dbo].[Post] ([Id], [BrowserTitle], [BrowserDescription], [PostTitle], [PostDescription], [Text], [ImageName], [AltImage], [CreateDate], [Tags], [UserId]) VALUES (3, N'Browser Title', N'Browser Description', N'عنوان پست', N'Post Description', N'متن کامل', N'QSN919OPREIHEV17J934PKWX10AS5IZ7XBCTMZK59VOJHZ0MFE57GN1F5ZHA95UJOLUDSHVUZ8546NPC9XM0M11KK6YWRJ5DBF46EX37TLIHS7ISJEBLT46XTJ2WT8DPC121ST8M4PGB.jpg', N'This is a test alt image', CAST(N'2021-11-25T02:02:25.8507559' AS DateTime2), N'کلمه ی کلیدی - عنوان کلمه ی کلیدی', 1)
INSERT [dbo].[Post] ([Id], [BrowserTitle], [BrowserDescription], [PostTitle], [PostDescription], [Text], [ImageName], [AltImage], [CreateDate], [Tags], [UserId]) VALUES (4, N'Browser Title', N'Browser Description', N'آیا باید برنامه نویس شد', N'Post Description', N'متن کامل', N'2B3J78BWUHJ2VA8ZRXD3O13Q0Q1922PR6SCR7WKK1MOPK7H5SAVL4RHBHNTQHB31216D8R25N2CCMNF2J5R2HDXOKBJUC3DZSWWTAE7BIZ8COEY4I0HLTBUZES37HH3TYMUZ0V2E8QTR.jpg', N'This is a test alt image', CAST(N'2021-11-25T02:03:41.8265758' AS DateTime2), N'maclaren - car', 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [ProductName], [ProductBrowserDescription], [ProductBrowserTitle], [ProductText], [ProductImageName], [AltImage], [Tags], [Quantity], [Price], [CreateDate], [GroupId], [SubGroupId]) VALUES (1, N'playstation 5', N'خرید محصول playstation 5', N'خرید playstation 5', N'متن این کالا', N'VZYQF4UIDB8GNYT82C022S40OV61QYLWJS70A3UDS1K1M1OREZDGOCJD48BT721P0M750378SWKAIDNWGOX0UEHGJ46C1AGZ94BA4T0K2EY21I50UPNTEB4VE0V674HRQVANCN2XXN8Q.jpg', N'متن جایگزین عکس', N'خرید پلی استیشن - صفه ی خرید پلی استیشن', 2, 1500000, CAST(N'2021-10-23T06:03:51.5156789' AS DateTime2), 1, 5)
INSERT [dbo].[Product] ([Id], [ProductName], [ProductBrowserDescription], [ProductBrowserTitle], [ProductText], [ProductImageName], [AltImage], [Tags], [Quantity], [Price], [CreateDate], [GroupId], [SubGroupId]) VALUES (2, N'یخچال دو در', N'یخچال دو در سامسونگ بخر و ببر', N'یخچال دو در سامسونگ', N'توضیحات مختصر محصول', N'TXU53OV7OODWWL1EDAUDF3YLLUBHQXFVSDZRH9HLDS37C0EYW876FE309ITIMNQ0ISDTWK6D2I9WA0JVPNVS0JQOJ9R8Q980CCZTWVCMB3D7EH0I972928A9CZKX27X3JJU7BZ94KIQ6.jpg', N'This is a test alt image', N'یخچال دو درب - یخچال سامسونگ - یخچال خارجکی', 5, 2000000, CAST(N'2021-11-25T01:49:24.1418098' AS DateTime2), 6, 7)
INSERT [dbo].[Product] ([Id], [ProductName], [ProductBrowserDescription], [ProductBrowserTitle], [ProductText], [ProductImageName], [AltImage], [Tags], [Quantity], [Price], [CreateDate], [GroupId], [SubGroupId]) VALUES (3, N'pc', N'pc Browser Description', N'pc Browser Title', N'Product Text', N'GSKCII9TG97DCZR7KPUDGJX4W2HJ88ZURD3TPIOT8EXKMQ5LICT5YMZ64PPQBZUIJMW867RCBAFCWNRG76B6O35EN6Y927SITOA946OKUR4YHXJQ8JTFYY4QRRU9JSJDR6SHNSMAR0M6.jpg', N'This is a test alt image', N'pc-ssd', 5, 50000, CAST(N'2021-11-25T01:50:22.0829418' AS DateTime2), 1, 2)
INSERT [dbo].[Product] ([Id], [ProductName], [ProductBrowserDescription], [ProductBrowserTitle], [ProductText], [ProductImageName], [AltImage], [Tags], [Quantity], [Price], [CreateDate], [GroupId], [SubGroupId]) VALUES (4, N'ps4', N'ps4 Browser Description', N'ps4 Browser Title', N'ps4 Product Text', N'9H70WHATONU5UTSMMOBBH1GKEBDQ7TY7M7QJU4NBR0YEMXX399XCZKZIBWVUEUW5ZWSXDJ1RB9TRCB8ROJQ75WIBIII8J267D3PZEA00HFAZ1HGAXDG5EZACORO5B3IJDWOJVIMOS0ZZ.jpg', N'This is a test alt image', N'ps4-ps4pro', 7, 7000, CAST(N'2021-11-25T01:51:19.2806900' AS DateTime2), 1, 5)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductPropertiy] ON 

INSERT [dbo].[ProductPropertiy] ([Id], [ProductPropertyTitle]) VALUES (1, N'رنگ')
INSERT [dbo].[ProductPropertiy] ([Id], [ProductPropertyTitle]) VALUES (2, N'وزن')
INSERT [dbo].[ProductPropertiy] ([Id], [ProductPropertyTitle]) VALUES (3, N'طول')
INSERT [dbo].[ProductPropertiy] ([Id], [ProductPropertyTitle]) VALUES (4, N'عرض')
SET IDENTITY_INSERT [dbo].[ProductPropertiy] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductPropertyRelations] ON 

INSERT [dbo].[ProductPropertyRelations] ([PP_ID], [Value], [ProductId], [ProductPropertId]) VALUES (1, N'سفید', 1, 1)
INSERT [dbo].[ProductPropertyRelations] ([PP_ID], [Value], [ProductId], [ProductPropertId]) VALUES (3, N'150 سانتی متر', 1, 4)
INSERT [dbo].[ProductPropertyRelations] ([PP_ID], [Value], [ProductId], [ProductPropertId]) VALUES (4, N'770 گرم', 1, 2)
INSERT [dbo].[ProductPropertyRelations] ([PP_ID], [Value], [ProductId], [ProductPropertId]) VALUES (5, N'230 سانتی متر', 1, 3)
SET IDENTITY_INSERT [dbo].[ProductPropertyRelations] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleTitle]) VALUES (1, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (1, 2000000, 1, CAST(N'2021-10-23T06:43:19.2642361' AS DateTime2), 1)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (2, 5000000, 1, CAST(N'2021-11-25T01:37:51.4792709' AS DateTime2), 2)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (3, 4000, 1, CAST(N'2021-11-25T05:37:43.3245965' AS DateTime2), 2)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (4, 500000, 1, CAST(N'2021-11-25T06:38:34.6901607' AS DateTime2), 2)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (5, 1, 1, CAST(N'2021-11-25T06:38:40.7645798' AS DateTime2), 2)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (6, 5000000, 1, CAST(N'2021-11-25T06:38:51.2063592' AS DateTime2), 2)
INSERT [dbo].[Transaction] ([Id], [Price], [Status], [CreateDate], [WalletId]) VALUES (7, 1, 1, CAST(N'2021-11-25T06:41:13.0466916' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Email], [Password], [SecureCode], [PhoneNumber], [IsActive], [RegisterDate], [UserAvatar], [RoleId]) VALUES (1, N'admin', N'Admin@gmail.com', N'25-F9-E7-94-32-3B-45-38-85-F5-18-1F-1B-62-4D-0B', N'ADU@kadkg45646@54asd@@!!', N'', 1, CAST(N'2021-10-26T05:58:59.9153516' AS DateTime2), N'user.jpg', 1)
INSERT [dbo].[User] ([Id], [UserName], [Email], [Password], [SecureCode], [PhoneNumber], [IsActive], [RegisterDate], [UserAvatar], [RoleId]) VALUES (9, N'Mohammad', N'mohamad1382mhd@gmail.com', N'25-F9-E7-94-32-3B-45-38-85-F5-18-1F-1B-62-4D-0B', N'DOVSUJYF5G74CI72D39K43D7V6VLIBVFULY0RX92EBVY8US3OUDXL4KKLY7XXM64V1K1UGLP3HF2IO8AO27Y784ZAOP30LF2F0DHK0IIIY3DZRB7Z6J5PH6X6U0G0SYSCNXRK00XTZPJE19TMSD3CJ', N'09135377502', 1, CAST(N'2021-10-23T05:24:45.8954116' AS DateTime2), N'O3G3HA04NS1SVUHU4KPWQE7O5M6V9ZSZ6GHCEBZB2GMIAFWS3TKYHTAK5274DE5YACWPMFQ3UN3K2YNZ0O1QO3SMF7GMD57XLYI8TGFYCQD3Z0RGOIEZNPJGTJJP8E0ZPF9EQOGTJCN8.jpg', NULL)
INSERT [dbo].[User] ([Id], [UserName], [Email], [Password], [SecureCode], [PhoneNumber], [IsActive], [RegisterDate], [UserAvatar], [RoleId]) VALUES (12, N'Mohammad', N'mohamadmehdideveloper@gmail.com', N'20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70', N'U0LJSHQE2JTYUTM4Z8L3M36XYM83H1BVMEUOI9ZZ50R51IWTJ5GE6ZZ04YVFIX6BH8LQ98WZJV8VMA5PZPTLU7YWO3UTOTQI4PX36GULJR5L0EN32FP3DVQKJZBFOCLZF016MCTT4HCDCN6KQ01JDX', N'0', 1, CAST(N'2021-11-25T05:51:14.1271071' AS DateTime2), N'user.jpg', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Wallet] ON 

INSERT [dbo].[Wallet] ([Id], [Price], [userId]) VALUES (1, 480000, 9)
INSERT [dbo].[Wallet] ([Id], [Price], [userId]) VALUES (2, 5000001, 1)
SET IDENTITY_INSERT [dbo].[Wallet] OFF
GO
SET IDENTITY_INSERT [dbo].[WhishList] ON 

INSERT [dbo].[WhishList] ([Id], [ProductId], [UserId]) VALUES (1, 1, 9)
SET IDENTITY_INSERT [dbo].[WhishList] OFF
GO
/****** Object:  Index [IX_Cart_ProductId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cart_ProductId] ON [dbo].[Cart]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cart_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cart_UserId] ON [dbo].[Cart]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_ParentId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comment_ParentId] ON [dbo].[Comment]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_PostId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comment_PostId] ON [dbo].[Comment]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comment_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comment_UserId] ON [dbo].[Comment]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Factor_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Factor_UserId] ON [dbo].[Factor]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FactorProduct_productsId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_FactorProduct_productsId] ON [dbo].[FactorProduct]
(
	[productsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Gallery_ProductId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Gallery_ProductId] ON [dbo].[Gallery]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group_ParentId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Group_ParentId] ON [dbo].[Group]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Post_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Post_UserId] ON [dbo].[Post]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_GroupId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Product_GroupId] ON [dbo].[Product]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_SubGroupId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Product_SubGroupId] ON [dbo].[Product]
(
	[SubGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductPropertyRelations_ProductId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductPropertyRelations_ProductId] ON [dbo].[ProductPropertyRelations]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductPropertyRelations_ProductPropertId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductPropertyRelations_ProductPropertId] ON [dbo].[ProductPropertyRelations]
(
	[ProductPropertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ProductId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ProductId] ON [dbo].[Reviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_UserId] ON [dbo].[Reviews]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transaction_WalletId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Transaction_WalletId] ON [dbo].[Transaction]
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_RoleId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_User_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wallet_userId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_Wallet_userId] ON [dbo].[Wallet]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WhishList_ProductId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_WhishList_ProductId] ON [dbo].[WhishList]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_WhishList_UserId]    Script Date: 11/25/2021 8:46:40 AM ******/
CREATE NONCLUSTERED INDEX [IX_WhishList_UserId] ON [dbo].[WhishList]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product_ProductId]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_User_UserId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Comment_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Comment] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Comment_ParentId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post_PostId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User_UserId]
GO
ALTER TABLE [dbo].[Factor]  WITH CHECK ADD  CONSTRAINT [FK_Factor_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Factor] CHECK CONSTRAINT [FK_Factor_User_UserId]
GO
ALTER TABLE [dbo].[FactorProduct]  WITH CHECK ADD  CONSTRAINT [FK_FactorProduct_Factor_FactorId] FOREIGN KEY([FactorId])
REFERENCES [dbo].[Factor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FactorProduct] CHECK CONSTRAINT [FK_FactorProduct_Factor_FactorId]
GO
ALTER TABLE [dbo].[FactorProduct]  WITH CHECK ADD  CONSTRAINT [FK_FactorProduct_Product_productsId] FOREIGN KEY([productsId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FactorProduct] CHECK CONSTRAINT [FK_FactorProduct_Product_productsId]
GO
ALTER TABLE [dbo].[Gallery]  WITH CHECK ADD  CONSTRAINT [FK_Gallery_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gallery] CHECK CONSTRAINT [FK_Gallery_Product_ProductId]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Group_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Group_ParentId]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User_UserId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Group_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Group_GroupId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Group_SubGroupId] FOREIGN KEY([SubGroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Group_SubGroupId]
GO
ALTER TABLE [dbo].[ProductPropertyRelations]  WITH CHECK ADD  CONSTRAINT [FK_ProductPropertyRelations_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPropertyRelations] CHECK CONSTRAINT [FK_ProductPropertyRelations_Product_ProductId]
GO
ALTER TABLE [dbo].[ProductPropertyRelations]  WITH CHECK ADD  CONSTRAINT [FK_ProductPropertyRelations_ProductPropertiy_ProductPropertId] FOREIGN KEY([ProductPropertId])
REFERENCES [dbo].[ProductPropertiy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductPropertyRelations] CHECK CONSTRAINT [FK_ProductPropertyRelations_ProductPropertiy_ProductPropertId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Product_ProductId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_User_UserId]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Wallet_WalletId] FOREIGN KEY([WalletId])
REFERENCES [dbo].[Wallet] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Wallet_WalletId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleId]
GO
ALTER TABLE [dbo].[Wallet]  WITH CHECK ADD  CONSTRAINT [FK_Wallet_User_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wallet] CHECK CONSTRAINT [FK_Wallet_User_userId]
GO
ALTER TABLE [dbo].[WhishList]  WITH CHECK ADD  CONSTRAINT [FK_WhishList_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WhishList] CHECK CONSTRAINT [FK_WhishList_Product_ProductId]
GO
ALTER TABLE [dbo].[WhishList]  WITH CHECK ADD  CONSTRAINT [FK_WhishList_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WhishList] CHECK CONSTRAINT [FK_WhishList_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [Shope] SET  READ_WRITE 
GO

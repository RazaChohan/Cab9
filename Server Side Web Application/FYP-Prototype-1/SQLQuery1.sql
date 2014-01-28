USE [stats.mdf]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Location_ID] [int] IDENTITY(1,1) NOT NULL,
	[Location_Name] [varchar](max) NOT NULL,
	[GPS_Coordinates] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Location_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fare]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fare](
	[Fare_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fare_Amount] [int] NOT NULL,
 CONSTRAINT [PK_Fare] PRIMARY KEY CLUSTERED 
(
	[Fare_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Owner](
	[Owner_ID] [int] IDENTITY(1,1) NOT NULL,
	[Owner_Name] [varchar](max) NOT NULL,
	[Owner_Password] [varchar](max) NOT NULL,
	[Owner_Email] [varchar](max) NULL,
	[Owner_PhNum] [int] NULL,
	[Owner_NIC] [varchar](max) NULL,
	[Owner_Address] [varchar](max) NULL,
	[Owner_Gender] [varchar](max) NULL,
	[Owner_Age] [int] NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Owner_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OptimumRoute]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OptimumRoute](
	[Route_ID] [int] IDENTITY(1,1) NOT NULL,
	[Route] [varchar](max) NULL,
	[Route_Destination] [varchar](max) NULL,
	[Route_Source] [varchar](max) NULL,
 CONSTRAINT [PK_OptimumRoute] PRIMARY KEY CLUSTERED 
(
	[Route_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cab]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cab](
	[Cab_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cab_RegNo] [varchar](max) NULL,
	[Cab_ChassisNum] [varchar](max) NULL,
	[Cab_Make] [varchar](max) NULL,
	[Cab_Model] [varchar](max) NULL,
	[Cab_Status] [varchar](max) NULL,
	[Cab_Color] [varchar](max) NULL,
 CONSTRAINT [PK_Cab] PRIMARY KEY CLUSTERED 
(
	[Cab_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Admin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Admin_Name] [varchar](max) NOT NULL,
	[Admin_Password] [varchar](max) NOT NULL,
	[Admin_Age] [int] NULL,
	[Admin_Gender] [varchar](max) NULL,
	[Admin_Address] [varchar](max) NULL,
	[Admin_NIC] [varchar](max) NULL,
	[Admin_Email] [varchar](max) NULL,
	[Admin_PhNum] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Admin_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PendingRegRequest]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PendingRegRequest](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Admin_ID] [int] NOT NULL,
	[User_Name] [varchar](max) NOT NULL,
	[User_Password] [varchar](max) NOT NULL,
	[User_Email] [varchar](max) NULL,
	[User_PhNum] [int] NULL,
	[User_NIC] [varchar](max) NULL,
	[User_Address] [varchar](max) NULL,
	[User_Gender] [varchar](max) NULL,
	[User_Age] [int] NULL,
 CONSTRAINT [PK_PendingRegRequest] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Driver](
	[Driver_ID] [int] IDENTITY(1,1) NOT NULL,
	[Route_ID] [int] NULL,
	[Cab_ID] [int] NULL,
	[Driver_Name] [varchar](max) NOT NULL,
	[Driver_Password] [varchar](max) NOT NULL,
	[Driver_Email] [varchar](max) NULL,
	[Driver_PhNum] [int] NULL,
	[Driver_NIC] [varchar](max) NULL,
	[Driver_Address] [varchar](max) NULL,
	[Driver_Gender] [varchar](max) NULL,
	[Driver_Age] [int] NULL,
	[Driver_Picture_URL] [varchar](max) NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[Driver_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Location_ID] [int] NULL,
	[Customer_Name] [varchar](max) NOT NULL,
	[Customer_Password] [varchar](max) NOT NULL,
	[Customer_Email] [varchar](max) NULL,
	[Customer_PhNum] [int] NULL,
	[Customer_NIC] [varchar](max) NULL,
	[Customer_Address] [varchar](max) NULL,
	[Customer_Gender] [varchar](max) NULL,
	[Customer_Age] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notification](
	[Not_ID] [int] IDENTITY(1,1) NOT NULL,
	[Admin_ID] [int] NULL,
	[Customer_ID] [int] NULL,
	[Owner_ID] [int] NULL,
	[Not_Content] [varchar](max) NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Not_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ETA]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ETA](
	[ETA_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[ETA_Time] [varchar](max) NULL,
 CONSTRAINT [PK_ETA] PRIMARY KEY CLUSTERED 
(
	[ETA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 12/06/2013 15:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Booking](
	[Booking_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[Fare_ID] [int] NULL,
	[Cab_ID] [int] NULL,
	[Booking_Status] [varchar](max) NOT NULL,
	[Booking_Date] [datetime] NOT NULL,
	[Booking_Source] [varchar](max) NOT NULL,
	[Booking_Time] [datetime] NOT NULL,
	[Booking_Destination] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Booking_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Booking_Cab]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Cab] FOREIGN KEY([Cab_ID])
REFERENCES [dbo].[Cab] ([Cab_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Cab]
GO
/****** Object:  ForeignKey [FK_Booking_Customer]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
/****** Object:  ForeignKey [FK_Booking_Fare]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Fare] FOREIGN KEY([Fare_ID])
REFERENCES [dbo].[Fare] ([Fare_ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Fare]
GO
/****** Object:  ForeignKey [FK_Customer_Location]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Location] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Location] ([Location_ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Location]
GO
/****** Object:  ForeignKey [FK_Driver_Cab]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Cab] FOREIGN KEY([Cab_ID])
REFERENCES [dbo].[Cab] ([Cab_ID])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_Cab]
GO
/****** Object:  ForeignKey [FK_Driver_OptimumRoute]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_OptimumRoute] FOREIGN KEY([Route_ID])
REFERENCES [dbo].[OptimumRoute] ([Route_ID])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_OptimumRoute]
GO
/****** Object:  ForeignKey [FK_ETA_Customer]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[ETA]  WITH CHECK ADD  CONSTRAINT [FK_ETA_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[ETA] CHECK CONSTRAINT [FK_ETA_Customer]
GO
/****** Object:  ForeignKey [FK_Notification_Admin1]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Admin1] FOREIGN KEY([Admin_ID])
REFERENCES [dbo].[Admin] ([Admin_ID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Admin1]
GO
/****** Object:  ForeignKey [FK_Notification_Customer]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Customer]
GO
/****** Object:  ForeignKey [FK_Notification_Owner]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Owner] FOREIGN KEY([Owner_ID])
REFERENCES [dbo].[Owner] ([Owner_ID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Owner]
GO
/****** Object:  ForeignKey [FK_PendingRegRequest_Admin]    Script Date: 12/06/2013 15:48:35 ******/
ALTER TABLE [dbo].[PendingRegRequest]  WITH CHECK ADD  CONSTRAINT [FK_PendingRegRequest_Admin] FOREIGN KEY([Admin_ID])
REFERENCES [dbo].[Admin] ([Admin_ID])
GO
ALTER TABLE [dbo].[PendingRegRequest] CHECK CONSTRAINT [FK_PendingRegRequest_Admin]
GO

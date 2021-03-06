USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/2/2017 11:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clientname] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 3/2/2017 11:34:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (12, N'joeclient', 8)
INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (13, N'joeclient2', 8)
INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (14, N'joeclient3', 8)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (8, N'Joe')
INSERT [dbo].[stylists] ([id], [name]) VALUES (9, N'Becky')
INSERT [dbo].[stylists] ([id], [name]) VALUES (10, N'nancy')
SET IDENTITY_INSERT [dbo].[stylists] OFF

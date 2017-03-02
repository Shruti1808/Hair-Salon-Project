USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/2/2017 12:37:28 AM ******/
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
/****** Object:  Table [dbo].[stylists]    Script Date: 3/2/2017 12:37:28 AM ******/
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

INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (1, N'shruti', 1)
INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (2, N'priti', 1)
INSERT [dbo].[clients] ([id], [clientname], [stylist_id]) VALUES (3, N'kunal', 1)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (1, N'Shahnaz hussain')
SET IDENTITY_INSERT [dbo].[stylists] OFF

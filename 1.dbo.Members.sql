Create database [sohyundb]
GO

USE [sohyundb]
GO

/****** Object:  Table [dbo].[Members]    Script Date: 2020-03-19 오후 4:24:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Members](
	[id] [varchar](20) NOT NULL,
	[pwd] [varchar](20) NOT NULL,
	[email] [varchar](50) NULL,
	[name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


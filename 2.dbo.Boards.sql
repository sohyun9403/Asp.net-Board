USE [sohyundb]
GO

/****** Object:  Table [dbo].[Boards]    Script Date: 2020-03-19 오후 4:24:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Boards](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[id] [varchar](20) NOT NULL,
	[subject] [nvarchar](100) NOT NULL,
	[regdate] [datetime] NOT NULL CONSTRAINT [DF_Board2_regdate]  DEFAULT (getdate()),
	[readCount] [int] NULL CONSTRAINT [DF_Board2_readCount]  DEFAULT ((0)),
	[filename] [varchar](100) NULL,
	[downloadCount] [int] NULL,
	[thread] [int] NULL,
	[depth] [int] NULL,
	[content] [nvarchar](3000) NULL,
	[idk] [int] NULL,
 CONSTRAINT [PK_Board2] PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Boards]  WITH CHECK ADD  CONSTRAINT [FK_board2_id] FOREIGN KEY([id])
REFERENCES [dbo].[Members] ([id])
GO

ALTER TABLE [dbo].[Boards] CHECK CONSTRAINT [FK_board2_id]
GO


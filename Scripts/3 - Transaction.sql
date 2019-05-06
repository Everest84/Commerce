USE [PocketChange]
GO

/****** Object:  Table [dbo].[Transaction]    Script Date: 5/6/2019 11:06:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction](
	[TransactionId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[TransactionType] [int] NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[ProcessingDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [DF_Transaction_ProcessingDate]  DEFAULT (getdate()) FOR [ProcessingDate]
GO

ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account__AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO

ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Account__AccountId]
GO


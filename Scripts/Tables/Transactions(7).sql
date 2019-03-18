USE [Commerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[TransactionId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[ProcessingDate] [datetime] NOT NULL,
	[Balance] [float],
	[TransactionType] [char],
	[Amount] [float],
	[Description1] [varchar](255),
	[Description2] [varchar](255),
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_TransactionId]  DEFAULT (newid()) FOR [TransactionId]
GO

ALTER TABLE [dbo].[Transactions] WITH CHECK ADD CONSTRAINT [FK_Transaction_AccountID] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_AccountID]
GO
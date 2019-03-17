USE [Commerce]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 3/16/2019 11:02:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[AccountId] [uniqueidentifier] NOT NULL,
	[AccountNumber] [varchar](255) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TypeId] [int] NOT NULL,
	[ReadOnly] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Table_1_AccountId]  DEFAULT (newid()) FOR [AccountId]
GO

ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_ReadOnly]  DEFAULT ((0)) FOR [ReadOnly]
GO

ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[AccountType] ([TypeId])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO

ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_UserRegistration_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO

ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_UserRegistration_UserId]
GO


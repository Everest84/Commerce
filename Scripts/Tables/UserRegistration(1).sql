USE [Commerce]
GO

/****** Object:  Table [dbo].[UserRegistration]    Script Date: 3/16/2019 11:00:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRegistration](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
 CONSTRAINT [PK_UserRegistration] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserRegistration] ADD  CONSTRAINT [DF_Table_1_GoalId]  DEFAULT (newid()) FOR [UserId]
GO

